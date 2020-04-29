using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CornerShopSecialistDesktop.Models
{
    class DeliveryViewModel
    {
        [JsonProperty("deliveryName")]
        public string deliveryName { get; set; }
        [JsonProperty("shopName")]
        public string shopName { get; set; }
        [JsonProperty("deliveryDate")]
        public DateTime deliveryDate { get; set; }
        [JsonProperty("deliveryType")]
        public string deliveryType { get; set; }
    }
}
