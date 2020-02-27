using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            //TODO: Dispose of data when logging out & clear all other pages that may be open
            Home home = new Home();
            home.Show();
            this.Hide();
        }
    }
}
