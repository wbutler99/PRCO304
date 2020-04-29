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
    public partial class ManagerReservations : Form
    {
        public ManagerReservations()
        {
            InitializeComponent();
            PopulateReservations();
        }

        public void PopulateReservations()
        {
            //Get the Reservation data and populate the table with it

            List<ReservationViewModel> reservations = new List<ReservationViewModel>();

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:9000/")
            };
            var response = client.GetAsync("Shop/Reservations").Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync().Result;
                reservations = JsonConvert.DeserializeObject<List<ReservationViewModel>>(jsonString);

                lblShop.Text = reservations[0].storeName;

                foreach(ReservationViewModel reservation in reservations)
                {
                    grdReservation.Rows.Add(reservation.name, reservation.productName);
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
