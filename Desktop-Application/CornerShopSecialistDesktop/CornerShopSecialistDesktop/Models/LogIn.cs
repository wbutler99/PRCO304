﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CornerShopSecialistDesktop.Models
{
    class LogIn
    {
        [JsonProperty("username")]
        [JsonRequired]
        private string employeeUsername { get; set; }

        [JsonProperty("password")]
        [JsonRequired]
        private string employeePassword { get; set; }

        public LogIn(string username, string password)
        {
            employeeUsername = username;
            employeePassword = password;
        }
    }
}
