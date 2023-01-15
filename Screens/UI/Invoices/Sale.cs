using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WareHouseSystem.General;
using WareHouseSystem.Screens.UI.Manage;

namespace WareHouseSystem.Screens.UI.Invoices
{
    public partial class Sale: MetroTemplate
    {
        private decimal ItemWeight;
        private int ItemRate;
        private decimal ItemTotal;
        private decimal GrandTotal;
        private decimal NetAmount;
        private decimal Discount;
        private decimal Balance;
        public decimal CashPaid;
        public string SaleId;
        public string CustomerId;
        public string Date;

        private string PrevCash;
        private string PrevBalance;

        private bool first = true;
        public bool IsSaved { get; set; }
        public bool IsUpdate { get; set; }
        public bool IsChanged { get; set; }

        public Sale()
        {
            InitializeComponent();
        }

        private void Sale_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            if (IsUpdate)
            {
                IsSaved = true;
                PopulateItemGrid();
            }
            else
            {
                IsSaved = false;
                GridAddingColumns();
            }
            ResetFields();

        }

        private void GridAddingColumns()
        {
            DataGridView dg = GDVitemDetail;
            dg.ColumnCount = 6;
            dg.Columns[0].Name = "Sr";
            dg.Columns[1].Name = "PId";
            dg.Columns[2].Name = "Description";
            dg.Columns[3].Name = "Weight";
            dg.Columns[4].Name = "Rate";
            dg.Columns[5].Name = "Total";
            dg.Columns[1].Visible = false;
            dg.Columns[2].ReadOnly = true;
            dg.Columns[5].ReadOnly = true;
            dg.Columns[0].ReadOnly = true;

        }

        public void PopulateItemGrid()
        {
            SetDateAndSupplier();
            GridAddingColumns();
            int sr = GDVitemDetail.Rows.Count;
            string query = "Select Item,Weight,Rate,Total,Pid from tblSaleItems where SaleId= " + SaleId;
            DataTable dt = database.GetTable(query);
            foreach (DataRow row in dt.Rows)
            {
                string[] row1 = new string[] { (sr + 1).ToString(), row["Pid"].ToString(), row["Item"].ToString(), row["Weight"].ToString(),  row["Rate"].ToString(), row["Total"].ToString() };
                GDVitemDetail.Rows.Add(row1);
            }
            CalculateGrandTotal();
        }

        private void SetDateAndSupplier()
        {
            CusName.SelectedValue = CustomerId;
            //dateInvoice.Value = DateTime.ParseExact((Date.Substring(0, 10)), "d", CultureInfo.InvariantCulture);
            txtCash.Text = CashPaid.ToString();
        }

        private void LoadComboBoxes()
        {
            LoadCustomerName();
            LoadCategories();

        }

        private void LoadCategories()
        {
            string query = "Select Id,Name from tblProducts";
            database.LoadComboBox(query, CatName);
            LoadItemName();
        }

        private void LoadItemName()
        {
            string query = "Select Id,Name from tblItems where ProductId="+CatName.SelectedValue;
            database.LoadComboBox(query, ItemName);
            if(ItemName.DataSource != null)
                GetCost();
            first = false;
        }

        private void LoadCustomerName()
        {
            string query = "Select Id,Name from tblCustomers";
            database.LoadComboBox(query, CusName);
        }

        private void btnAddCus_Click(object sender, EventArgs e)
        {
            new Customers().ShowDialog();
            LoadCustomerName();
        }

