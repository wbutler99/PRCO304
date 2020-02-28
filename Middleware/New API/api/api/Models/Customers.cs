using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class Customers
    {
        public int CustomerId { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string CustomerHashedPassword { get; set; }
        public string PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string Postcode { get; set; }
    }
}
