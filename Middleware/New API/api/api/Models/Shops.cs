using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class Shops
    {
        public Shops()
        {
            Employees = new HashSet<Employees>();
        }

        public int ShopId { get; set; }
        public string ShopName { get; set; }
        public string ShopAddressLineOne { get; set; }
        public string ShopAddressLineTwo { get; set; }
        public string ShopPostcode { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
    }
}