        private void AddItemLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Items().ShowDialog();
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
                AddItem();
                CalculateGrandTotal();
                ClearTextBoxes();
            }
        }

        private void CalculateGrandTotal()
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
            CashOrDiscountValueChanged();
        }

        private void CashOrDiscountValueChanged()
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
            IsChanged = true;
        }

        private void CalculateItemTotal()
        {
            GetValuesOfFields();
            ItemTotal = ItemWeight * ItemRate;
            txtItemTotal.Text = ItemTotal.ToString();
        }

        private void GetValuesOfFields()
        {
            if (txtWeight.Text != string.Empty)
                ItemWeight = Convert.ToDecimal(txtWeight.Text.Trim());
            else
                ItemWeight = 0;
            if (txtRate.Text != string.Empty)
                ItemRate = Convert.ToInt32(txtRate.Text.Trim());
            else
                ItemRate = 0;
        }

        private void ResetFields()
        {
            ItemWeight = 0;
            ItemRate = 0;
            ItemTotal = 0;
            ItemName.Focus();
            IsChanged = true;
            if (IsSaved)
            {
                btnSave.Text = "Update";
            }
            else
            {
                btnSave.Text = "Save";
            }

        }

        private void ClearTextBoxes()
        {
            txtWeight.Text = string.Empty;
            txtItemTotal.Text = string.Empty;
        }

        private void AddItem()
        {
            int sr;
            sr = GDVitemDetail.RowCount;
            string[] row = new string[] { (sr + 1).ToString(), CatName.SelectedValue.ToString(), ItemName.Text, txtWeight.Text,  txtRate.Text, txtItemTotal.Text };
            GDVitemDetail.Rows.Add(row);

        }

        private bool RequiredFields()
        {
            if (txtWeight.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Weight is Missing !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtWeight.Focus();
                return false;
            }
            if (txtRate.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Rate/Kg is Missing !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtRate.Focus();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsChanged)
            {
                if (!IsSaved)
                    SavingInvoice();
                else
                    UpdateInvoice();
            }
            else
            {
                MessageBox.Show("Already Saved");
            }
        }

        private void SavingInvoice()
        {
            if (Valid())
            {
                InsertInvoice();
                InsertInvoiceDetail();
                if (Balance > 0)
                    InsertCustomerRecord();
                if (CashPaid > 0)
                    InsertDailySheet();
                MessageBox.Show("Invoice Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IsSaved = true;
                IsChanged = false;

            }
        }

        private void InsertDailySheet()
        {
            DateTime selectedDate = dateInvoice.Value; //get the selected date from the date picker
            string dateString = selectedDate.ToString("yyyy-MM-dd");
            string query = "Insert Into tblDailySheet(Name,Title,Income,Date) Values('" + CusName.Text + "','Invoice_#_" + SaleId + "'," + CashPaid + ",'" + dateString + "')";
            database.RunQuery(query);
        }

        private void InsertCustomerRecord()
        {
            DateTime selectedDate = dateInvoice.Value; //get the selected date from the date picker
            string dateString = selectedDate.ToString("yyyy-MM-dd");
            string query = "Insert into tblCustomerLedger(Date,CustomerId,Title,InvoiceDue,UpdateDate) Values('" + dateString + "'," + CusName.SelectedValue + ",'Invoice_#_" + SaleId + "'," + Balance + ",GetDate())";
            database.RunQuery(query);
        }

        private void InsertInvoiceDetail()
        {
            GetSaleId();
            InsertItems();
        }

        private void InsertItems()
        {
            foreach (DataGridViewRow row in GDVitemDetail.Rows)
            {
                string item = row.Cells[2].Value.ToString();
                string weight = row.Cells[3].Value.ToString();
                string rate = row.Cells[4].Value.ToString();
                string total = row.Cells[5].Value.ToString();
                string Pid = row.Cells[1].Value.ToString();
                string query = "insert Into tblSaleItems Values(" + Pid + "," + SaleId + ",'" + item + "'," + weight +"," + rate + "," + total + ")";
                database.RunQuery(query);
                database.StockMinus(Pid, weight);
            }
        }

        private void GetSaleId()
        {
            string query = "Select max(Id) from tblSaleInvoice ";
            SaleId = database.ScalarQuery(query);
        }

        private void InsertInvoice()
        {
            DateTime selectedDate = dateInvoice.Value; //get the selected date from the date picker
            string dateString = selectedDate.ToString("yyyy-MM-dd");
            string query = "Insert into tblSaleInvoice(CustomerId,TotalBill,Cash,Balance,Date,UpdateDate) Values(" + CusName.SelectedValue + "," + NetAmount + "," + CashPaid + "," + Balance + ",'" + dateString + "',GetDate())";
            database.RunQuery(query);
        }

        private bool Valid()
        {
            if (GDVitemDetail.RowCount == 0)
            {
                MessageBox.Show("Empty Invoice !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                ItemName.Focus();
                return false;
            }
            if (CusName.SelectedIndex < 0)
            {
                MessageBox.Show("Select Supplier Name !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                CusName.Focus();
                return false;
            }
            return true;

        }

        private void GDVitemDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            UpdateTotal();
            CalculateGrandTotal();
        }

        private void UpdateTotal()
        {
            ItemWeight = Convert.ToDecimal(GDVitemDetail.SelectedRows[0].Cells[3].Value);
            ItemRate = Convert.ToInt32(GDVitemDetail.SelectedRows[0].Cells[4].Value);
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
            if (IsSaved && !IsChanged)
            {
                this.Hide();
                new Sale().ShowDialog();
            }
            else
            {
                DialogResult result = MessageBox.Show("Do You want to save the Invoice!", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (!IsSaved)
                        SavingInvoice();
                    else
                        UpdateInvoice();
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
                this.Hide();
                new Sale().ShowDialog();
            }
        }

        private void UpdateInvoice()
        {
            GetPreviousBalanceandCashValue();
            UpdatePurchaseInvoice();
            DeleteItemAndAddstock();
            InsertItems();
            UpdateSupplierRecord();
            UpdateDailySheet();
            MessageBox.Show("Invoice Updated");
            IsChanged = false;
        }

        private void GetPreviousBalanceandCashValue()
        {
            string query = "select balance from tblSaleInvoice where Id=" + SaleId;
            PrevBalance = database.ScalarQuery(query);
            query = "select Cash from tblSaleInvoice where Id=" + SaleId;
            PrevCash = database.ScalarQuery(query);
        }

        private void UpdateDailySheet()
        {
            //if previous record is inserted then update values
            if (Convert.ToDecimal(PrevCash) > 0)
            {
                DateTime selectedDate = dateInvoice.Value; //get the selected date from the date picker
                string dateString = selectedDate.ToString("yyyy-MM-dd");
                string query = "Update tblDailySheet set Name='" + CusName.Text + "',Title='Invoice_#_" + SaleId + "',Income=" + CashPaid + ",Date='" + dateString + "' where title='Invoice_#_" + SaleId + "'";
                database.RunQuery(query);
            }
            else if (CashPaid > 0)//else insert new record
            {
                InsertDailySheet();
            }
        }

        private void UpdateSupplierRecord()
        {
            string query = "Select CustomerId from tblSaleInvoice where id=" + SaleId;
            string SId = database.ScalarQuery(query);
            // if supplier same
            if (SId == CusName.SelectedValue.ToString())
            {
                // if previous record inserted than update
                if (Convert.ToDecimal(PrevBalance) > 0)
                {
                    query = "Update tblCustomerLedger set InvoiceDue=" + Balance + ", UpdateDate=GetDate() where title='Invoice_#_" + SaleId + "'";
                    database.RunQuery(query);
                }
                else if (Balance > 0)
                {
                    InsertCustomerRecord();
                }
            }
            else
            {
                query = "delete from tblSupplierLedger where title='Invoice_#_" + SaleId + "'";
                database.RunQuery(query);
                InsertCustomerRecord();
            }
        }

        private void DeleteItemAndAddstock()
        {
            GetItemfromTableAndAddingStock();
            DeleteItemFromTable();
        }

        private void DeleteItemFromTable()
        {
            string query = "Delete from tblSaleItems where SaleId=" + SaleId;
            database.RunQuery(query);
        }

        private void GetItemfromTableAndAddingStock()
        {
            string query = "select Pid,weight from tblSaleItems where SaleId=" + SaleId;
            DataTable table = database.GetTable(query);
            foreach (DataRow row in table.Rows)
            {
                database.StockAdd(row["Pid"].ToString(), row["weight"].ToString());
            }

        }

        private void UpdatePurchaseInvoice()
        {
            string query = "update tblSaleInvoice set CustomerId=" + CusName.SelectedValue + ",TotalBill= " + NetAmount + ",Cash=" + CashPaid + ",Balance=" + Balance + ", UpdateDate=GetDate()  where Id=" + SaleId;
            database.RunQuery(query);
        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {
            CalculateItemTotal();
        }

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            database.DigitValidWithoutDecimal(e);

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

        private void txtTotalDis_TextChanged(object sender, EventArgs e)
        {
            CashOrDiscountValueChanged();
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            CashOrDiscountValueChanged();
        }

        private void GDVitemDetail_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Are You Sure ?\n This Process Can't Rollback.", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                e.Cancel = true;
        }

        private void GDVitemDetail_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            MessageBox.Show("Item Deleted Successfully", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CalculateGrandTotal();
        }

        private void SupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsChanged = true;
        }

        private void GetCost()
        {
            string query = "select rate from tblItems where Id=" + ItemName.SelectedValue;
            string cost = database.ScalarQuery(query);
            txtRate.Text = cost;
            CalculateItemTotal();
        }

        private void ItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!first && ItemName.DataSource != null)
                GetCost();
            else
            {
                txtRate.Text = string.Empty;
            }
        }

        private void CatName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!first)
                LoadItemName();
        }
    }
}
