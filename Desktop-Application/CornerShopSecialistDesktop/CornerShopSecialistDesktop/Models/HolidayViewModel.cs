using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CornerShopSecialistDesktop.Models
{
    class HolidayViewModel
    {
        [JsonProperty("holidayReference")]
        public string holidayReference { get; set; }
        [JsonProperty("storeName")]
        public string storeName { get; set; }
        [JsonProperty("username")]
        public string username { get; set; }
        [JsonProperty("startDate")]
        public DateTime startDate { get; set; }
        [JsonProperty("endDate")]
        public DateTime endDate { get; set; }
        [JsonProperty("status")]
        public string status { get; set; }
        [JsonProperty("reason")]
        public string reason { get; set; }
    }
}
