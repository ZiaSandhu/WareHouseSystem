using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WareHouseSystem.Screens.UI.ledger
{
    public partial class DailySheet : Form
    {
        public DailySheet()
        {
            InitializeComponent();
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
            new CustomerLedgerForm().ShowDialog();
        }

        private void btnSupplierLedgerForm_Click(object sender, EventArgs e)
        {
            new SupplierLedgerForm().ShowDialog();
        }
    }
}
