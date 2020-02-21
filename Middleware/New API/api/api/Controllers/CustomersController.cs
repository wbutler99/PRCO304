using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Models;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using api.Models.BindingModels;
using api.Models.DTO;
using api.Utilities;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly PRCO304_wbutlerContext _context;

        public CustomersController(PRCO304_wbutlerContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public IQueryable<CustomerDTO> GetCustomers()
        {
            var customers = from c in _context.Customers
                            select new CustomerDTO()
                            {
                                CustomerId = (int)c.CustomerId,
                                Username = c.Username,
                                EmailAddress = c.EmailAddress,
                                FirstName = c.FirstName,
                                LastName = c.LastName,
                                DateOfBirth = (DateTime)c.DateOfBirth,
                                AddressLineOne = c.AddressLineOne,
                                AddressLineTwo = c.AddressLineTwo,
                                PostCode = c.Postcode
                            };
            return customers;
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDTO>> GetCustomers(int id)
        {
            var c = await _context.Customers.FindAsync(id);

            if (c == null)
            {
                return NotFound();
            }

            var customer = new CustomerDTO()
            {
                CustomerId = (int)c.CustomerId,
                Username = c.Username,
                EmailAddress = c.EmailAddress,
                FirstName = c.FirstName,
                LastName = c.LastName,
                DateOfBirth = (DateTime)c.DateOfBirth,
                AddressLineOne = c.AddressLineOne,
                AddressLineTwo = c.AddressLineTwo,
                PostCode = c.Postcode
            };



            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomers(int id, Customers customers)
        {
            if (id != customers.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers/Insert
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [Route("Insert")]
        public async Task<ActionResult<CustomerDTO>> PostCustomers([FromBody] CustomerRegistrationBindingModel registrationDetails)
        {
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
            Customers customers = new Customers()
            {
                Username = registrationDetails.Username,
                EmailAddress = registrationDetails.EmailAddress,
                CustomerHashedPassword = hashedPassword,
                PasswordSalt = generatedSalt,
                FirstName = registrationDetails.FirstName,
                LastName = registrationDetails.LastName,
                DateOfBirth = registrationDetails.DateOfBirth,
                AddressLineOne = registrationDetails.AddressLineOne,
                AddressLineTwo = registrationDetails.AddressLineTwo,
                Postcode = registrationDetails.PostCode,
            };

            _context.Customers.Add(customers);
            _context.SaveChanges();

            Customers addedCustomer = await _context.Customers.FindAsync(customers.CustomerId);

            if (addedCustomer == null)
            {
                //throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
                return NotFound();
            }

            CustomerDTO customerDetails = new CustomerDTO()
            {
                CustomerId = (int)addedCustomer.CustomerId,
                Username = addedCustomer.Username,
                EmailAddress = addedCustomer.EmailAddress,
                FirstName = addedCustomer.FirstName,
                LastName = addedCustomer.LastName,
                DateOfBirth = (DateTime)addedCustomer.DateOfBirth,
                AddressLineOne = addedCustomer.AddressLineOne,
                AddressLineTwo = addedCustomer.AddressLineTwo,
                PostCode = addedCustomer.Postcode

            };

            //return CreatedAtAction("GetCustomers", new { id = customers.CustomerId }, customerDetails);
            return Ok(customerDetails);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customers>> DeleteCustomers(int id)
        {
            var customers = await _context.Customers.FindAsync(id);
            if (customers == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customers);
            await _context.SaveChangesAsync();

            return customers;
        }

        private bool CustomersExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }

        private bool EmailExists(string emailAddress)
        {
            return _context.Customers.Any(e => e.EmailAddress == emailAddress);
        }

        private bool UsernameExists(string username)
        {
            return _context.Customers.Any(e => e.Username == username);
        }
    }
}
