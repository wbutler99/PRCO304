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
            lblDeliveryType.Visible = false;
            lblDeliveryDate.Visible = false;
            PopulateDelivery();
        }

        private void PopulateDelivery()
        {
            //Get the delivery data and populate the table with it

            DeliveryViewModel delivery = new DeliveryViewModel();

            List<DeliveryItemViewModel> items = new List<DeliveryItemViewModel>();

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:9000/")
            };
            var response = client.GetAsync("Delivery/Shop").Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync().Result;
                delivery = JsonConvert.DeserializeObject<DeliveryViewModel>(jsonString);
                lblDeliveryDate.Text = delivery.deliveryDate.ToString();
                lblDeliveryType.Text = delivery.deliveryType.ToString();
                lblDeliveryDate.Visible = true;
                lblDeliveryType.Visible = true;

                var deliveryName = delivery.deliveryName;
                var secondResponse = client.PostAsJsonAsync("Delivery/Shop/Items", deliveryName).Result;
                if(secondResponse.IsSuccessStatusCode)
                {
                    var secondJsonString = secondResponse.Content.ReadAsStringAsync().Result;
                    items = JsonConvert.DeserializeObject<List<DeliveryItemViewModel>>(secondJsonString);
                     foreach (DeliveryItemViewModel item in items)
                    {
                        grdDelivery.Rows.Add(item.productName, item.quantity);
                    }
                }
            }
            else
            {
                MessageBox.Show("Delivery Request failed. Please try again. Error Code: " + response.StatusCode.ToString(),
                    "Delivery Request Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            grdDelivery.Rows.Clear();
            PopulateDelivery();
        }
    }
}
