using CornerShopSecialistDesktop.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CornerShopSecialistDesktop
{
    public partial class Shops : Form
    {
        public Shops()
        {
            InitializeComponent();
            PopulateShops();
        }

        private void PopulateShops()
        {
            List<ShopViewModel> shops = new List<ShopViewModel>();
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:9000/")
            };
            var response = client.GetAsync("Shop").Result;
            if (response.IsSuccessStatusCode)
            {

                var jsonString = response.Content.ReadAsStringAsync().Result;
                shops = JsonConvert.DeserializeObject<List<ShopViewModel>>(jsonString);
                foreach (ShopViewModel shop in shops)
                {
                    grdShops.Rows.Add(shop.storeName, shop.addressLineOne, shop.addressLineTwo, shop.postcode);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            grdShops.Rows.Clear();
            PopulateShops();
        }
    }
}
