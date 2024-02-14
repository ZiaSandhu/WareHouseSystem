using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WareHouseSystem.General;
using WareHouseSystem.Screens.UI.Manage;

namespace WareHouseSystem.Screens.UI.ledger
{
    public partial class customerLedger : Form
    {

        public customerLedger()
        {
            InitializeComponent();
            LoadCustomerName();
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

            database.LedgerGridPopulate(GDVCusLedger, userId,true);
            decimal income = database.CalculateColumnSum(GDVCusLedger, "income");
            decimal expense = database.CalculateColumnSum(GDVCusLedger, "expense");
            decimal balance =  expense - income;

            labelBalance.Text = "Rs." + database.FormatAmount(balance);
            labelIncome.Text = "Rs." + database.FormatAmount(income);
            labelExpense.Text = "Rs." + database.FormatAmount(expense);
        }
     
        private void LoadCustomerName()
        {
            string query = "Select Id,Name from tblStakeholders where role='Customer'";
            database.LoadComboBox(query, FilterNameBox);

            isFirstSelection = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FilterNameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!isFirstSelection)
                PopulateGrid();
        }

        private void btnBillPayment_Click(object sender, EventArgs e)
        {
            CustomerLedgerForm customerLedgerForm = new CustomerLedgerForm(true);
            customerLedgerForm.FormClosed += CustomerLedgerForm_FormClosed;
            customerLedgerForm.ShowDialog();
        }

       
        private void CustomerLedgerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            PopulateGrid();
        }
    }
}
