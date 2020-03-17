using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CornerShopSecialistDesktop.Models
{
    class StockViewModel
    {
        [JsonProperty("productName")]
        public string productName { get; set; }

        [JsonProperty("stockType")]
        public string stockType { get; set; }

        [JsonProperty("description")]
        public string productDescription { get; set; }

        [JsonProperty("quantity")]
        public int quantity { get; set; }

        public StockViewModel(string productName, string stockType, string productDescription, int quantity)
        {
            this.productName = productName;
            this.stockType = stockType;
            this.productDescription = productDescription;
            this.quantity = quantity;
        }
    }
}
