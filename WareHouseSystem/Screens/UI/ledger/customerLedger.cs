using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WareHouseSystem.General;

namespace WareHouseSystem.Screens.UI.ledger
{
    public partial class customerLedger : Form
    {
        public customerLedger()
        {
            InitializeComponent();
            LoadCustomerName();
            PopulateGrid();
            CustomSetting();
        }
        private void CustomSetting()
        {
            database.SetDateTimePickerToFirstDayOfMonth(FromDate);
        }
        private void PopulateGrid()
        {
            string query = "select * from tblCustomersLedger";
            database.PopulatGrid(query, GDVCusLedger);
            //decimal balance = database.CalculateColumnSum(GDVCusLedger, "amount");

            //labelBalance.Text = "Rs." + database.FormatAmount(balance);
        }

      

     
        private void LoadCustomerName()
        {
            string query = "Select Id,Name from tblCustomers";
            database.LoadComboBox(query, CusNameBox);
            database.LoadComboBox(query, FilterNameBox);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (fieldsRequired())
            {
                insertData();
            }
        }

        private void insertData()
        {
            
            
            insertIntoCustomerLedger();
            //insertIntoDailySheet();
        }

        private void insertIntoDailySheet()
        {
            throw new NotImplementedException();
        }

        private void insertIntoCustomerLedger()
        {
            string description;

            if (txtDescription.Text.Trim().Length <= 0)
            {
                description = "Recieved";
            }
            else
            {
                description = txtDescription.Text;
            }
            DateTime date = DateTime.Now;
            string formattedDateTime = date.ToString("yyyy-MM-dd HH:mm:ss");
            string query = "INSERT INTO tblCustomersLedger (customerId, description, amount, createdAt, updatedAt,date) VALUES (" + CusNameBox.SelectedValue + ", '" + description + "', " + txtAmount.Text.Trim() + ", '" + formattedDateTime + "', '" + formattedDateTime + "','"+dateLedger.Value.Date.ToString("yyyy-MM-dd")+"')";

            database.RunQuery(query);

            //MessageBox.Show(query, "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool fieldsRequired()
        {
           if(txtAmount.Text.Trim().Length <= 0)
            {
                MessageBox.Show("Enter Amount!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtAmount.Focus();
                return false;
            }
           
            return true;
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            database.DigitValidation(sender,e);
        }
    }
}
