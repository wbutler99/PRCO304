using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CornerShopSecialistDesktop.Models
{
    class ShopViewModel
    {
        [JsonProperty("_id")]
        public string shopId { get; set; }
        [JsonProperty("storeName")]
        public string storeName { get; set; }
        [JsonProperty("addressLineOne")]
        public string addressLineOne { get; set; }
        [JsonProperty("addressLineTwo")]
        public string addressLineTwo { get; set; }
        [JsonProperty("postcode")]
        public string postcode { get; set; }


    }
}
