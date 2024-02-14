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

namespace WareHouseSystem.Screens.UI
{
    public partial class Stats : Form
    {
        public Stats()
        {
            InitializeComponent();
            LoadStats();
        }

        private void LoadStats()
        {
            Dictionary<string, int> roleCounts = database.GetRoleCounts();

            int customerCount = 0;
            int supplierCount = 0;
            int employeeCount = 0;

            foreach (var kvp in roleCounts)
            {
                string role = kvp.Key;
                int count = kvp.Value;

                if (role == "Customer")
                    customerCount = count;
                else if (role == "Supplier")
                    supplierCount = count;
                else if (role == "Employee")
                    employeeCount = count;
            }

            labelCustomer.Text = customerCount.ToString();
            labelSupplier.Text = supplierCount.ToString();
            labelEmployee.Text = employeeCount.ToString();



            string query = "select sum(expense)-sum(income) as income from tblUserLedger where role='customer'";
            string income = database.ScalarQuery(query);

            query = "select sum(income)-sum(expense) as expense from tblUserLedger where role='supplier'";
            string expense = database.ScalarQuery(query);

            query = "select sum(income)-sum(expense) as balance from tblCashbooks";
            string balance = database.ScalarQuery(query);


            labelBalance.Text = balance;
            labelIncome.Text = income;
            labelExpense.Text = expense;
        }
    }
}
