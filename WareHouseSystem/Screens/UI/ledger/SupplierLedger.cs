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
    public partial class SupplierLedger : Form
    {
        public SupplierLedger()
        {
            InitializeComponent();
            LoadComboBox();
            CustomSetting();
            PopulateGrid();
        }

        private bool isFirstSelection = true;

        private void CustomSetting()
        {
            database.SetDateTimePickerToFirstDayOfMonth(FromDate);
        }
        private void PopulateGrid()
        {
            int userId = (int)FilterNameBox.SelectedValue;
            string fromDate = FromDate.Value.Date.ToString("yyyy-MM-dd");
            string toDate = ToDate.Value.Date.ToString("yyyy-MM-dd");

            database.LedgerGridPopulate(GDVCusLedger, userId, fromDate, toDate);
            decimal income = database.CalculateColumnSum(GDVCusLedger, "income");
            decimal expense = database.CalculateColumnSum(GDVCusLedger, "expense");
            decimal balance =  income - expense ;

            labelBalance.Text = "Rs." + database.FormatAmount(balance);
            labelIncome.Text = "Rs." + database.FormatAmount(income);
            labelExpense.Text = "Rs." + database.FormatAmount(expense);
        }

        private void LoadComboBox()
        {
            string query = "Select Id,Name from tblStakeholders where role='Supplier'";
            database.LoadComboBox(query, FilterNameBox);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
          this.Close();
        }

        private void FromDate_ValueChanged(object sender, EventArgs e)
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
