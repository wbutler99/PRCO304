using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class Employees
    {
        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeUsername { get; set; }
        public string EmployeeEmailAddress { get; set; }
        public DateTime EmployeeDateOfBirth { get; set; }
        public string EmployeeAddressLineOne { get; set; }
        public string EmployeeAddressLineTwo { get; set; }
        public string EmployeePostcode { get; set; }
        public string EmployeeHashedPassword { get; set; }
        public string EmployeePasswordSalt { get; set; }
        public string JobRole { get; set; }
        public string EmployeeSortCode { get; set; }
        public string EmployeeAccountNo { get; set; }
        public int? EmployeeShopId { get; set; }

        public virtual Shops EmployeeShop { get; set; }
    }
}
