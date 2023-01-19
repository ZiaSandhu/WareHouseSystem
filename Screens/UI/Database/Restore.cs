using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WareHouseSystem.General;

namespace WareHouseSystem.Screens.UI.Database
{
    public partial class Restore : MetroTemplate
    {
        public Restore()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = ofd.FileName;
                btnSave.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string query = "use master; ALTER DATABASE WarHouseSystem SET Single_User WITH ROLLBACK IMMEDIATE ";
            query += "RESTORE DATABASE WarHouseSystem FROM DISK = '" + txtPath.Text + "' WITH REPLACE;";
            database.RunQuery (query);
            MessageBox.Show("Successfully RESTORED DataBase", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
