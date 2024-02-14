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
    public partial class Expenses : MetroTemplate
    {
        public Expenses()
        {
            InitializeComponent();
            CustomizeSetting();
        }

        private void CustomizeSetting()
        {
            listType.SelectedIndex = 0;
            int currentMonth = DateTime.Today.Month;
            listBill.SelectedIndex = 0;
            listMonths.SelectedIndex = currentMonth-1;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (RequiredFields())
            {
                string description = getDescription();
                string amount = txtAmount.Text.Trim();
                DateTime date = DateTime.Now;
                string formattedDateTime = date.ToString("yyyy-MM-dd HH:mm:ss");
                string currentDate = datepicker.Value.Date.ToString("yyyy-MM-dd");
                string query = "INSERT INTO tblCashbooks (description, expense, date,createdAt, updatedAt)  VALUES('"+description+"',"+amount+",'"+currentDate+ "','"+ formattedDateTime + "','"+ formattedDateTime + "')";
                database.RunQuery(query);
                txtAmount.Text = "";
                MessageBox.Show("Expense added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private string getDescription()
        {
            string descriptionText = txtDescription.Text.Trim();

            string description = listType.Text;

            if (listType.SelectedIndex == 0)
            {
                return description + "_" + descriptionText;
            }
            else if (listType.SelectedIndex == 1)
                {
                   return description + "_" + listBill.Text + "_" + listMonths.Text;
                }
            else if (listType.SelectedIndex == 2)
            {
                return description  + "_" + listMonths.Text;
            }
            return description;

        }

        private bool RequiredFields()
        {
            if(txtAmount.Text.Trim().Length <= 0)
            {
                txtAmount.Focus();
                return false;
            }
            return true;
        }

        private void listType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listType.SelectedIndex == 0)
            {
                panelBill.Visible = false;
                panelDescription.Visible = true;
                panelMonth.Visible = false;
            }
            if (listType.SelectedIndex == 1)
            {
                panelBill.Visible = true;
                panelDescription.Visible = false ;
                panelMonth.Visible = true;
            }if(listType.SelectedIndex == 2)
            {
                panelBill.Visible = false;
                panelDescription.Visible = false ;
                panelMonth.Visible = true;
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            database.DigitValidation(sender, e);
        }

        private void Expenses_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cashbook cashbookForm = Application.OpenForms["Cashbook"] as Cashbook;
            if (cashbookForm != null)
            {
                cashbookForm.PopulateGrid();
            }
        }
    }
}
