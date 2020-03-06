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
    public partial class CreateAccount : Form
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.ToString();
            string lastName = txtLastName.ToString();
            string username = txtUsername.ToString();
            string password = txtPassword.ToString();
            string email = txtEmail.ToString();
            DateTime DOB = dtpDOB.Value.Date;
            string addressLineOne = txtAddressLineOne.ToString();
            string addressLineTwo = txtAddressLineTwo.ToString();
            string postcode = txtPostcode.ToString();
            string jobRole = comJobRole.SelectedItem.ToString();
            string accountNo = txtAccountNo.ToString();
            string sortCode = txtSortCode.ToString();
            int shopId = System.Convert.ToInt32(comShopId.SelectedItem.ToString());

            AccountCreation employee = new AccountCreation(firstName, lastName, password, email, DOB, addressLineOne, addressLineTwo, postcode, jobRole, sortCode,
                accountNo, shopId);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://web.socem.plymouth.ac.uk/FYP/WButler/api/");
            var response = client.PostAsJsonAsync("employee", employee).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Sign Up Succeded.", "Sign Up Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sign Up failed. Please check you credentials and try again. Error Code: " + response.StatusCode.ToString(),
                    "Sign Up Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
