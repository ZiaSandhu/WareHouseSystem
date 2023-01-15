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
using WareHouseSystem.Screens.UI.Database;
using WareHouseSystem.Screens.UI.Employees;
using WareHouseSystem.Screens.UI.Invoices;
using WareHouseSystem.Screens.UI.Ledger;
using WareHouseSystem.Screens.UI.Manage;
using WareHouseSystem.Screens.UI.View;

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
            database.BackupDatabase();
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

        private void btnPurchaseInvoice_Click(object sender, EventArgs e)
        {
            new Purchase().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Sale().ShowDialog();
        }

        private void purchaseInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void manageItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Items().ShowDialog();
        }

        private void customerLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CustomerLedger().ShowDialog();
        }

        private void supplierLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SupplierLedger().ShowDialog();
        }

        private void cashBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new DailySheet().ShowDialog();
        }

        private void manageSaleInvoicesRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {

            new ViewSale().ShowDialog();
        }

        private void managePurchaseRecordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new ViewPurchase().ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            new AddExpense().ShowDialog();
        }

        private void Dashboard_MouseEnter(object sender, EventArgs e)
        {
            QuickInfo();
        }

        private void QuickInfo()
        {
            string query = "select sum(Income) from tblDailySheet where Date=Convert(date,GetDATE())";
            string Income=database.ScalarQuery(query);
            if (Income != "")
                lblIncome.Text = Income;
            else
                Income = "0";
            query = "select sum(Expense) from tblDailySheet where Date=Convert(date,GetDATE())";
            string Expense=database.ScalarQuery(query);
            if (Expense != "")
                lblExpense.Text = Expense;
            else
                Expense = "0";
            lblBalance.Text = (Convert.ToDecimal(Income) - Convert.ToDecimal(Expense)).ToString();
        }

        private void backupDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Backup().ShowDialog();
        }

        private void manageEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddEmployees().ShowDialog();
        }

        private void salaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new EmployeeLedger().ShowDialog();
        }
    }
}
