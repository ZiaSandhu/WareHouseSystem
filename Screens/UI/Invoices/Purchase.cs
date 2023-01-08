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
using WareHouseSystem.Screens.UI.Manage;

namespace WareHouseSystem.Screens.UI.Invoices
{
    public partial class Purchase : MetroTemplate
    {
        private int ItemWeight;
        private int bagQuantity;
        private int ItemRate;
        private decimal ItemTotal;
        private decimal GrandTotal;
        private decimal NetAmount;
        private decimal Discount;
        private decimal Balance;
        private decimal CashPaid;

        private bool IsSaved = false;

        private string PurchaseId;

        public Purchase()
        {
            InitializeComponent();
        }

        private void Purchase_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            ResetFields();
        }

        private void LoadComboBoxes()
        {
            LoadSupplierName();
            LoadItemName();
           
        }

        private void LoadItemName()
        {
            string query = "Select Id,Name from tblProducts";
            database.LoadComboBox(query, ItemName);
        }

        private void LoadSupplierName()
        {
            string query = "Select Id,Name from tblSuppliers";
            database.LoadComboBox(query,SupName);
        }

        private void btnAddCus_Click(object sender, EventArgs e)
        {
            new Suppliers().ShowDialog();
            LoadSupplierName();
        }

        private void AddItemLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Products().ShowDialog();
            LoadItemName();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (RequiredFields())
            {
                CalculateItemTotal();
                AddItem();
                CalculateTotal();
                ResetFields();
            }
        }

        private void CalculateTotal()
        {
            GrandTotal = 0;
            int x = 1;
            foreach (DataGridViewRow dr in GDVitemDetail.Rows)
            {
                dr.Cells["sr"].Value = x++.ToString();
                GrandTotal += Convert.ToDecimal(dr.Cells["total"].Value);
            }
            NetAmount = GrandTotal;
            lblTotal.Text = GrandTotal.ToString();
            lblNetAmount.Text = NetAmount.ToString();
            Calculation();
        }

        private void Calculation()
        {
            if (txtTotalDis.Text != string.Empty)
            {
                Discount = Convert.ToDecimal(txtTotalDis.Text.Trim());
            }
            else
                Discount = 0;
            if (txtCash.Text != string.Empty)
            {
                CashPaid = Convert.ToDecimal(txtCash.Text.Trim());
            }
            else
                CashPaid = 0;
            NetAmount = GrandTotal - Discount;
            lblNetAmount.Text = NetAmount.ToString();
            Balance = NetAmount - CashPaid;
            lblBalance.Text = Balance.ToString();
            ResetFields();
        }

        private void CalculateItemTotal()
        {
            GetValues();
            ItemWeight -= bagQuantity * 3;
            ItemTotal = ItemWeight * ItemRate;
            txtItemTotal.Text=ItemTotal.ToString();
        }

        private void GetValues()
        {
            if (txtWeight.Text != string.Empty)
                ItemWeight = Convert.ToInt32(txtWeight.Text.Trim());
            else
                ItemWeight = 0;
            
            if(TotalBags.SelectedIndex != -1)
                bagQuantity = Convert.ToInt32(TotalBags.Text);
            else
                bagQuantity = 1;

            if (txtRate.Text != string.Empty)
                ItemRate = Convert.ToInt32(txtRate.Text.Trim());
            else
                ItemRate = 0;
        }

        private void ResetFields()
        {
            txtWeight.Text = string.Empty;
            txtRate.Text = string.Empty;
            txtItemTotal.Text = string.Empty;
            PurchaseId = string.Empty;
            TotalBags.SelectedIndex = 0;
            ItemName.SelectedIndex = 0;
            bagQuantity = 0;
            ItemWeight = 0;
            ItemRate = 0;
            ItemTotal = 0;
            IsSaved = false;
            ItemName.Focus();

        }

        private void AddItem()
        {
            int sr;
            sr = GDVitemDetail.Rows.Add();
            GDVitemDetail.Rows[sr].Cells["sr"].Value = sr + 1;
            GDVitemDetail.Rows[sr].Cells["desc"].Value = ItemName.Text;
            GDVitemDetail.Rows[sr].Cells["Weight"].Value = txtWeight.Text;
            GDVitemDetail.Rows[sr].Cells["bags"].Value = TotalBags.Text;
            GDVitemDetail.Rows[sr].Cells["rate"].Value = txtRate.Text;
            GDVitemDetail.Rows[sr].Cells["total"].Value = txtItemTotal.Text;
        }

        private bool RequiredFields()
        {
            if(txtWeight.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Weight is Missing !","Error",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                txtWeight.Focus();
                return false;
            }
            if (txtRate.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Rate/Kg is Missing !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtRate.Focus();
                return false;
            }
            if (TotalBags.SelectedIndex < 0)
            {
                MessageBox.Show("Select Bags Quantity!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                TotalBags.Focus();
                return false;
            }
            if (ItemName.SelectedIndex < 0)
            {
                MessageBox.Show("Select Item Name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                ItemName.Focus();
                return false;
            }
            return true;
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            CalculateItemTotal();
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            database.DigitValidation(sender, e);
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            database.DigitValidation(sender, e);
        }

        private void txtTotalDis_KeyPress(object sender, KeyPressEventArgs e)
        {
            database.DigitValidation(sender, e);

        }

        private void txtCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            database.DigitValidation(sender, e);

        }

        private void txtWeight_TextChanged(object sender, EventArgs e)
        {
            CalculateItemTotal();
        }

        private void TotalBags_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateItemTotal();
        }

        private void txtTotalDis_TextChanged(object sender, EventArgs e)
        {
            Calculation();
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            Calculation();            
        }

        private void GDVitemDetail_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Are You Sure ?\n This Process Can't Rollback.", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                e.Cancel = true;
        }

        private void GDVitemDetail_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            MessageBox.Show("Item Deleted Successfully", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CalculateTotal();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SavingInvoice();
        }

        private void SavingInvoice()
        {
            if (Valid())
            {
                InsertInvoice();
                InsertInvoiceDetail();
                if(Balance>0)
                    UpdateSupplierRecord();
                if (CashPaid > 0)
                    UpdateDailySheet();
                MessageBox.Show("Invoice Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsSaved = true;

            }
        }

        private void UpdateDailySheet()
        {
            
        }

        private void UpdateSupplierRecord()
        {
            string query = "Insert into tblSupplierLedger(Date,SupplierId,Title,Income,UpdateDate) Values('"+dateInvoice.Value.Date+"',"+SupName.SelectedValue+",'Invoice No "+PurchaseId+"',"+NetAmount+",'"+System.DateTime.Now.ToShortDateString()+"')";
            database.RunQuery(query);
        }

        private void InsertInvoiceDetail()
        {
            string query="Select max(Id) from tblPurchaseInvoice ";
            PurchaseId = database.ScalarQuery(query);
            foreach(DataGridViewRow row in GDVitemDetail.Rows)
            {
                string item = row.Cells["desc"].Value.ToString();
                string weight = row.Cells["Weight"].Value.ToString();
                string rate = row.Cells["rate"].Value.ToString();
                string total = row.Cells["total"].Value.ToString();
                string bag = row.Cells["bags"].Value.ToString();
                 query = "insert Into tblPurchaseItems Values("+PurchaseId+",'"+item+"',"+weight+","+rate+","+bag+","+total+")";
                database.RunQuery(query);
            }
        }

        private void InsertInvoice()
        {
            string query = "Insert into tblPurchaseInvoice Values("+SupName.SelectedValue+","+NetAmount+","+CashPaid+","+Balance+",'"+dateInvoice.Value.Date+"')";
            database.RunQuery(query);
        }

        private bool Valid()
        {
            if(GDVitemDetail.RowCount == 0)
            {
                MessageBox.Show("Empty Invoice !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                ItemName.Focus();
                return false;
            }
            if(SupName.SelectedIndex < 0)
            {
                MessageBox.Show("Select Supplier Name !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                SupName.Focus();
                return false;
            }
            return true;

        }

        private void GDVitemDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            UpdateTotal();
            CalculateTotal();
        }

        private void UpdateTotal()
        {
            ItemWeight = Convert.ToInt32(GDVitemDetail.SelectedRows[0].Cells["Weight"].Value);
            bagQuantity = Convert.ToInt32(GDVitemDetail.SelectedRows[0].Cells["bags"].Value);
            ItemWeight -= bagQuantity * 3;
            ItemRate = Convert.ToInt32(GDVitemDetail.SelectedRows[0].Cells["rate"].Value);
            ItemTotal = ItemRate * ItemWeight;
            GDVitemDetail.SelectedRows[0].Cells["total"].Value = ItemTotal.ToString();
            ResetFields();

        }

        private void GDVitemDetail_KeyPress(object sender, KeyPressEventArgs e)
        {
            database.DigitValidation(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsSaved)
            {
                this.Close();
                new Purchase().ShowDialog(); 
            }
            else
            {
                DialogResult result = MessageBox.Show("Do You want to save the Invoice!", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    SavingInvoice();
                }
                else if(result == DialogResult.Cancel)
                {
                    return;
                }
                this.Close();
                new Purchase().ShowDialog();
            }
        }
    }
}
