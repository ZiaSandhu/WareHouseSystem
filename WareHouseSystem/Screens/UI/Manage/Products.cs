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
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }
        private string ProductID { get; set; }

        decimal stock = 0;

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
            string query = "Select * from tblProducts";
            database.PopulatGrid(query, GDVSupplier);
        }

        private void ResetFormControls()
        {
            btnDelete.Enabled = false;
            btnSave.Text = "Save";

            this.ProductID = null;
            txtStock.Text = string.Empty;
            txtName.Text = string.Empty; ;
            PopulateSupplierGrid();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (RequireFields())
            {
                if (this.ProductID == string.Empty || this.ProductID == null)
                    InsertValues();
                else
                    UpdateValues();
            }
        }

        private void UpdateValues()
        {
            GetStock();
            string query = "Update tblProducts set Name='" + txtName.Text.Trim() + "',Stock=" + stock +" where Id='" + this.ProductID + "'";
            if (database.RunQuery(query))
            {
                MessageBox.Show("Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            GetStock();
            string query = "Insert into tblProducts Values('" + txtName.Text.Trim() + "',"+stock+")";
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

        private void GetStock()
        {
            if (txtStock.Text.Trim().Length > 0)
                stock = Convert.ToDecimal(txtStock.Text.Trim());
        }

        private bool RequireFields()
        {
            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("Name is Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return false;
            }
            return true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (RequireFields())
            {
                if (MessageBox.Show("Are You Sure ? \n Delete Product " + txtName.Text + " from System.", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string query = "delete from tblProducts where Id='" + this.ProductID + "'";
                    if (database.RunQuery(query))
                    {
                        MessageBox.Show("Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                this.ProductID = GDVSupplier.CurrentRow.Cells[0].Value.ToString();
                txtName.Text = GDVSupplier.CurrentRow.Cells[1].Value.ToString();
                txtStock.Text = GDVSupplier.CurrentRow.Cells[2].Value.ToString();
                btnDelete.Enabled = true;
                btnSave.Text = "Update";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFormControls();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            database.DigitValidation(sender, e);
        }
    }
}
