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
    public partial class ApproveHolidays : Form
    {
        private List<HolidayViewModel> holidays = new List<HolidayViewModel>();
        private HolidayViewModel selectedHoliday;
        public ApproveHolidays()
        {
            InitializeComponent();
            PopulateHolidays();
        }

        private void comHolidays_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedHoliday = new HolidayViewModel();
            string reference = comHolidays.SelectedItem.ToString();
            selectedHoliday = holidays.Find(x => x.holidayReference == reference);
            lblUsername.Text = selectedHoliday.username;
            lblStartDate.Text = selectedHoliday.startDate.ToShortDateString();
            lblEndDate.Text = selectedHoliday.endDate.ToShortDateString();
            lblReason.Text = selectedHoliday.reason;
            lblStatus.Text = selectedHoliday.status;
            lblUsername.Visible = true;
            lblStartDate.Visible = true;
            lblEndDate.Visible = true;
            lblReason.Visible = true;
            lblStatus.Visible = true;
            btnApprove.Visible = true;
            btnDeny.Visible = true;
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            selectedHoliday.status = "Approved";
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:9000/")
            };
            var response = client.PostAsJsonAsync("Update/Holiday", selectedHoliday).Result;
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Holiday Approved.",
                    "Holiday Approved", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetData();
            }
            else
            {
                MessageBox.Show("Holiday Request failed. Please try again. Error Code: " + response.StatusCode.ToString(),
                    "Holiday Request Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnDeny_Click(object sender, EventArgs e)
        {
            selectedHoliday.status = "Denied";
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:9000/")
            };
            var response = client.PostAsJsonAsync("Update/Holiday", selectedHoliday).Result;
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Holiday Denied.",
                    "Holiday Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetData();
            }
            else
            {
                MessageBox.Show("Holiday Request failed. Please try again. Error Code: " + response.StatusCode.ToString(),
                    "Holiday Request Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void PopulateHolidays()
        {
            holidays = new List<HolidayViewModel>();
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:9000/")
            };
            var response = client.GetAsync("Shop/Holiday/Approve").Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync().Result;
                holidays = JsonConvert.DeserializeObject<List<HolidayViewModel>>(jsonString);

                foreach (HolidayViewModel holiday in holidays)
                {
                    comHolidays.Items.Add(holiday.holidayReference);
                }
            }
        }

        private void ResetData()
        {
            lblUsername.Text = "username";
            lblUsername.Visible = false;
            lblStartDate.Text = "startDate";
            lblStartDate.Visible = false;
            lblEndDate.Text = "endDate";
            lblEndDate.Visible = false;
            lblReason.Text = "reason";
            lblReason.Visible = false;
            lblStatus.Text = "status";
            lblStatus.Visible = false;
            comHolidays.Items.Clear();
            PopulateHolidays();
        }
    }
}
