﻿using CornerShopSecialistDesktop.Models;
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

                //grdStock.Rows.Add(stocks);
                foreach(StockViewModel stock in stocks)
                {
                    grdStock.Rows.Add(stock.productName, stock.quantity);
                }                
                
            //    DataGridViewRow newRow = new DataGridViewRow();
                //    newRow.CreateCells(grdStock);
                //    newRow.Cells[0].Value = stock.productName;
                //    newRow.Cells[1].Value = stock.quantity;

                //    grdStock.Rows.Add(newRow);
            }
            else
            {
                MessageBox.Show("Stock Request failed. Please try again. Error Code: " + response.StatusCode.ToString(),
                    "Stock Request Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
