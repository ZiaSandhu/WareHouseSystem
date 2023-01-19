using System;
using System.Collections;
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
    public partial class EmployeesLedger : MetroTemplate 
    {
        private string UpdateId;
        private double TotalWeight;
        private double Total;
        private double Advance = 0;
        private double Balance;

        private string BillId;

        public bool BillUpdate = false;
        public bool IsBillSaved = false;


        public EmployeesLedger()
        {
            InitializeComponent();
        }

        private void newBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("tabPage2");
            PopulatePage2Box();
        }

        private void PopulatePage2Box()
        {
            string query = "select Id,Name from tblEmployees";
            database.LoadComboBox(query, EmpNameBox);
            query = "select Id,Name from tblSuppliers";
            database.LoadComboBox(query, SupNameBox);
        }

        private void employeeSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("tabPage1");

        }

        private void EmployeesLedger_Load(object sender, EventArgs e)
        {
            PopulateSalaryGrid();
            PopulateComboBoxes();
        }

        private void PopulateSalaryGrid(string q="")
        {
            string query = "Select tsl.Id,ts.Name,tsl.Title,tsl.EmployeeId,tsl.Salaray,tsl.Income,tsl.Date from (tblEmployeeSalary tsl " +
                "INNER JOIN tblEmployees ts ON tsl.EmployeeId = ts.Id) " + q;
            database.PopulatGrid(query, GDVCusLedger);
            if (GDVCusLedger.Rows.Count > 0)
            {
                GDVCusLedger.Columns["Id"].Visible = false;
                GDVCusLedger.Columns["EmployeeId"].Visible = false;
            }
        }

        private void PopulateComboBoxes()
        {
            string query = "Select Id,Name from tblEmployees";
            database.LoadComboBox(query, CusNameBox);
            database.LoadComboBox(query, FilterNameBox);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (RequiredFieldsToAddSalary())
            {
                if (UpdateId == string.Empty)
                {
                    Saving();
                    SavingToDailySheet();
                }
                else
                {
                    UpdateRecord();
                    UpdateDailySheet();
                }
                Reset();
                PopulateSalaryGrid();
            }

        }

        private void UpdateDailySheet()
        {
            string RefId = "EL" + UpdateId;
            string Colm = "Expense";
            if (CBTitle.Text == "Income")
                Colm = "Income";
            string colm1 = "Expense";
            if (Colm == "Expense")
                colm1 = "Income";
                
            DateTime selectedDate = datepicker.Value;
            string dateString = selectedDate.ToString("yyyy-MM-dd");
            string query = "Update tblDailySheet set Name='" + CusNameBox.Text + "',Title='" + CBTitle.Text +"'," + Colm + "=" + txtDebit.Text.Trim() + ","+colm1+"=0,Date='"+dateString+ "'    where RefId='" + RefId+"'";
            database.RunQuery(query);
        }

        private void UpdateRecord()
        {
            string Colm = "Salaray";
            if (CBTitle.Text == "Income")
                Colm = "Income";
            string colm1 = "Salaray";
            if (Colm == "Salaray")
                colm1 = "Income";
            DateTime selectedDate = datepicker.Value;
            string dateString = selectedDate.ToString("yyyy-MM-dd");
            string query = "Update tblEmployeeSalary Set EmployeeId ="+ CusNameBox.SelectedValue + ",Title='" + CBTitle.Text + "'," + Colm + "=" + txtDebit.Text.Trim() + ","+colm1+"=0,Date='" + dateString + "' where Id="+UpdateId;
            database.RunQuery(query);
        }

        private bool RequiredFieldsToAddSalary()
        {
            return true;
        }

        private void SavingToDailySheet()
        {
            string query = "Select max(Id) from tblCustomerLedger";
            string RefId = database.ScalarQuery(query);
            RefId = "EL" + RefId;
            string Colm = "Expense";
            if (CBTitle.Text == "Income")
                Colm = "Income";
            DateTime selectedDate = datepicker.Value;
            string dateString = selectedDate.ToString("yyyy-MM-dd");
            query = "Insert into tblDailySheet(Name,Title,"+Colm+",Date,RefId) Values('"+CusNameBox.Text+"','"+CBTitle.Text+"',"+txtDebit.Text.Trim()+",'"+dateString+"','"+RefId+"')";
            database.RunQuery(query);
        }

        private void Saving()
        {
            string Colm = "Salaray";
            if (CBTitle.Text == "Income")
                Colm = "Income";
            DateTime selectedDate = datepicker.Value; 
            string dateString = selectedDate.ToString("yyyy-MM-dd");
            string query = "insert into tblEmployeeSalary(EmployeeId,Title," + Colm + ",Date) Values("+CusNameBox.SelectedValue+",'"+CBTitle.Text+"',"+txtDebit.Text.Trim()+",'"+dateString+"')";
            database.RunQuery(query);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            UpdateId = string.Empty;
            txtDebit.Text = string.Empty;
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
            DateTime selectedDate = FromDate.Value;
            string dateString = selectedDate.ToString("yyyy-MM-dd");
            DateTime selectedDate1 = ToDate.Value;
            string dateString1 = selectedDate1.ToString("yyyy-MM-dd");
            string query = "where Date>='" + dateString + "' and Date<= '" + dateString1 + "'";
            PopulateSalaryGrid(query);
        }

        private void FilterByNameWithoutDate()
        {
            string query = "where tsl.EmployeeId = " + FilterNameBox.SelectedValue;
            PopulateSalaryGrid(query);
        }

        private void FilterByNameDate()
        {
            DateTime selectedDate = FromDate.Value;
            string dateString = selectedDate.ToString("yyyy-MM-dd");
            DateTime selectedDate1 = ToDate.Value;
            string dateString1 = selectedDate1.ToString("yyyy-MM-dd");
            string query = "where Date>='" + dateString + "' and Date<= '" + dateString1 + "' and tsl.EmployeeId = " + FilterNameBox.SelectedValue;
            PopulateSalaryGrid(query);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateSalaryGrid();
        }

        private void GDVCusLedger_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!GDVCusLedger.SelectedRows[0].Cells["Title"].Value.ToString().Contains('#'))
            {
                CusNameBox.SelectedValue = GDVCusLedger.SelectedRows[0].Cells["EmployeeId"].Value;
                CBTitle.Text = GDVCusLedger.SelectedRows[0].Cells["Title"].Value.ToString();
                string Colm;
                if (CBTitle.Text == "Income")
                    Colm = "Income";
                else
                    Colm = "Salaray";
                txtDebit.Text = GDVCusLedger.SelectedRows[0].Cells[Colm].Value.ToString();
                UpdateId = GDVCusLedger.SelectedRows[0].Cells["Id"].Value.ToString(); 
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (RequiredFieldsToAddItem())
            {
                AddColumns();
                AddItems();
                CalculateTotalWeight(); 
            }
        }

        private bool RequiredFieldsToAddItem()
        {
            if(SupNameBox.SelectedIndex < 0)
            {
                MessageBox.Show("Select Vendors", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                SupNameBox.Focus();
                return false;
            }
            if (TxtWeight.Text == string.Empty)
            {
                MessageBox.Show("Enter Weight", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtWeight.Focus();
                return false;
            }
            return true;
        }

        private void CalculateTotalWeight()
        {
            double TotalWeight = 0;
            foreach(DataGridViewRow row in GDVBill.Rows)
            {
                TotalWeight += Convert.ToDouble(row.Cells["Weight"].Value);
            }
            TxtTotalWeight.Text = TotalWeight.ToString();
        }

        private void AddItems()
        {
            int sr = 0;
            sr=GDVBill.Rows.Count;
            string[] row = new string[] { (sr+1).ToString(), SupNameBox.Text, TxtWeight.Text.Trim() };
            GDVBill.Rows.Add(row);
        }

        private void AddColumns()
        {
            DataGridView dg = GDVBill;
            dg.ColumnCount = 3;
            dg.Columns[0].Name = "Sr";
            dg.Columns[1].Name = "Name";
            dg.Columns[2].Name = "Weight";
        }

        private void TxtTotalWeight_TextChanged(object sender, EventArgs e)
        {
            if (TxtTotalWeight.Text != string.Empty)
            {
                TotalWeight = Convert.ToDouble(TxtTotalWeight.Text.Trim());
            }
            else
                TotalWeight = 0;
            CalculateTotal();
        }
        private void CalculateTotal()
        {
            Total = TotalWeight * Convert.ToDouble(TxtRate.Text);
            TxtTotal.Text = Total.ToString();
        }

        private void TxtTotal_TextChanged(object sender, EventArgs e)
        {
            CalculateBalance();
        }

        private void TxtAdvance_TextChanged(object sender, EventArgs e)
        {
            if (TxtAdvance.Text != string.Empty)
            {
                Advance = Convert.ToDouble(TxtAdvance.Text.Trim());
            }
            else
                Advance = 0;
            CalculateBalance();
        }

        private void CalculateBalance()
        {
            Balance = Total - Advance;
            TxtBalance.Text = Balance.ToString();
        }

        private void TxtAdvance_KeyPress(object sender, KeyPressEventArgs e)
        {
            database.DigitValidWithoutDecimal(e);
        }

        private void TxtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            database.DigitValidation(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (GDVBill.Rows.Count > 0)
            {
                if (IsBillSaved)
                {
                    SavingBill();

                }
                else
                {
                    UpdateBill();
                }
            }
        }

        private void UpdateBill()
        {
            UpdateEmployeeBill();
            UpdateBillItem();
            UpdateEmployeeSalary();
            UpdateDailySheetForBill();
            MessageBox.Show("Bill Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void UpdateEmployeeBill()
        {
            DateTime selectedDate = DatePickerBill.Value;
            string dateString = selectedDate.ToString("yyyy-MM-dd");
            string query = "Update tblEmployeeBill set EmployeeId="+ EmpNameBox.SelectedValue + ",Weight="+ TxtTotalWeight.Text + ",Rate=" + TxtRate.Text + ",Total=" + TxtTotal.Text +"Advance=" + Advance + ",Balance=" + TxtBalance.Text + ",Date'" + dateString + " where Id="+BillId;
            database.RunQuery(query);
        }

        private void UpdateBillItem()
        {
            string query="Delete from tblEmpBillItem where EmpBillId="+BillId;
            database.RunQuery(query);
            foreach (DataGridViewRow row in GDVBill.Rows)
            {
                query = "Update tblEmpBillItem set Name='" + row.Cells["Name"].Value.ToString() + "',Weight=" + row.Cells["Weight"].Value.ToString() + " where EmpBillId="+BillId;
                database.RunQuery(query);

            }
        }

        private void UpdateEmployeeSalary()
        {
            DateTime selectedDate = DatePickerBill.Value;
            string dateString = selectedDate.ToString("yyyy-MM-dd");
            string query = "Update tblEmployeeSalary set EmployeeId=" + EmpNameBox.SelectedValue + ",Salaray=" + TxtAdvance.Text + ",Date ='" + dateString + "' where Title='Advance_Bill_#_" + BillId + "'";
            database.RunQuery(query);
        }

        private void UpdateDailySheetForBill()
        {
            string RefId = "EMB" + BillId;
            DateTime selectedDate = DatePickerBill.Value;
            string dateString = selectedDate.ToString("yyyy-MM-dd");
            string query = "Update tblDailySheet set Name='" + EmpNameBox.Text + "',Title='Advance_Bill_#_" + BillId + "',Expense=" + TxtAdvance.Text.Trim() + ",Date='" + dateString + "' where RefId='" + RefId + "')";
            database.RunQuery(query);
        }

        private void SavingBill()
        {
            InsertToEmpBill();
            InsertToEmpBillItem();
            if (Advance > 0)
                InsertToEmployeeSalary();
            InsertDailySheet();
            IsBillSaved = true;
            MessageBox.Show("Bill Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InsertToEmployeeSalary()
        {
            DateTime selectedDate = DatePickerBill.Value;
            string dateString = selectedDate.ToString("yyyy-MM-dd");
            string query = "Insert into tblEmployeeSalary(EmployeeId,Title,Salaray,Date) Values(" + EmpNameBox.SelectedValue + ",'Advance_Bill_#_" + BillId + "'," + TxtAdvance.Text + ",'" + dateString + "')";
            database.RunQuery(query);
        }

        private void InsertDailySheet()
        {
            string RefId = "EMB" + BillId;
            DateTime selectedDate = DatePickerBill.Value;
            string dateString = selectedDate.ToString("yyyy-MM-dd");
            string query = "Insert into tblDailySheet(Name,Title,Expense,Date,RefId) Values('" + EmpNameBox.Text + "','Advance_Bill_#_" + BillId + "'," + TxtAdvance.Text.Trim() + ",'" + dateString + "','" + RefId + "')";
            database.RunQuery(query);
        }

        private void InsertToEmpBillItem()
        {
            string query = "Select max(Id) from tblCustomerLedger";
            BillId = database.ScalarQuery(query);
            foreach(DataGridViewRow row in GDVBill.Rows)
            {
                query = "Insert Into tblEmpBillItem Values(" + BillId + ",'" + row.Cells["Name"].Value.ToString()+ "'," + row.Cells["Weight"].Value.ToString() +")";
                database.RunQuery(query);

            }
        }

        private void InsertToEmpBill()
        {
            DateTime selectedDate = DatePickerBill.Value;
            string dateString = selectedDate.ToString("yyyy-MM-dd");
            string query = "Insert into tblEmployeeBill Values("+EmpNameBox.SelectedValue+","+TxtTotalWeight.Text+","+TxtRate.Text+","+TxtTotal.Text+","+Advance+","+TxtBalance.Text+",'"+dateString+"')";
            database.RunQuery(query);
        }

        private void viewRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("tabPage3");
            string query = "select Id,Name from tblEmployees";
            database.LoadComboBox(query, comboBox1);
            PopulaterecordGrid();
        }

        private void PopulaterecordGrid(string q="")
        {
            string query = "Select tsl.Id,ts.Name,tsl.EmployeeId,tsl.Weight,tsl.Rate,tsl.Total,tsl.Advance,tsl.Balance,tsl.Date from (tblEmployeeBill tsl " +
                "INNER JOIN tblEmployees ts ON tsl.EmployeeId = ts.Id) " + q;
            database.PopulatGrid(query, GDVRecord);
            if (GDVRecord.Rows.Count > 0)
            {
                GDVRecord.Columns["EmployeeId"].Visible = false;
            }
        }

        private void viewDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("tabPage2");
            BillId = GDVRecord.SelectedRows[0].Cells["Id"].Value.ToString();
            EmpNameBox.SelectedValue = GDVRecord.SelectedRows[0].Cells["EmployeeId"].Value.ToString();
            MessageBox.Show(BillId);
            string query = "select Name,Weight from tblEmpBillItem where EmpBillId=" + BillId;
            database.PopulatGrid(query, GDVBill);
            CalculateTotalWeight();
            TxtAdvance.Text = GDVRecord.SelectedRows[0].Cells["Advance"].Value.ToString();
            IsBillSaved = true;
        }
    }
}