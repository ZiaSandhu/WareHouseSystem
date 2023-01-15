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

namespace WareHouseSystem.Screens.UI.Employees
{
    public partial class EmployeeLedger : MetroTemplate
    {
        private string UpdateId;

        public EmployeeLedger()
        {
            InitializeComponent();
        }

        private void EmployeeLedger_Load(object sender, EventArgs e)
        {
            PopulateGrid();
            LoadComboBox();
            ResetFields();
        }
        private void ResetFields()
        {
            UpdateId = string.Empty;
            txtDebit.Text = string.Empty;
        }

        private void LoadComboBox()
        {
            string query = "Select Id,Name from tblEmployees";
            database.LoadComboBox(query, CusNameBox);
            database.LoadComboBox(query, FilterNameBox);
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

        private void PopulateGrid(string q="")
        {
            string query = "Select tsl.Id,ts.Name,Concat(tsl.Title,'-',tsl.Month) as Detail,tsl.Salaray,tsl.Date from (tblEmployeeSalary tsl " +
                "INNER JOIN tblEmployees ts ON tsl.EmployeeId = ts.Id) " + q;
            database.PopulatGrid(query, GDVCusLedger);
            if (GDVCusLedger.Rows.Count > 0)
            {
                GDVCusLedger.Columns["Id"].Visible = false;
            }
        }

        private void UpdateDailySheet()
        {
            string query = "Update tblDailySheet set Name='"+CusNameBox.SelectedText+"',Title='"+CBMonth.SelectedText+"-"+CBTitle.SelectedText+"',Expense="+txtDebit.Text+" where RefId='EL"+UpdateId+"'";
            database.RunQuery(query);
        }

        private void UpdateRecord()
        {
            string query = "Update tblEmployeeSalary set Month='"+CBMonth.SelectedText+"',Title='"+CBTitle.SelectedText+"',Salary="+txtDebit.Text+" where Id="+UpdateId;
            database.RunQuery(query);
        }

        private void InsertDailySheet()
        {
            string query = "Select max(Id) from tblEmployeeSalary";
            string RefId = database.ScalarQuery(query);
            RefId = "EL" + RefId;
            DateTime date = datepicker.Value;
            string dateString = date.ToString("yyyy-MM-dd");
            string query1 = "Insert Into tblDailySheet(Name,Title,Expense,Date,RefId) Values('" + CusNameBox.Text + "','" + CBMonth.SelectedText + "_"+CBTitle.SelectedText+"'," + txtDebit.Text.Trim() + ", '" + dateString + "','" + RefId + "')";
            database.RunQuery(query1);
        }

        private void InsertNewRecord()
        {
            DateTime selectedDate = datepicker.Value; //get the selected date from the date picker
            string dateString = selectedDate.ToString("yyyy-MM-dd");
            string query = "Insert into tblEmployeeSalary Values('"+CusNameBox.SelectedValue+"','"+CBMonth.SelectedText+"','"+CBTitle.SelectedText+"',"+txtDebit.Text+",'"+dateString+"')";
            database.RunQuery(query);
        }

        private bool RequiredFields()
        {
            if(txtDebit.Text == string.Empty)
            {
                MessageBox.Show("Enter Amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDebit.Focus();
                return false;
            }
            return true;
        }

        private void GDVCusLedger_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
                CusNameBox.SelectedValue = GDVCusLedger.SelectedRows[0].Cells["EmployeeId"].Value;
                CBTitle.SelectedText = GDVCusLedger.SelectedRows[0].Cells["Title"].Value.ToString();
                CBMonth.SelectedText = GDVCusLedger.SelectedRows[0].Cells["Month"].Value.ToString();
                txtDebit.Text = GDVCusLedger.SelectedRows[0].Cells["Salary"].Value.ToString();
                UpdateId = GDVCusLedger.SelectedRows[0].Cells["Id"].Value.ToString();
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
            string query = " where Date>='" + dateString + "' and Date<= '" + dateString1 + "'";
            PopulateGrid(query);
        }

        private void FilterByNameWithoutDate()
        {
            string query = "where tsl.EmployeeId = " + FilterNameBox.SelectedValue;
            PopulateGrid(query);
        }

        private void FilterByNameDate()
        {
            DateTime selectedDate = FromDate.Value; //get the selected date from the date picker
            string dateString = selectedDate.ToString("yyyy-MM-dd");
            DateTime selectedDate1 = ToDate.Value; //get the selected date from the date picker
            string dateString1 = selectedDate.ToString("yyyy-MM-dd");
            string query = "where Date>='" + dateString + "' and Date<= '" + dateString1 + "' and tslEmployeeId = " + FilterNameBox.SelectedValue;
            PopulateGrid(query);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }
    }
}
