using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Services
{
    public class EmployeeService
    {
        private Entities db = new Entities();

        public EMPLOYEE ValidateEmployee(string employeeId, string password)
        {
            EMPLOYEE employee = db.EMPLOYEES.FirstOrDefault(e => e.employee_id == employeeId);

            if (employee != null)
            {
                string attemptedHash = Utilities.Security.GenerateSHA256Hash(password, employee.employee_password_salt);
                if (attemptedHash.Equals(employee.employee_hashed_password))
                    return employee;
            }
            return null;
        }
    }
}