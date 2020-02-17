using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using api.Models;
using api.Models.BindingModels;
using api.Models.DTO;
using api.Utilities;

namespace api.Controllers
{
    [Authorize]
    // Add RoutePrefix to specify the location of this resource.
    [EnableCors(origins: "http://localhost:44308", headers: "*", methods: "*")]
    [RoutePrefix("api/Customers")]
    public class CustomersController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Customers
        [HttpGet]
        [Route("")]
        public IQueryable<CustomerDTO> GetCUSTOMERS()
        {
            var customers = from c in db.CUSTOMERS
                            select new CustomerDTO()
                            {
                                CustomerId = (int)c.customer_id,
                                Username = c.username,
                                EmailAddress = c.email_address,
                                FirstName = c.first_name,
                                LastName = c.last_name,
                                DateOfBirth = (DateTime)c.date_of_birth,
                                AddressLineOne = c.address_line_one,
                                AddressLineTwo = c.address_line_two,
                                PostCode = c.postcode
                            };
            return customers;
        }

        // GET: api/Customers/5
        [HttpGet, Authorize(Roles = "Customer, Employee")]
        [Route("{id:int}", Name = "GetCustomerDetailsById")]
        [ResponseType(typeof(CustomerDTO))]
        public async Task<IHttpActionResult> GetCUSTOMERAsync(int id)
        {
            //CUSTOMER cUSTOMER = db.CUSTOMERS.Find(id);
            // Select the CUSTOMER object from the database model and create a CustomerDTO object from it.

            var customer = await db.CUSTOMERS.Select(c =>
                new CustomerDTO()
                {
                    CustomerId = (int)c.customer_id,
                    Username = c.username,
                    EmailAddress = c.email_address,
                    FirstName = c.first_name,
                    LastName = c.last_name,
                    DateOfBirth = (DateTime)c.date_of_birth,
                    AddressLineOne = c.address_line_one,
                    AddressLineTwo = c.address_line_two,
                    PostCode = c.postcode
                }).SingleOrDefaultAsync(c => c.CustomerId == id).ConfigureAwait(false);

            // If the retrieved customer is null then return a 401 Not Found.
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/Customers/5
        [HttpPut, Authorize(Roles = "Customer")]
        [Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCUSTOMER(int id, CUSTOMER cUSTOMER)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cUSTOMER.customer_id)
            {
                return BadRequest();
            }

            db.Entry(cUSTOMER).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Customers/Insert
        // Used to CREATE a new customer and add them to my database.
        [AllowAnonymous]
        [HttpPost]
        [Route("Insert")]
        [ResponseType(typeof(CustomerDTO))]
        public IHttpActionResult PostCUSTOMER(CustomerRegistrationBindingModel registrationDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (registrationDetails == null)
            {
                return BadRequest();
            }

            // Check if the customer already exists under the email address provided, 
            // if so return a Conflict HTTP response code.
            if (EmailExists(registrationDetails.EmailAddress) || UsernameExists(registrationDetails.Username))
            {
                return Conflict();
            }

            // Generate the password hash and salt to store for the customer record.
            string generatedSalt = Security.CreateSalt(32);
            string hashedPassword = Security.GenerateSHA256Hash(registrationDetails.CustomerPassword, generatedSalt);

            // Create customer object based on the details received and processed.
            CUSTOMER customer = new CUSTOMER()
            {
                username = registrationDetails.Username,
                email_address = registrationDetails.EmailAddress,
                customer_hashed_password = hashedPassword,
                password_salt = generatedSalt,
                first_name = registrationDetails.FirstName,
                last_name = registrationDetails.LastName,
                date_of_birth = registrationDetails.DateOfBirth,
                address_line_one = registrationDetails.AddressLineOne,
                address_line_two = registrationDetails.AddressLineTwo,
                postcode = registrationDetails.PostCode,
            };

            // Add the customer object to our database as a record.
            db.CUSTOMERS.Add(customer);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                // A DbUpdateException will occur if the data does not match what the database expects
                // i.e. constraints are violated, we can send back a bad request HTTP response.
                // Return a 403 Forbidden with an error message.
                HttpError err = new HttpError("Constraint failure.");
                HttpResponseMessage responseMessage = Request.CreateErrorResponse(HttpStatusCode.BadRequest, err);

                return ResponseMessage(responseMessage);
            }

            // Find the added user by the email address provided by the client.
            CUSTOMER addedCustomer = db.CUSTOMERS.SingleOrDefault(dbCustomer => dbCustomer.email_address == customer.email_address);
            if (addedCustomer == null)
            {
                //throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
                return NotFound();
            }

            CustomerDTO customerDetails = new CustomerDTO()
            {
                CustomerId = (int)addedCustomer.customer_id,
                Username = addedCustomer.username,                
                EmailAddress = addedCustomer.email_address,
                FirstName = addedCustomer.first_name,
                LastName = addedCustomer.last_name,
                DateOfBirth = addedCustomer.date_of_birth,
                AddressLineOne = addedCustomer.address_line_one,
                AddressLineTwo = addedCustomer.address_line_two,
                PostCode = addedCustomer.postcode

            };

            //return CreatedAtRoute("GetCustomerDetailsById", new { id = customerDetails.CustomerId }, customerDetails);
            return Ok();
        }

