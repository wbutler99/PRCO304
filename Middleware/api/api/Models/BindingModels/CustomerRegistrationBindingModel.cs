using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace api.Models.BindingModels
{
    public class CustomerRegistrationBindingModel
    {
        [JsonProperty("username")]
        [JsonRequired]
        public string Username { get; set; }

        [JsonProperty("customerPassword")]
        [JsonRequired]
        public string CustomerPassword { get; set; }

        [JsonProperty("emailAddress")]
        [JsonRequired]
        public string EmailAddress { get; set; }

        [JsonProperty("firstName")]
        [JsonRequired]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        [JsonRequired]
        public string LastName { get; set; }

        [JsonProperty("dateOfBirth")]
        [JsonRequired]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty("addressLineOne")]
        [JsonRequired]
        public string AddressLineOne { get; set; }

        [JsonProperty("addressLineTwo")]
        [JsonRequired]
        public string AddressLineTwo { get; set; }

        [JsonProperty("postCode")]
        [JsonRequired]
        public string PostCode { get; set; }
    }
}