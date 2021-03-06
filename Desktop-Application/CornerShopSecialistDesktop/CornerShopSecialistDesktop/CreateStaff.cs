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
    public partial class CreateStaff : Form
    {

        public CreateStaff()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string email = txtEmail.Text;
            DateTime DOB = dtpDOB.Value.Date.AddHours(1);
            string addressLineOne = txtAddressLineOne.Text;
            string addressLineTwo = txtAddressLineTwo.Text;
            string postcode = txtPostcode.Text;
            string jobRole = "Staff";
            string accountNo = txtAccountNo.Text;
            string sortCode = txtSortCode.Text;

            StaffViewModel employee = new StaffViewModel(username, firstName, lastName, password, email, DOB, addressLineOne, addressLineTwo, postcode, jobRole, sortCode,
            accountNo);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9000/");
            var response = client.PostAsJsonAsync("Manager/Staff/Signup", employee).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Sign Up Succeded.", "Sign Up Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFirstName.Clear();
                txtLastName.Clear();
                txtUsername.Clear();
                txtPassword.Clear();
                txtEmail.Clear();
                dtpDOB.ResetText();
                txtAddressLineOne.Clear();
                txtAddressLineTwo.Clear();
                txtPostcode.Clear();
                txtAccountNo.Clear();
                txtSortCode.Clear();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sign Up failed. Please check you credentials and try again. Error Code: " + response.StatusCode.ToString(),
                    "Sign Up Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}
