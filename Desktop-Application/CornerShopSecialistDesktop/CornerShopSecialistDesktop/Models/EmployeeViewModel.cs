using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CornerShopSecialistDesktop.Models
{
    class EmployeeViewModel
    {
        [JsonProperty("employeeId")]
        public int employeeId { get; set; }

        [JsonProperty("firstName")]
        public string firstName { get; set; }

        [JsonProperty("lastName")]
        public string lastName { get; set; }

        [JsonProperty("username")]
        public string username { get; set; }

        [JsonProperty("emailAddress")]
        public string emailAddress { get; set; }

        [JsonProperty("DOB")]
        public DateTime DOB { get; set; }

        [JsonProperty("addressLineOne")]
        public string addressLineOne { get; set; }

        [JsonProperty("addressLineTwo")]
        public string addressLineTwo { get; set; }

        [JsonProperty("postcode")]
        public string postcode { get; set; }

        [JsonProperty("jobRole")]
        public string jobRole { get; set; }

        [JsonProperty("sortCode")]
        public string sortCode { get; set; }

        [JsonProperty("accountNo")]
        public string accountNo { get; set; }

        [JsonProperty("shopName")]
        public int shopName { get; set; }
    }
}
