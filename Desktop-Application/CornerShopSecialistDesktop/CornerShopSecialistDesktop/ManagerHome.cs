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
    public partial class ManagerHome : Form
    {
        public ManagerHome()
        {
            InitializeComponent();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:9000/")
            };
            var response = client.GetAsync("Staff/Logout").Result;
            if (response.IsSuccessStatusCode)
            {
                Home home = new Home();
                home.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Log Out Request failed. Please try again. Error Code: " + response.StatusCode.ToString(),
                    "Log Out Request Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            Stock stockPage = new Stock();
            stockPage.Show();

        }

        private void btnNewStaff_Click(object sender, EventArgs e)
        {
            CreateStaff createStaff = new CreateStaff();
            createStaff.Show();
        }
    }
}
