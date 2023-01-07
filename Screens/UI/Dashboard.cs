using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
