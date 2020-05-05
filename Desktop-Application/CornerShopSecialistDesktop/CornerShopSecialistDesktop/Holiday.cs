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
    public partial class Holiday : Form
    {
        public Holiday()
        {
            InitializeComponent();
            PopulateHoliday();
        }

        private void btnApproveHoliday_Click(object sender, EventArgs e)
        {
            ApproveHolidays approve = new ApproveHolidays();
            approve.Show();
        }

        private void PopulateHoliday()
        {
            List<HolidayViewModel> holidays = new List<HolidayViewModel>();

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:9000/")
            };
            var response = client.GetAsync("Shop/Holiday").Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonString = response.Content.ReadAsStringAsync().Result;
                holidays = JsonConvert.DeserializeObject<List<HolidayViewModel>>(jsonString);

                lblShop.Text = holidays[0].storeName;

                foreach (HolidayViewModel holiday in holidays)
                {
                    grdHolidays.Rows.Add(holiday.holidayReference, holiday.username, holiday.startDate.ToString(), holiday.endDate.ToString(),
                        holiday.reason, holiday.status);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            grdHolidays.Rows.Clear();
            PopulateHoliday();
        }
    }
}
