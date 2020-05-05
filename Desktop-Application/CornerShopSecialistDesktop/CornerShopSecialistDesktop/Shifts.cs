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
    public partial class Shifts : Form
    {
        public Shifts()
        {
            InitializeComponent();
            lblShop.Visible = false;
            PopulateShifts();
        }

        private void btnNewShift_Click(object sender, EventArgs e)
        {
            NewShift newShift = new NewShift();
            newShift.Show();
        }

        private void PopulateShifts()
        {

            List<ShiftViewModel> shifts = new List<ShiftViewModel>();
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:9000/")
            };
            var response = client.GetAsync("Shop/Shift").Result;
            if (response.IsSuccessStatusCode)
            {            
                
                var jsonString = response.Content.ReadAsStringAsync().Result;
                shifts = JsonConvert.DeserializeObject<List<ShiftViewModel>>(jsonString);
                
                lblShop.Visible = true;
                foreach (ShiftViewModel shift in shifts)
                {
                    lblShop.Text = shift.storeName.ToString();
                    grdShifts.Rows.Add(shift.username, shift.shiftDate);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            grdShifts.Rows.Clear();
            PopulateShifts();
        }
    }
}
