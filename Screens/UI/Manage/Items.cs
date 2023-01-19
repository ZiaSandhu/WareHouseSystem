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

namespace WareHouseSystem.Screens.UI.Manage
{
    public partial class Items : MetroTemplate
    {
        public Items()
        {
            InitializeComponent();
        }
        private string ItemID { get; set; }

        private void Suppliers_Load(object sender, EventArgs e)
        {
            PopulateSupplierGrid();
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            string query = "select Id,Name from tblProducts";
            database.LoadComboBox(query, CatName);
        }

        private void PopulateSupplierGrid()
        {
            string query = "Select * from tblItems";
            database.PopulatGrid(query, GDVSupplier);
        }

        private void ResetFormControls()
        {
            btnDelete.Enabled = false;
            btnSave.Text = "Save";

            this.ItemID = null;
            CatName.SelectedIndex = 0;
            txtName.Text = string.Empty;
            txtCost.Text = string.Empty;
            PopulateSupplierGrid();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (RequireFields())
            {
                if (this.ItemID == string.Empty || this.ItemID == null)
                    InsertValues();
                else
                    UpdateValues();
            }
        }

        private void UpdateValues()
        {
            string query = "Update tblItems set ProductId="+CatName.SelectedValue+", Name='" + txtName.Text.Trim() + "',Rate=" + txtCost.Text.Trim() + " where Id='" + this.ItemID + "'";
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
            string query = "Insert into tblItems Values("+CatName.SelectedValue+",'" + txtName.Text.Trim() + "'," + txtCost.Text.Trim() + ")";
            if (database.RunQuery(query))
            {
                MessageBox.Show("Item Record Inserted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetFormControls();
                PopulateSupplierGrid();
            }
            else
            {
                MessageBox.Show("Something Went Wrong \n Plz try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool RequireFields()
        {
            if(CatName.SelectedIndex < 0)
            {
                MessageBox.Show("Category is Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CatName.Focus();
                return false;
            }
            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("Name is Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return false;
            }
            if (txtCost.Text == string.Empty)
            {
                MessageBox.Show("Cost is Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCost.Focus();
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
                    string query = "delete from tblItems where Id='" + this.ItemID + "'";
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
                this.ItemID = GDVSupplier.CurrentRow.Cells[0].Value.ToString();
                CatName.SelectedValue = GDVSupplier.CurrentRow.Cells[1].Value;
                txtName.Text = GDVSupplier.CurrentRow.Cells[2].Value.ToString();
                txtCost.Text = GDVSupplier.CurrentRow.Cells[3].Value.ToString();
                btnDelete.Enabled = true;
                btnSave.Text = "Update";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFormControls();
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            database.DigitValidation(sender, e);
        }

        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            database.DigitValidation(sender, e);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Products().ShowDialog();
            LoadComboBox();
            PopulateSupplierGrid();
        }

        
    }
}
