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
    public partial class SupplierLedgerForm : MetroTemplate
    {
        public SupplierLedgerForm()
        {
            InitializeComponent();
            LoadSupplierName();

        }

        private void LoadSupplierName()
        {
            string query = "Select Id,Name from tblSuppliers";
            database.LoadComboBox(query, SupNameBox);
        }

        private void txtBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            database.DigitValidation(sender,e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (RequiredFields())
            {

                //insert into customer ledger
                string description;

                if (textDescription.Text.Trim().Length <= 0)
                {
                    description = "Recieved";
                }
                else
                {
                    description = textDescription.Text;
                }
                DateTime date = DateTime.Now;
                string formattedDateTime = date.ToString("yyyy-MM-dd HH:mm:ss");
                string amount = txtAmount.Text.Trim();
                string currentDate = datepicker.Value.Date.ToString("yyyy-MM-dd");
                string query = "INSERT INTO tblSuppliersLedger (supplierId, description, amount, createdAt, updatedAt, date) " +
               "OUTPUT INSERTED.ID " +
               "VALUES (" + SupNameBox.SelectedValue + ", '" + description + "', " + amount + ", '" + formattedDateTime + "', '" + formattedDateTime + "','" + currentDate + "')";

                string ledgerId = database.ScalarQuery(query);

                //insert into cashbook

                string cashbookQuery = "Insert into tblCashBooks(description,expense,userId, userLedgerId,date,createdAt,updatedAt) values('" + description + "'," + amount + "," + SupNameBox.SelectedValue + "," + ledgerId + ",'" + currentDate + "','" + formattedDateTime + "','" + formattedDateTime + "')";

                database.RunQuery(cashbookQuery);

            }
        }
        private bool RequiredFields()
        {
            if (txtAmount.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Enter Amount!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtAmount.Focus();
                return false;
            }

            return true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SupplierLedgerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DailySheet cashbookForm = Application.OpenForms["Cashbook"] as DailySheet;
            if (cashbookForm != null)
            {
                cashbookForm.PopulateGrid();
            }
        }
    }
}
