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
        private string productName { get; set; }

        [JsonProperty("stockType")]
        private string stockType { get; set; }

        [JsonProperty("description")]
        private string productDescription { get; set; }

        [JsonProperty("quantity")]
        private string quantity { get; set; }

        public StockViewModel(string productName, string stockType, string productDescription, string quantity)
        {
            this.productName = productName;
            this.stockType = stockType;
            this.productDescription = productDescription;
            this.quantity = quantity;
        }
    }
}
