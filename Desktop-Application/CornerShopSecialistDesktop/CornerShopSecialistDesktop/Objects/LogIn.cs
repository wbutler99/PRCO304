using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CornerShopSecialistDesktop.Objects
{
    class LogIn
    {
        [JsonProperty("username")]
        [JsonRequired]
        public string employeeUsername { get; set; }

        [JsonProperty("password")]
        [JsonRequired]
        public string employeePassword { get; set; }
    }
}
