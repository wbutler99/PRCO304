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
    public partial class Payroll : Form
    {
        private List<StaffViewModel> staffs = new List<StaffViewModel>();
        private StaffViewModel selectedStaff;
        public Payroll()
        {
            InitializeComponent();
            PopulateStaff();
        }

        private void comStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedStaff = new StaffViewModel();
            string username = comStaff.SelectedItem.ToString();
            selectedStaff = staffs.Find(x => x.username == username);
            lblUsername.Text = selectedStaff.username;
            lblFirstName.Text = selectedStaff.firstName;
            lblLastName.Text = selectedStaff.lastName;
            txtSortCode.Text = selectedStaff.sortCode;
            txtAccountNo.Text = selectedStaff.accountNo;
            lblUsername.Visible = true;
            lblFirstName.Visible = true;
            lblLastName.Visible = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            selectedStaff.sortCode = txtSortCode.Text;
            selectedStaff.accountNo = txtAccountNo.Text;

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:9000/")
            };
            var response = client.PostAsJsonAsync("Staff/Desktop/Update", selectedStaff).Result;
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Payroll Information Updated.",
                    "Payroll Information Updated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetData();
            }
            else
            {
                MessageBox.Show("Payroll Request failed. Please try again. Error Code: " + response.StatusCode.ToString(),
                    "Payroll Request Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void PopulateStaff()
        {
            staffs = new List<StaffViewModel>();
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

        private void ResetData()
        {
            lblUsername.Text = "username";
            lblFirstName.Text = "firstname";
            lblLastName.Text = "lastname";
            lblUsername.Visible = false;
            lblFirstName.Visible = false;
            lblLastName.Visible = false;
            txtAccountNo.Text = null;
            txtSortCode.Text = null;
        }
    }
}
