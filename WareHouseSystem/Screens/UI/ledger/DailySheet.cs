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
    public partial class DailySheet : Form
    {
        public DailySheet()
        {
            InitializeComponent();
            PopulateGrid();
            CustomSetting();
        }

        private void CustomSetting()
        {
            database.SetDateTimePickerToFirstDayOfMonth(FromDate);
        }

        public void PopulateGrid()
        {
            string query = "select * from tblCashbooks";
            database.PopulatGrid(query, GDVCashbook);
            decimal income = database.CalculateColumnSum(GDVCashbook,"income");
            decimal expense = database.CalculateColumnSum(GDVCashbook, "expense");
            decimal balance = income-expense;

            labelBalance.Text = "Rs."+database.FormatAmount(balance);
            labelIncome.Text = "Rs." + database.FormatAmount(income);
            labelExpense.Text = "Rs." + database.FormatAmount(expense);
        }

        private void UserRecords_Enter(object sender, EventArgs e)
        {

        }

        private void btnExpenseForm_Click(object sender, EventArgs e)
        {
            new Expenses().ShowDialog();
        }

        private void btnCustomerLedgerForm_Click(object sender, EventArgs e)
        {
            CustomerLedgerForm customerLedgerForm = new CustomerLedgerForm();
            customerLedgerForm.FormClosed += CustomerLedgerForm_FormClosed;
            customerLedgerForm.ShowDialog();
        }

        private void CustomerLedgerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            PopulateGrid();
        }
        private void btnSupplierLedgerForm_Click(object sender, EventArgs e)
        {
            SupplierLedgerForm supplierLedgerForm = new SupplierLedgerForm();
            supplierLedgerForm.FormClosed += SupplierLedgerForm_FormClosed;
            supplierLedgerForm.ShowDialog();
        }
        private void SupplierLedgerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            PopulateGrid();
        }


    }
}
