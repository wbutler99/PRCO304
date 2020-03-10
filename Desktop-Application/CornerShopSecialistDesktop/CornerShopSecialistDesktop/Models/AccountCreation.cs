using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CornerShopSecialistDesktop.Models
{
    public class AccountCreation
    {

        [JsonProperty("firstName")]
        public string firstName { get; set; }

        [JsonProperty("lastName")]
        public string lastName { get; set; }

        [JsonProperty("username")]
        public string username { get; set; }

        [JsonProperty("password")]
        public string password { get; set; }

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

        //[JsonProperty("shopId")]
        //public int shopId { get; set; }

        public AccountCreation(string username, string firstName, string lastName, string password, string email, DateTime dOB, string addressLineOne, string addressLineTwo, 
            string postcode, string jobRole, string sortCode, string accountNo)
        {
            this.username = username;
            this.firstName = firstName;
            this.lastName = lastName;
            this.password = password;
            this.emailAddress = email;
            DOB = dOB;
            this.addressLineOne = addressLineOne;
            this.addressLineTwo = addressLineTwo;
            this.postcode = postcode;
            this.jobRole = jobRole;
            this.sortCode = sortCode;
            this.accountNo = accountNo;
            //this.shopId = shopId;
        }
    }
}