using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using api.Models;
using api.Models.BindingModels;
using api.Models.DTO;
using api.Utilities;

namespace api.Controllers
{
    public class EmployeesController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Employees
        public IQueryable<EmployeeDTO> GetEMPLOYEES()
        {
            var employees = from e in db.EMPLOYEES
                            select new EmployeeDTO()
                            {
                                employeeId = e.employee_id,
                                firstName = e.employee_first_name,
                                lastName = e.employee_last_name,
                                username = e.employee_username,
                                emailAddress = e.employee_email_address,
                                DOB = e.employee_date_of_birth,
                                addressLineOne = e.employee_address_line_one,
                                addressLineTwo = e.employee_address_line_two,
                                postcode = e.employee_postcode,
                                sortCode = e.employee_sort_code,
                                accountNo = e.employee_account_no,
                                shopId = (int)e.employee_shop_id
                            };
            return employees;
        }

        // GET: api/Employees/5
        [ResponseType(typeof(EmployeeDTO))]
        public async System.Threading.Tasks.Task<IHttpActionResult> GetEMPLOYEEAsync(int id)
        {
            EMPLOYEE eMPLOYEE = db.EMPLOYEES.Find(id);
            var employee = await db.EMPLOYEES.Select(e =>
                new EmployeeDTO()
                {
                    employeeId = e.employee_id,
                    firstName = e.employee_first_name,
                    lastName = e.employee_last_name,
                    username = e.employee_username,
                    emailAddress = e.employee_email_address,
                    DOB = e.employee_date_of_birth,
                    addressLineOne = e.employee_address_line_one,
                    addressLineTwo = e.employee_address_line_two,
                    postcode = e.employee_postcode,
                    sortCode = e.employee_sort_code,
                    accountNo = e.employee_account_no,
                    shopId = (int)e.employee_shop_id
                }).SingleOrDefaultAsync(e => e.employeeId == id).ConfigureAwait(true);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEMPLOYEE(int id, EMPLOYEE eMPLOYEE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eMPLOYEE.employee_id)
            {
                return BadRequest();
            }

            db.Entry(eMPLOYEE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

        // POST: api/Employees/Insert
        [HttpPost]
        [Route("Insert")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PostEMPLOYEE([FromBody] EmployeeCreationBindingModel employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //Generate the hash and salt for the password before insertion
            string generatedSalt = Security.CreateSalt(32);
            string hashedPassword = Security.GenerateSHA256Hash(employee.password, generatedSalt);
            //Create a new employee to be inserted into the database
            EMPLOYEE insertEmployee = new EMPLOYEE()
            {
                employee_first_name = employee.firstName,
                employee_last_name = employee.lastName,
                employee_username = employee.username,
                employee_hashed_password = hashedPassword,
                employee_password_salt = generatedSalt,
                employee_email_address = employee.emailAddress,
                employee_date_of_birth = employee.DOB,
                employee_address_line_one = employee.addressLineOne,
                employee_address_line_two = employee.addressLineTwo,
                employee_postcode = employee.postcode,
                job_role = employee.jobRole,
                employee_sort_code = employee.sortCode,
                employee_account_no = employee.accountNo,
                employee_shop_id = employee.shopId
            };

            db.EMPLOYEES.Add(insertEmployee);
            //Attempt to save the changes to the database
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                //if (EMPLOYEEExists(eMPLOYEE.employee_id))
                //{
                //    return Conflict();
                //}
                //else
                //{
                //    throw;
                //}
                return BadRequest();
            }

            //return CreatedAtRoute("DefaultApi", new { id = eMPLOYEE.employee_id }, eMPLOYEE);
            HttpResponseMessage responseMessage = Request.CreateResponse(HttpStatusCode.Created, employee);
            return ResponseMessage(responseMessage);
        }

        //Login to web app for admin employees:
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        [ResponseType(typeof(EmployeeDTO))]
        public IHttpActionResult employeeLogin([FromBody] EmployeeLoginBindingModel loginCredentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //Checks to make sure that there are login credentials present
            if (string.IsNullOrEmpty(loginCredentials.employeeUsername) || string.IsNullOrEmpty(loginCredentials.employeePassword))
            {
                HttpError errorNoInput = new HttpError("Please enter a valid Username and Password.");
                HttpResponseMessage responseNoInput = Request.CreateErrorResponse(HttpStatusCode.Forbidden, errorNoInput);

                return ResponseMessage(responseNoInput);
            }
            //Checks if the user in question exists
            if (UsernameExists(loginCredentials.employeeUsername))
            {
                EMPLOYEE employeeDb = db.EMPLOYEES.SingleOrDefault(employee => employee.employee_username == loginCredentials.employeeUsername);

                if (employeeDb != null && loginCredentials.employeeUsername == employeeDb.employee_username)
                {
                    string attemptedPasswordHash = Security.GenerateSHA256Hash(loginCredentials.employeePassword, employeeDb.employee_password_salt);

                    if (employeeDb.employee_hashed_password.Equals(attemptedPasswordHash))
                    {
                        EmployeeDTO employeeDetails = new EmployeeDTO()
                        {
                            employeeId = employeeDb.employee_id,
                            firstName = employeeDb.employee_first_name,
                            lastName = employeeDb.employee_last_name,
                            username = employeeDb.employee_username,
                            emailAddress = employeeDb.employee_email_address,
                            DOB = employeeDb.employee_date_of_birth,
                            addressLineOne = employeeDb.employee_address_line_one,
                            addressLineTwo = employeeDb.employee_address_line_two,
                            postcode = employeeDb.employee_postcode,
                            sortCode = employeeDb.employee_sort_code,
                            accountNo = employeeDb.employee_account_no,
                            shopId = (int)employeeDb.employee_shop_id
                        };

                        //SUCCESS
                        return Ok(employeeDetails);
                    }
                    else
                    {
                        //403 Forbidden
                        HttpError forbiddenError = new HttpError("Incorrect Username and or password.");
                        HttpResponseMessage forbiddenResponse = Request.CreateErrorResponse(HttpStatusCode.Forbidden, forbiddenError);

                        return Ok(forbiddenResponse);
                    }
                }
            }
            //Not found within database:

            HttpError errorNotFound = new HttpError("Error finding account.");
            HttpResponseMessage responseNotFound = Request.CreateErrorResponse(HttpStatusCode.NotFound, errorNotFound);

            return ResponseMessage(responseNotFound);
        }

        // DELETE: api/Employees/5
        [HttpDelete]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteEMPLOYEE(string id)
        {
            EMPLOYEE employee = db.EMPLOYEES.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.EMPLOYEES.Remove(employee);
            db.SaveChanges();

            return Ok(employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int id)
        {
            return db.EMPLOYEES.Count(e => e.employee_id == id) > 0;
        }

        private bool UsernameExists(string username)
        {
            return db.EMPLOYEES.Count(e => e.employee_username == username) > 0;
        }
    }
}