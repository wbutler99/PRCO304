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
    public partial class CreateDelivery : Form
    {
        public CreateDelivery()
        {
            InitializeComponent();
            PopulateShops();
        }

        private void btnCreateDelivery_Click(object sender, EventArgs e)
        {
            string newDeliveryName = txtDeliveryName.Text;
            string newStoreName = comStoreName.SelectedItem.ToString();
            DateTime newDeliveryDate = dtpDeliveryDate.Value.Date.AddHours(1);
            string newDeliveryType = comDeliveryType.SelectedItem.ToString();

            DeliveryViewModel newDelivery = new DeliveryViewModel();

            newDelivery.deliveryName = newDeliveryName;
            newDelivery.shopName = newStoreName;
            newDelivery.deliveryDate = newDeliveryDate;
            newDelivery.deliveryType = newDeliveryType;

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:9000/")
            };
            var response = client.PostAsJsonAsync("Create/Delivery", newDelivery).Result;
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("New Delivery Created.", "New Delivery Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comStoreName.Items.Clear();
                dtpDeliveryDate.Value.ToLocalTime();
            }
            else
            {
                MessageBox.Show("New Delivery Creation failed. Please check your credentials and try again. Error Code: " + response.StatusCode.ToString(),
                    "New Delivery Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PopulateShops()
        {
            List<ShopViewModel> shops = new List<ShopViewModel>();
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:9000/")
            };
            var response = client.GetAsync("Shop").Result;
            if(response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync().Result;
                shops = JsonConvert.DeserializeObject<List<ShopViewModel>>(jsonString);

                foreach(ShopViewModel shop in shops)
                {
                    comStoreName.Items.Add(shop.storeName);
                }
            }
        }
    }
}
