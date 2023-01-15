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

namespace WareHouseSystem.Screens.UI.Ledger
{
    public partial class DailySheet : MetroTemplate
    {
        public DailySheet()
        {
            InitializeComponent();
        }

        private void DailySheet_Load(object sender, EventArgs e)
        {
            PopulateDailySheet();
        }

        private void PopulateDailySheet(string q="")
        {
            string query = "Select Name,Title,Income,Expense,Date from tblDailySheet "+q;
            database.PopulatGrid(query, GDVInvoice);
            CalculateSummary();
        }

        private void CalculateSummary()
        {
            decimal Income = 0;
            decimal Expense = 0;
            foreach(DataGridViewRow row in GDVInvoice.Rows)
            {
                Income += Convert.ToDecimal(row.Cells["Income"].Value);
                Expense += Convert.ToDecimal(row.Cells["Expense"].Value);
            }
            lblBalance.Text = (Income - Expense).ToString();
            lblIncome.Text = Income.ToString();
            lblExpense.Text = Expense.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FilterByDate();
        }

        private void FilterByDate()
        {
            DateTime selectedDate = FromDate.Value; //get the selected date from the date picker
            string dateString = selectedDate.ToString("yyyy-MM-dd");
            DateTime selectedDate1 = ToDate.Value; //get the selected date from the date picker
            string dateString1 = selectedDate.ToString("yyyy-MM-dd");
            string query = "where Date>='"+dateString+"' and Date<='"+dateString1+"'";
            PopulateDailySheet(query);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateDailySheet();
        }
    }
}
