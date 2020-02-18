using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace api.Controllers
{
    public class EmployeeLoginBindingModel
    {
        [JsonProperty("username")]
        [JsonRequired]
        public string employeeUsername { get; set; }

        [JsonProperty("password")]
        [JsonRequired]
        public string employeePassword { get; set; }
    }
}