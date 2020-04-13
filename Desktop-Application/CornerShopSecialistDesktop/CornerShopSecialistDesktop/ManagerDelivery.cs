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
    public partial class ManagerDelivery : Form
    {
        public ManagerDelivery()
        {
            InitializeComponent();
            PopulateDelivery();
        }

        private void PopulateDelivery()
        {
            //Get the delivery data and populate the table with it

            List<DeliveryViewModel> deliveries = new List<DeliveryViewModel>();

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:9000/")
            };
            var response = client.GetAsync("Delivery/Shop").Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync().Result;
                deliveries = JsonConvert.DeserializeObject<List<DeliveryViewModel>>(jsonString);

                //grdStock.Rows.Add(stocks);
                foreach (DeliveryViewModel delivery in deliveries)
                {
                    grdDelivery.Rows.Add(delivery.productName, delivery.quantity);
                }
            }
            else
            {
                MessageBox.Show("Stock Request failed. Please try again. Error Code: " + response.StatusCode.ToString(),
                    "Stock Request Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
