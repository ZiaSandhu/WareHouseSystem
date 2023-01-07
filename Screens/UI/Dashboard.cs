using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WareHouseSystem.Screens.UI.Manage;

namespace WareHouseSystem.Screens.UI
{
    public partial class Dashboard : MetroTemplate
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        async void RunTime()
        {
            while (true)
            {
                lblTime.Text = DateTime.Now.ToString("T");
                await Task.Delay(1000);
            }
        }
        public void SettingLabel(string name)
        {

            lblUser.Text = "Welcome " + name + "";
            lblDate.Text = System.DateTime.Now.ToString("D");
            RunTime();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Users().ShowDialog();
        }

        private void manageSuppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Suppliers().ShowDialog();
        }

        private void manageCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Customers().ShowDialog();
        }

        private void manageProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Products().ShowDialog();
        }
    }
}
