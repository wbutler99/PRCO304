﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CornerShopSecialistDesktop.Models
{
    class DeliveryItemViewModel
    {
        [JsonProperty("deliveryName")]
        public string deliveryname { get; set; }
        [JsonProperty("productName")]
        public string productName { get; set; }
        [JsonProperty("quantity")]
        public int quantity { get; set; }
    }
}
