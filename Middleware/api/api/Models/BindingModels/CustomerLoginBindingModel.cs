using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace api.Models.BindingModels
{
    //This class handles the JSON data for logging a customer into 
    //the system when it is passed from the client
    public class CustomerLoginBindingModel
    {
        [JsonProperty("username")]
        [JsonRequired]
        public string Username { get; set; }

        [JsonProperty("password")]
        [JsonRequired]
        public string Password { get; set; }
    }
}