﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace api.Models.DTO
{
    public class CustomerDTO
    {
        [JsonProperty("customerId")]
        public int CustomerId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [JsonProperty("addressLineOne")]
        public string AddressLineOne { get; set; }

        [JsonProperty("addressLineTwo")]
        public string AddressLineTwo { get; set; }

        [JsonProperty("postCode")]
        public string PostCode { get; set; }

    }
}