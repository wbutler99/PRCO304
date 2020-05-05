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
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent();
            PopulateStock();

        }

        public void PopulateStock()
        {
            //Get the stock data and populate the table with it

            List<StockViewModel> stocks = new List<StockViewModel>();

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:9000/")
            };
            var response = client.GetAsync("Staff/Stock").Result;
            if(response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync().Result;
                stocks = JsonConvert.DeserializeObject<List<StockViewModel>>(jsonString);

                
                foreach(StockViewModel stock in stocks)
                {
                    lblShop.Text = stock.storeName;
                    grdStock.Rows.Add(stock.productName, stock.quantity);
                }                
            }
            else
            {
                MessageBox.Show("Stock Request failed. Please try again. Error Code: " + response.StatusCode.ToString(),
                    "Stock Request Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            grdStock.Rows.Clear();
            PopulateStock();
        }
    }
}
