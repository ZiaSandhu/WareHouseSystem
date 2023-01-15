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
    public partial class SupplierLedger : MetroTemplate
    {
        private string UpdateId;
        public SupplierLedger()
        {
            InitializeComponent();
        }

        private void SupplierLedger_Load(object sender, EventArgs e)
        {
            PopulateGrid();
            LoadComboBox();
            ResetFields();
        }

        private void LoadComboBox()
        {
            string query = "Select Id,Name from tblSuppliers";
            database.LoadComboBox(query,CusNameBox);
            database.LoadComboBox(query, FilterNameBox);
        }

        private void PopulateGrid(string q="")
        {
            string query = "Select tsl.Id,ts.Name,tsl.Title,tsl.SupplierId,tsl.InvoiceDue,tsl.AmountPaid,tsl.Date from (tblSupplierLedger tsl " +
                "INNER JOIN tblSuppliers ts ON tsl.SupplierId = ts.Id) " + q;
            database.PopulatGrid(query, GDVCusLedger);
            if (GDVCusLedger.Rows.Count > 0)
            {
                GDVCusLedger.Columns["Id"].Visible = false;
                GDVCusLedger.Columns["SupplierId"].Visible = false; 
            }

            CalculateSummary();
        }

        private void CalculateSummary()
        {
            decimal InvoiceDue = 0;
            decimal AmountPaid = 0;
            foreach(DataGridViewRow row in GDVCusLedger.Rows)
            {
                InvoiceDue += Convert.ToDecimal(row.Cells["InvoiceDue"].Value);
                AmountPaid += Convert.ToDecimal(row.Cells["AmountPaid"].Value);
            }
            lblDebit.Text = InvoiceDue.ToString();
            lblCredit.Text = AmountPaid.ToString();
            lblBalance.Text=(InvoiceDue-AmountPaid).ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (CBdate.Checked && CBName.Checked)//both check boxes are checked
            {
                //filter by date and name
                FilterByNameDate();
            }
            else if (!CBdate.Checked && CBName.Checked)//Name checkbox is checked
            {
                //FilterName by name without date
                FilterByNameWithoutDate();
            }
            else if (CBdate.Checked & !CBName.Checked)//date check box is checked
            {
                //filter by date
                FilterByDate();
            }
            else
                MessageBox.Show("NO Selection", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FilterByDate()
        {
            DateTime selectedDate = FromDate.Value; //get the selected date from the date picker
            string dateString = selectedDate.ToString("yyyy-MM-dd");
            DateTime selectedDate1 = ToDate.Value; //get the selected date from the date picker
            string dateString1 = selectedDate.ToString("yyyy-MM-dd");
            string query = "where Date>='" + dateString + "' and Date<= '" + dateString1 +"'";
            PopulateGrid(query);
        }

        private void FilterByNameWithoutDate()
        {
            string query = "where tsl.SupplierId = "+FilterNameBox.SelectedValue;
            PopulateGrid(query);
        }

        private void FilterByNameDate()
        {
            DateTime selectedDate = FromDate.Value; //get the selected date from the date picker
            string dateString = selectedDate.ToString("yyyy-MM-dd");
            DateTime selectedDate1 = ToDate.Value; //get the selected date from the date picker
            string dateString1 = selectedDate.ToString("yyyy-MM-dd");
            string query = "where Date>='" + dateString + "' and Date<= '" + dateString1 + "' and tsl.SupplierId = "+FilterNameBox.SelectedValue;
            PopulateGrid(query);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void GDVCusLedger_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you Sure! \n This can't be rollback.", "Confirm to Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void GDVCusLedger_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            string query = "Delete from tblSupplierLedger where Id=" + GDVCusLedger.SelectedRows[0].Cells["Id"].Value.ToString();
            database.RunQuery(query);
            string query1 = "Delete from tblDailySheet where RefId='SL" + UpdateId + "'";
            database.RunQuery(query1);

        }

        private void GDVCusLedger_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!GDVCusLedger.SelectedRows[0].Cells["Title"].Value.ToString().Contains('#'))
            {
                CusNameBox.SelectedValue = GDVCusLedger.SelectedRows[0].Cells["SupplierId"].Value;
                txtTitle.Text = GDVCusLedger.SelectedRows[0].Cells["Title"].Value.ToString();
                txtDebit.Text = GDVCusLedger.SelectedRows[0].Cells["AmountPaid"].Value.ToString();
                UpdateId= GDVCusLedger.SelectedRows[0].Cells["Id"].Value.ToString();
            }
        }

        private void UpdateRecord()
        {
            UpdateId = GDVCusLedger.SelectedRows[0].Cells["Id"].Value.ToString();
            string query = "Update tblSupplierLedger set SupplierId=" + CusNameBox.SelectedValue + ",Title='" + txtTitle.Text + "',AmountPaid=" + txtDebit.Text + ",UpdateDate=GetDate() where Id=" + UpdateId;
            database.RunQuery(query);
            MessageBox.Show("Record Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InsertNewRecord()
        {
            DateTime selectedDate = datepicker.Value; //get the selected date from the date picker
            string dateString = selectedDate.ToString("yyyy-MM-dd");
            string query = "Insert Into tblSupplierLedger(SupplierId,Title,AmountPaid,Date) Values("+CusNameBox.SelectedValue+", '"+txtTitle.Text+"',"+txtDebit.Text.Trim()+",'"+dateString+"')";
            database.RunQuery(query);
            MessageBox.Show("Record Inserted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (RequiredFields())
            {
                if (UpdateId == string.Empty)
                {
                    InsertNewRecord();
                    InsertDailySheet();
                }
                else
                {
                    UpdateRecord();
                    UpdateDailySheet();
                }
                ResetFields(); 
                PopulateGrid();
            }
        }

        private void UpdateDailySheet()
        {
            string query = "Update tblDailySheet set Name='" + CusNameBox.Text + "',Title='" + txtTitle.Text.Trim() + "', Expense="+txtDebit.Text.Trim()+" where RefId='SL"+UpdateId+"'";
            database.RunQuery(query);
        }

        private void InsertDailySheet()
        {
            string query="Select max(Id) from tblSupplierLedger";
            string RefId = database.ScalarQuery(query);
            RefId = "SL" + RefId;
            DateTime date = datepicker.Value;
            string dateString = date.ToString("yyyy-MM-dd");
            string query1 = "Insert Into tblDailySheet(Name,Title,Expense,Date,RefId) Values('"+CusNameBox.Text+"','"+txtTitle.Text.Trim()+"',"+txtDebit.Text.Trim()+", '"+dateString+"','"+RefId+"')";
            database.RunQuery(query1);
        }

        private bool RequiredFields()
        {
            if (txtTitle.Text == string.Empty)
            {
                MessageBox.Show("Enter Title", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTitle.Focus();
                return false;
            }
            if (txtDebit.Text == string.Empty)
            {
                MessageBox.Show("Enter Amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDebit.Focus();
                return false;
            }
            return true;
        }

        private void ResetFields()
        {
            UpdateId = string.Empty;
            txtTitle.Text = string.Empty;
            txtDebit.Text = string.Empty;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        private void txtDebit_KeyPress(object sender, KeyPressEventArgs e)
        {
            database.DigitValidWithoutDecimal(e);
        }

        private void txtTitle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '#')
            {
                e.Handled = true;
            }
        }
    }

}
