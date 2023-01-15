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
    public partial class AddExpense : MetroTemplate
    {
        public AddExpense()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (RequiredFields())
            {
                string query = "insert into tblDailySheet(Title,Expense,date) Values('"+txtTitle.Text+"',"+txtAmount.Text.Trim()+",GetDate())";
                database.RunQuery(query);
                MessageBox.Show("Expense Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool RequiredFields()
        {
            if (txtTitle.Text == string.Empty)
            {
                MessageBox.Show("Title is Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTitle.Focus();
                return false;
            }
            if (txtAmount.Text == string.Empty)
            {
                MessageBox.Show("Amount is Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAmount.Focus();
                return false;
            }
            return true;
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            database.DigitValidation(sender, e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        private void ResetFields()
        {
            txtAmount.Text = string.Empty;
            txtTitle.Text = string.Empty;
        }
    }
}
