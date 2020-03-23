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

        [JsonProperty("quantity")]
        public int quantity { get; set; }

        public StockViewModel(string productName, int quantity)
        {
            this.productName = productName;
            this.quantity = quantity;
        }
    }
}
