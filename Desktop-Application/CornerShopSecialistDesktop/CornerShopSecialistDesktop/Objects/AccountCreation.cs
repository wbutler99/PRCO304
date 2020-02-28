using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CornerShopSecialistDesktop.Objects
{
    public class AccountCreation
    {
        [JsonProperty("firstName")]
        [JsonRequired]
        public string firstName { get; set; }

        [JsonProperty("lastName")]
        [JsonRequired]
        public string lastName { get; set; }

        [JsonProperty("username")]
        [JsonRequired]
        public string username { get; set; }

        [JsonProperty("password")]
        [JsonRequired]
        public string password { get; set; }

        [JsonProperty("emailAddress")]
        [JsonRequired]
        public string emailAddress { get; set; }

        [JsonProperty("DOB")]
        [JsonRequired]
        public DateTime DOB { get; set; }

        [JsonProperty("addressLineOne")]
        [JsonRequired]
        public string addressLineOne { get; set; }

        [JsonProperty("addressLineTwo")]
        [JsonRequired]
        public string addressLineTwo { get; set; }

        [JsonProperty("postcode")]
        [JsonRequired]
        public string postcode { get; set; }

        [JsonProperty("jobRole")]
        [JsonRequired]
        public string jobRole { get; set; }

        [JsonProperty("sortCode")]
        [JsonRequired]
        public string sortCode { get; set; }

        [JsonProperty("accountNo")]
        [JsonRequired]
        public string accountNo { get; set; }

        [JsonProperty("shopId")]
        public int shopId { get; set; }
    }
}