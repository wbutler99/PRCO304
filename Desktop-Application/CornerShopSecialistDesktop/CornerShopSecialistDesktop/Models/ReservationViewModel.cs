using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CornerShopSecialistDesktop.Models
{
    class ReservationViewModel
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("productName")]
        public string productName { get; set; }
        [JsonProperty("storeName")]
        public string storeName { get; set; }
    }
}
