using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CornerShopSecialistDesktop.Models
{
    class ShiftViewModel
    {
        [JsonProperty("storeName")]
        public string storeName { get; set; }
        [JsonProperty("username")]
        public string username { get; set; }
        [JsonProperty("shiftDate")]
        public DateTime shiftDate { get; set; }
    }
}
