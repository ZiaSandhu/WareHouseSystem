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

namespace WareHouseSystem.Screens.UI.ledger
{
    public partial class EmployeeLedger : Form
    {
        public EmployeeLedger()
        {
            InitializeComponent();
            LoadComboBox();
            PopulateGrid();
            customSetting();
        }
        private bool isFirstSelection = true;

        private void customSetting()
        {
            btnReport.Visible = false;
        }
        private void PopulateGrid()
        {
            int userId = (int)FilterNameBox.SelectedValue;

            database.LedgerGridPopulate(GDVCusLedger, userId);

           

        }

        private void LoadComboBox()
        {
            string query = "Select Id,Name from tblStakeholders where role='Employee'";
            database.LoadComboBox(query, FilterNameBox);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            PopulateGrid();
        }

        private void ToDate_ValueChanged(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void FilterNameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!isFirstSelection)
            {
                PopulateGrid();
            }
        }
    }
}
