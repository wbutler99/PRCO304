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
    public partial class NewShift : Form
    {
        public NewShift()
        {
            InitializeComponent();
            lblShop.Visible = false;
            PopulateShop();
        }
        public void PopulateShop()
        {
            List<StaffViewModel> staffs = new List<StaffViewModel>();
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:9000/")
            };
            var response = client.GetAsync("Manager/Staff").Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync().Result;
                staffs = JsonConvert.DeserializeObject<List<StaffViewModel>>(jsonString);
                foreach (StaffViewModel staff in staffs)
                {
                    comStaff.Items.Add(staff.username);
                }
            }
        }

        private void btnNewShift_Click(object sender, EventArgs e)
        {
            string newShiftUsername = comStaff.SelectedItem.ToString();
            DateTime newShiftDate = dtpShiftDate.Value.Date.AddHours(1);
            ShiftViewModel newShift = new ShiftViewModel();
            newShift.username = newShiftUsername;
            newShift.shiftDate = newShiftDate;
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:9000/")
            };
            var response = client.PostAsJsonAsync("Create/Shift", newShift).Result;
            if(response.IsSuccessStatusCode)
            {
                MessageBox.Show("New Shift Created.", "New Shift Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comStaff.Items.Clear();
                dtpShiftDate.Value.ToLocalTime();
            }
            else
            {
                MessageBox.Show("New Shift Creation failed. Please check your credentials and try again. Error Code: " + response.StatusCode.ToString(),
                    "New Shift Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
