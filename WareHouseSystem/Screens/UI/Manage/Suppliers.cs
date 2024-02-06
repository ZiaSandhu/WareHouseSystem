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

namespace WareHouseSystem.Screens.UI.Manage
{
    public partial class Suppliers : Form
    {
        private string SupplierName { get; set; }
        private string SupplierID { get; set; }
        
        decimal bal = 0;

        public Suppliers()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Suppliers_Load(object sender, EventArgs e)
        {
            PopulateSupplierGrid();
        }

        private void PopulateSupplierGrid()
        {
            string query = "Select * from tblSuppliers";
            database.PopulatGrid(query,GDVSupplier);
        }

        private void ResetFormControls()
        {
            btnDelete.Enabled = false;
            btnSave.Text = "Save";
            bal = 0;
            this.SupplierID = null;
            this.SupplierName = null;
            txtBalance.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtName.Text = string.Empty; ;
            txtAddress.Text = string.Empty;
            PopulateSupplierGrid();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (RequireFields())
            {
                if (this.SupplierName == string.Empty || this.SupplierName == null)
                    InsertValues();
                else
                    UpdateValues();
            }
        }

        private void UpdateValues()
        {
            GetBalance();
            string query = "Update tblSuppliers set Name='" + txtName.Text.Trim() + "',Phone='" + txtPhone.Text.Trim() + "',Location='" + txtAddress.Text.Trim() + "',Balance=" + bal + " where Id='"+this.SupplierID+"'";
            if (database.RunQuery(query))
            {
                MessageBox.Show("Supplier Record Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetFormControls();
                PopulateSupplierGrid();
            }
            else
            {
                MessageBox.Show("Something Went Wrong \n Plz try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertValues()
        {
            GetBalance();
            string query = "Insert into tblSuppliers(name,phone,location,balance) Values('"+txtName.Text.Trim()+"','"+txtPhone.Text.Trim()+"','"+txtAddress.Text.Trim()+"',"+bal+")";
            if (database.RunQuery(query))
            {
                MessageBox.Show("Supplier Record Inserted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetFormControls();
                PopulateSupplierGrid();
            }
            else
            {
                MessageBox.Show("Something Went Wrong \n Plz try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetBalance()
        {
            if (txtBalance.Text.Trim().Length > 0)
                bal = Convert.ToDecimal(txtBalance.Text.Trim());
        }

        private bool RequireFields()
        {
            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("Name is Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return false;
            }
            //if (txtPhone.Text == string.Empty)
            //{
            //    MessageBox.Show("Phone is Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtPhone.Focus();
            //    return false;
            //}
            return true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (RequireFields())
            {
                if (MessageBox.Show("Are You Sure ? \n Delete Supplier " + txtName.Text + " from System.", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string query = "delete from tblSuppliers where Id='" + this.SupplierID + "'";
                    if (database.RunQuery(query))
                    {
                        MessageBox.Show("Supplier Record Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ResetFormControls();
                        PopulateSupplierGrid();
                    }
                    else
                    {
                        MessageBox.Show("Something Went Wrong \n Plz try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void GDVSupplier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GDVSupplier.Rows.Count > 0)
            {
                this.SupplierID = GDVSupplier.CurrentRow.Cells[0].Value.ToString();
                this.SupplierName = GDVSupplier.CurrentRow.Cells[1].Value.ToString();
                txtName.Text = this.SupplierName;
                txtPhone.Text = GDVSupplier.CurrentRow.Cells[2].Value.ToString();
                txtAddress.Text = GDVSupplier.CurrentRow.Cells[4].Value.ToString();
                txtBalance.Text = GDVSupplier.CurrentRow.Cells[3].Value.ToString();

                btnDelete.Enabled = true;
                btnSave.Text = "Update";
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string query = "Select * from tblSuppliers where Name like '%"+txtSearch.Text.Trim()+"%'";
            database.PopulatGrid(query, GDVSupplier);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFormControls();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            database.DigitValidation(sender, e);
        }

        private void txtBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            database.DigitValidation(sender, e);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
