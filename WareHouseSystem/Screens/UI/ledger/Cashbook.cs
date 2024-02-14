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
    public partial class Cashbook : Form
    {
        public Cashbook()
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
            string fromDate = FromDate.Value.Date.ToString("yyyy-MM-dd");
            string toDate = ToDate.Value.Date.ToString("yyyy-MM-dd");

            string query = @"
    SELECT ul.date, sh.name, ul.description, ul.income, ul.expense
    FROM tblCashbooks ul
    LEFT JOIN tblStakeHolders sh ON ul.userId = sh.ID
    WHERE ul.date >= '"+fromDate+ "' AND ul.date <=  '"+toDate+"'";

            database.PopulatGrid(query, GDVCashbook);

            string query1 = "SELECT SUM(income) as allincome, SUM(expense) as allexpense, SUM(income) -sum(expense) AS balance FROM tblCashbooks";


            Dictionary<string, object> result = database.GetAggregatedValues(query1);

            // Access the values using the keys
            decimal income = (decimal)result["allincome"];
            decimal expense = (decimal)result["allexpense"];
            decimal balance = (decimal)result["balance"];

            labelBalance.Text = "Rs"+database.FormatAmount(balance);
            labelIncome.Text = "Rs" + database.FormatAmount(income);
            labelExpense.Text = "Rs" + database.FormatAmount(expense);
        }

        private void UserRecords_Enter(object sender, EventArgs e)
        {

        }

        private void btnExpenseForm_Click(object sender, EventArgs e)
        {
            Expenses expensesForm = new Expenses();
            expensesForm.FormClosed += ExpensesForm_FormClosed;
            expensesForm.ShowDialog();

        }
        private void ExpensesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            PopulateGrid();
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

        private void button1_Click(object sender, EventArgs e)
        {
            EmployerLedgerForm employeeLedgerForm = new EmployerLedgerForm();
            employeeLedgerForm.FormClosed += EmployerLedgerForm_FormClosed;
            employeeLedgerForm.ShowDialog();

        }
        private void EmployerLedgerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            PopulateGrid();
        }

        private void FromDate_ValueChanged(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void ToDate_ValueChanged(object sender, EventArgs e)
        {
            PopulateGrid();
        }
    }
}
