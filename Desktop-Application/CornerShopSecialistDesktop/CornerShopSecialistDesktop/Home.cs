using CornerShopSecialistDesktop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CornerShopSecialistDesktop;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net;

namespace CornerShopSecialistDesktop
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            CreateAccount createAccount = new CreateAccount();
            createAccount.Show();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            var employee = new EmployeeViewModel();
            string username = txtUsernameInput.Text;
            string password = txtPasswordInput.Text;

            LogIn logInDetails = new LogIn(username, password);

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:9000/")
            };
            var response = client.PostAsJsonAsync("Staff/Login", logInDetails).Result;

            if(response.IsSuccessStatusCode)
            {
                var JsonString = response.Content.ReadAsStringAsync().Result;
                employee = JsonConvert.DeserializeObject<EmployeeViewModel>(JsonString);
                if(employee.jobRole == "Admin")
                {
                    AdminHome home = new AdminHome();
                    home.Show();
                }
                else if(employee.jobRole == "Manager")
                {
                    ManagerHome home = new ManagerHome();
                    home.Show();
                }
                txtUsernameInput.Clear();
                txtPasswordInput.Clear();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Log In failed. Please check you credentials and try again.", "Log In Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
