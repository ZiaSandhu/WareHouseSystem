using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WareHouseSystem.General;

namespace WareHouseSystem.Screens.UI.Database
{
    public partial class Backup : MetroTemplate
    {
        public Backup()
        {
            InitializeComponent();
        }

        private void Backup_Load(object sender, EventArgs e)
        {

        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog.SelectedPath;
                btnSave.Enabled = true;
                string fileName = "backup.txt";
                string currentDirectory = Directory.GetCurrentDirectory();
                string filePath = Path.Combine(currentDirectory, fileName);

                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine(txtPath.Text);
                }

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BackupDatabase();
        }

        public void BackupDatabase()
        {
            MessageBox.Show(txtPath.Text);
            string query = "BACKUP DATABASE WarHouseSystem TO DISK='" + txtPath.Text + "\\Buisness_Solution " + DateTime.Now.ToString("yyyy-MM-dd:HH-mm-ss") + ".bak'";
            database.RunQuery(query);
            MessageBox.Show("Backuped Successfully");
        }
    }
}