        // POST: api/Customers/Login
        // Used to login a user to the customer application.
        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        [ResponseType(typeof(CustomerDTO))]
        public IHttpActionResult PostCUSTOMERLogin([FromBody] CustomerLoginBindingModel loginDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrEmpty(loginDetails.Username) || string.IsNullOrEmpty(loginDetails.Password))
            {
                // Return 403 Forbidden with error message.
                HttpError err = new HttpError("Ensure that your username and password are provided.");
                HttpResponseMessage responseMessage = Request.CreateErrorResponse(HttpStatusCode.Forbidden, err);

                return ResponseMessage(responseMessage);
            }

            // Ensure there is a user under this email address.
            if (UsernameExists(loginDetails.Username))
            {
                // Get the customer record from the database that matches the email address provided.
                CUSTOMER dbCustomer = db.CUSTOMERS.SingleOrDefault(customer => customer.username == loginDetails.Username);

                if (dbCustomer != null && loginDetails.Username.Equals(dbCustomer.username))
                {
                    // Get the stored salt for the customer and the attempted password.
                    string attemptedPasswordHash = Security.GenerateSHA256Hash(loginDetails.Password, dbCustomer.password_salt);

                    // If the password hash matches that stored in the database then the user is authenticated.
                    if (dbCustomer.customer_hashed_password.Equals(attemptedPasswordHash))
                    {
                        // Return the user details as with the Customer Data Transfer Object.
                        CustomerDTO customerDetails = new CustomerDTO()
                        {
                            CustomerId = (int)dbCustomer.customer_id, 
                            Username = dbCustomer.username,
                            EmailAddress = dbCustomer.email_address,
                            FirstName = dbCustomer.first_name,
                            LastName = dbCustomer.last_name,
                            DateOfBirth = dbCustomer.date_of_birth,
                            AddressLineOne = dbCustomer.address_line_one,
                            AddressLineTwo = dbCustomer.address_line_two,
                            PostCode = dbCustomer.postcode

                        };

                        return Ok(customerDetails);
                    }
                    else
                    {
                        // Return a 403 Forbidden with an error message.
                        HttpError err = new HttpError("Ensure that the username and password are correct for the account you are trying to access.");
                        HttpResponseMessage responseMessage = Request.CreateErrorResponse(HttpStatusCode.Forbidden, err);

                        return ResponseMessage(responseMessage);
                    }
                }
                else
                {
                    // In the event that we cannot fetch the customer record based on the provided username.
                    HttpError err = new HttpError("There was an error processing the login details you have provided on our side.");
                    HttpResponseMessage responseMessage = Request.CreateErrorResponse(HttpStatusCode.NotFound, err);

                    return ResponseMessage(responseMessage);
                }

            }
            else
            {
                // The username the user requested is not registered to an account.
                HttpError err = new HttpError("This account is not yet registered with our service.");
                HttpResponseMessage responseMessage = Request.CreateErrorResponse(HttpStatusCode.NotFound, err);

                return ResponseMessage(responseMessage);
            }
        }

        // DELETE: api/Customers/5
        [HttpDelete, Authorize(Roles = "Employee")]
        [Route("{id:int}")]
        [ResponseType(typeof(CUSTOMER))]
        public IHttpActionResult DeleteCUSTOMER(int id)
        {
            CUSTOMER cUSTOMER = db.CUSTOMERS.Find(id);
            if (cUSTOMER == null)
            {
                return NotFound();
            }

            db.CUSTOMERS.Remove(cUSTOMER);
            db.SaveChanges();

            return Ok(cUSTOMER);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(decimal id)
        {
            return db.CUSTOMERS.Count(e => e.customer_id == id) > 0;
        }

        private bool EmailExists(string emailAddress)
        {
            return db.CUSTOMERS.Count(e => e.email_address == emailAddress) > 0;
        }

        private bool UsernameExists(string username)
        {
            return db.CUSTOMERS.Count(u => u.username == username) > 0;
        }
    }
}