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
    public partial class AddEmployees : MetroTemplate
    {
        public AddEmployees()
        {
            InitializeComponent();
        }
        private string EmployeeName { get; set; }
        private string EmployeeID { get; set; }
        private void AddEmployees_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void PopulateGrid()
        {
            string query = "Select * from tblEmployees";
            database.PopulatGrid(query, GDVSupplier);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFormControls();   
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (RequiredFileds())
            {
                if (this.EmployeeName == string.Empty || this.EmployeeID == null)
                    InsertValues();
                else
                    UpdateValues();
            }
        }

        private void UpdateValues()
        {
            string query = "Update tblEmployees set Name='" + txtName.Text.Trim() + "',Phone='" + txtPhone.Text.Trim() + "',Location='" + txtAddress.Text.Trim() + "' where Id='" + this.EmployeeID + "'";
            if (database.RunQuery(query))
            {
                MessageBox.Show("Employee Record Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetFormControls();
                PopulateGrid();
            }
            else
            {
                MessageBox.Show("Something Went Wrong \n Plz try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetFormControls()
        {
            btnDelete.Enabled = false;
            btnSave.Text = "Save";

            this.EmployeeID = null;
            this.EmployeeName = null;
            txtPhone.Text = string.Empty;
            txtName.Text = string.Empty; ;
            txtAddress.Text = string.Empty;
            PopulateGrid();
        }

        private void InsertValues()
        {
            string query = "Insert into tblEmployees Values('" + txtName.Text.Trim() + "','" + txtPhone.Text.Trim() + "','" + txtAddress.Text.Trim() + "')";
            if (database.RunQuery(query))
            {
                MessageBox.Show("Supplier Record Inserted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetFormControls();
                PopulateGrid();
            }
            else
            {
                MessageBox.Show("Something Went Wrong \n Plz try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool RequiredFileds()
        {
            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("Name is Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return false;
            }
            if (txtPhone.Text == string.Empty)
            {
                MessageBox.Show("Phone is Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhone.Focus();
                return false;
            }
            return true;
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            database.DigitValidWithoutDecimal(e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GDVSupplier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GDVSupplier.Rows.Count > 0)
            {
                this.EmployeeID = GDVSupplier.CurrentRow.Cells[0].Value.ToString();
                this.EmployeeName = GDVSupplier.CurrentRow.Cells[1].Value.ToString();
                txtName.Text = this.EmployeeName;
                txtPhone.Text = GDVSupplier.CurrentRow.Cells[2].Value.ToString();
                txtAddress.Text = GDVSupplier.CurrentRow.Cells[3].Value.ToString();

                btnDelete.Enabled = true;
                btnSave.Text = "Update";
            }
        }
    }
}
