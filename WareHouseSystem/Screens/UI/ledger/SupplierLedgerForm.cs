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
        private bool isBill = false;
        public SupplierLedgerForm(bool isBillTrue = false)
        {
            InitializeComponent();
            LoadSupplierName();

            isBill = isBillTrue;
            textDescription.Text = isBill ? "Bill # " : "Paid";
        }

        private void LoadSupplierName()
        {
            string query = "Select Id,Name from tblStakeholders where role='Supplier'";
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
                    description = isBill ? "Bill # " : "Paid";
                }
                else
                {
                    description = textDescription.Text;
                }
                DateTime date = DateTime.Now;
                string formattedDateTime = date.ToString("yyyy-MM-dd HH:mm:ss");
                string amount = txtAmount.Text.Trim();
                string currentDate = datepicker.Value.Date.ToString("yyyy-MM-dd");

                if (!isBill)
                {
                    string query = "INSERT INTO tblUserLedger (userId, description, expense, createdAt, updatedAt, date,role) " +
             "OUTPUT INSERTED.ID " +
             "VALUES (" + SupNameBox.SelectedValue + ", '" + description + "', " + amount + ", '" + formattedDateTime + "', '" + formattedDateTime + "','" + currentDate + "','Supplier')";

                    string ledgerId = database.ScalarQuery(query);

                    //insert into cashbook

                    string cashbookQuery = "Insert into tblCashBooks(description,expense,userId, userLedgerId,date,createdAt,updatedAt) values('" + description + "'," + amount + "," + SupNameBox.SelectedValue + "," + ledgerId + ",'" + currentDate + "','" + formattedDateTime + "','" + formattedDateTime + "')";

                    database.RunQuery(cashbookQuery);
                }
                else if (isBill)
                {
                    string query = "INSERT INTO tblUserLedger (userId, description, income, createdAt, updatedAt, date,role) " +
            "OUTPUT INSERTED.ID " +
            "VALUES (" + SupNameBox.SelectedValue + ", '" + description + "', " + amount + ", '" + formattedDateTime + "', '" + formattedDateTime + "','" + currentDate + "','Supplier')";
                    database.RunQuery (query);  
                }
                txtAmount.Text = "";

                // udpate customer balance

                MessageBox.Show("Ledger Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            Cashbook cashbookForm = Application.OpenForms["Cashbook"] as Cashbook;
            if (cashbookForm != null)
            {
                cashbookForm.PopulateGrid();
            }
        }
    }
}
