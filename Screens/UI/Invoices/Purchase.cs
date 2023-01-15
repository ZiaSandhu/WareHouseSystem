using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
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
    public partial class Purchase : MetroTemplate
    {
        private decimal ItemWeight;
        private int bagQuantity;
        private int ItemRate;
        private decimal ItemTotal;
        private decimal GrandTotal;
        private decimal NetAmount;
        private decimal Discount;
        private decimal Balance;
        public decimal CashPaid;
        public string PurchaseId;
        public string Supplier;
        public string Date;

        private string PrevCash;
        private string PrevBalance;

        private bool first = true;
        public bool IsSaved { get; set; }
        public bool IsUpdate { get; set; }
        public bool IsChanged { get; set; }

        public Purchase()
        {
            InitializeComponent();
        }

        private void Purchase_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            //GetCost();
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
            DataGridView dg=GDVitemDetail;
            dg.ColumnCount = 8;
            dg.Columns[0].Name = "Sr";
            dg.Columns[1].Name = "PId";
            dg.Columns[2].Name = "Description";
            dg.Columns[3].Name = "Weight";
            dg.Columns[4].Name = "Bags";
            dg.Columns[5].Name = "NetWeight";
            dg.Columns[6].Name = "Rate";
            dg.Columns[7].Name = "Total";
            dg.Columns[1].Visible = false;
            dg.Columns[2].ReadOnly = true;
            dg.Columns[5].ReadOnly = true;
            dg.Columns[0].ReadOnly = true;
            dg.Columns[7].ReadOnly = true;

        }

        public void PopulateItemGrid()
        {
            SetDateAndSupplier();
            GridAddingColumns();
            int sr=GDVitemDetail.Rows.Count;
            string query = "Select Item,Weight,Cost,Bags,NetWeight,Total,Pid from tblPurchaseItems where PurchaseId= "+PurchaseId;
            DataTable dt=database.GetTable(query);
            foreach(DataRow row in dt.Rows)
            {
                string[] row1 = new string[] { (sr + 1).ToString(), row["Pid"].ToString() ,row["Item"].ToString(), row["Weight"].ToString(), row["Bags"].ToString(), row["NetWeight"].ToString(),row["Cost"].ToString(), row["Total"].ToString() };
                GDVitemDetail.Rows.Add(row1);
            }
            CalculateGrandTotal();
        }

        private void SetDateAndSupplier()
        {
            SupName.SelectedValue = Supplier;
            //dateInvoice.Value = DateTime.ParseExact((Date.Substring(0,10)),"d", CultureInfo.InvariantCulture);
            txtCash.Text=CashPaid.ToString();  
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
            GetCost();
            first = false;
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
            if ((IsSaved && !IsChanged) || GDVitemDetail.Rows.Count==0)
            {
                this.Close();
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
                this.Close();
            }
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
            ItemWeight -= bagQuantity * 3;
            ItemTotal = ItemWeight * ItemRate;
            txtItemTotal.Text=ItemTotal.ToString();
        }

        private void GetValuesOfFields()
        {
            if (txtWeight.Text != string.Empty)
                ItemWeight = Convert.ToInt32(txtWeight.Text.Trim());
            else
                ItemWeight = 0;

            if (TotalBags.SelectedIndex != -1)
                bagQuantity = Convert.ToInt32(TotalBags.Text);
            else
            {
                TotalBags.SelectedIndex = 0;
                bagQuantity = 1;
            }
            if (txtRate.Text != string.Empty)
                ItemRate = Convert.ToInt32(txtRate.Text.Trim());
            else
                ItemRate = 0;
        }

        private void ResetFields()
        {
            bagQuantity = 0;
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
            TotalBags.SelectedIndex = 0;
        }

        private void AddItem()
        {
            int sr;
            sr = GDVitemDetail.RowCount;
            string[] row = new string[] { (sr+1).ToString(), ItemName.SelectedValue.ToString(),ItemName.Text,txtWeight.Text,TotalBags.Text,ItemWeight.ToString(),txtRate.Text,txtItemTotal.Text };
            GDVitemDetail.Rows.Add(row);
            //GDVitemDetail.Rows[sr].Cells["sr"].Value = sr + 1;
            //GDVitemDetail.Rows[sr].Cells["desc"].Value = ItemName.Text;
            //GDVitemDetail.Rows[sr].Cells["Weight"].Value = txtWeight.Text;
            //GDVitemDetail.Rows[sr].Cells["bags"].Value = TotalBags.Text;
            //GDVitemDetail.Rows[sr].Cells["rate"].Value = txtRate.Text;
            //GDVitemDetail.Rows[sr].Cells["total"].Value = txtItemTotal.Text;
            //GDVitemDetail.Rows[sr].Cells["PId"].Value = ItemName.SelectedValue;

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
                if(Balance>0)
                    InsertSupplierRecord();
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
            string query = "Insert Into tblDailySheet(Name,Title,Expense,Date) Values('" + SupName.Text + "','Invoice_#_" + PurchaseId + "'," + CashPaid + ",'" +dateString + "')";
            database.RunQuery(query);
        }

        private void InsertSupplierRecord()
        {
            DateTime selectedDate = dateInvoice.Value; //get the selected date from the date picker
            string dateString = selectedDate.ToString("yyyy-MM-dd");
            string query = "Insert into tblSupplierLedger(Date,SupplierId,Title,InvoiceDue,UpdateDate) Values('"+dateString+"' ,"+SupName.SelectedValue+ ",'Invoice_#_" + PurchaseId+"',"+Balance+",GetDate())";
            database.RunQuery(query);
        }

        private void InsertInvoiceDetail()
        {
            GetProductId();
            InsertItems();
        }

        private void InsertItems()
        {
            foreach (DataGridViewRow row in GDVitemDetail.Rows)
            {
                string item = row.Cells[2].Value.ToString();
                string weight = row.Cells[3].Value.ToString();
                string bag = row.Cells[4].Value.ToString();
                string Netweight = row.Cells[5].Value.ToString();
                string rate = row.Cells[6].Value.ToString();
                string total = row.Cells[7].Value.ToString();
                string Pid = row.Cells[1].Value.ToString();
                string query = "insert Into tblPurchaseItems Values(" + PurchaseId + "," + Pid + ",'" + item + "'," + weight + "," + bag + "," + Netweight + "," + rate + "," + total + ")";
                database.RunQuery(query);
                database.StockAdd(Pid, Netweight);
            }
        }

        private void GetProductId()
        {
            string query = "Select max(Id) from tblPurchaseInvoice ";
            PurchaseId = database.ScalarQuery(query);
        }

        private void InsertInvoice()
        {
            DateTime selectedDate = dateInvoice.Value; //get the selected date from the date picker
            string dateString = selectedDate.ToString("yyyy-MM-dd");
            string query = "Insert into tblPurchaseInvoice(SupplierId,TotalBill,Cash,Balance,Date,UpdateDate) Values("+SupName.SelectedValue+","+NetAmount+","+CashPaid+","+Balance+",'"+dateString+"',GetDate())";
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
            CalculateGrandTotal();
        }

        private void UpdateTotal()
        {
            ItemWeight = Convert.ToDecimal(GDVitemDetail.SelectedRows[0].Cells[3].Value);
            bagQuantity = Convert.ToInt32(GDVitemDetail.SelectedRows[0].Cells[4].Value);
            ItemWeight -= bagQuantity * 3;
            GDVitemDetail.SelectedRows[0].Cells[5].Value = ItemWeight;
            ItemRate = Convert.ToInt32(GDVitemDetail.SelectedRows[0].Cells[6].Value);
            ItemTotal = ItemRate * ItemWeight;
            GDVitemDetail.SelectedRows[0].Cells[7].Value = ItemTotal.ToString();
            ResetFields();

        }

        private void GDVitemDetail_KeyPress(object sender, KeyPressEventArgs e)
        {
            database.DigitValidation(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((IsSaved && !IsChanged) || GDVitemDetail.Rows.Count == 0)
            {
                this.Hide();
                new Purchase().ShowDialog(); 
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
                else if(result == DialogResult.Cancel)
                {
                    return;
                }
                this.Hide();
                new Purchase().ShowDialog();
            }
        }

        private void UpdateInvoice()
        {
            GetPreviousBalanceandCashValue();
            UpdatePurchaseInvoice();
            DeleteItemAndSubtractstock();
            InsertItems();
            UpdateSupplierRecord();
            UpdateDailySheet();
            MessageBox.Show("Invoice Updated");
            IsChanged = false;
        }

        private void GetPreviousBalanceandCashValue()
        {
            string query = "select balance from tblPurchaseInvoice where Id="+PurchaseId;
            PrevBalance = database.ScalarQuery(query);
            query = "select Cash from tblPUrchaseInvoice where Id="+PurchaseId;
            PrevCash = database.ScalarQuery(query);
        }

        private void UpdateDailySheet()
        {
            //if previous record is inserted then update values
            if (Convert.ToDecimal(PrevCash) > 0)
            {
                DateTime selectedDate = dateInvoice.Value; //get the selected date from the date picker
                string dateString = selectedDate.ToString("yyyy-MM-dd");
                string query = "Update tblDailySheet set Name='" + SupName.Text + "',Title='Invoice_#_a" + PurchaseId + "',Expense=" + CashPaid + ",Date='" + dateString + "' where title='Invoice_#_"+PurchaseId+"'";
                database.RunQuery(query);
            }
            else if(CashPaid > 0)//else insert new record
            {
                InsertDailySheet();
            }
        }

        private void UpdateSupplierRecord()
        {
            string query = "Select SupplierId from tblPurchaseInvoice where id=" + PurchaseId;
            string SId = database.ScalarQuery(query);
            // if supplier same
            if (SId == SupName.SelectedValue.ToString())
            {
                // if previous record inserted than update
                if (Convert.ToDecimal(PrevBalance) > 0)
                {
                    query = "Update tblSupplierLedger set InvoiceDue=" + Balance + ", UpdateDate=GetDate() where title='Invoice_#_" + PurchaseId + "'";
                    database.RunQuery(query);
                }
                else if (Balance > 0)
                {
                    InsertSupplierRecord();
                }
            }
            else
            {
                query = "delete from tblSupplierLedger where title='Invoice_#_" + PurchaseId + "'";
                database.RunQuery(query);
                InsertSupplierRecord();
            }
        }

        private void DeleteItemAndSubtractstock()
        {
            GetItemfromTableAndSubractingStock();
            DeleteItemFromTable();
        }

        private void DeleteItemFromTable()
        {
            string query = "Delete from tblPurchaseItems where PurchaseId="+PurchaseId;
            database.RunQuery(query);
        }

        private void GetItemfromTableAndSubractingStock()
        {
            string query = "select Pid,Netweight from tblPurchaseItems where PurchaseId="+PurchaseId;
            DataTable table = database.GetTable(query);
            foreach(DataRow row in table.Rows)
            {
                database.StockMinus(row["Pid"].ToString(), row["Netweight"].ToString());
            }

        }

        private void UpdatePurchaseInvoice()
        {
            string query = "update tblPurchaseInvoice set SupplierId="+SupName.SelectedValue+",TotalBill= "+NetAmount+",Cash="+CashPaid+",Balance="+Balance+", UpdateDate=GetDate()  where Id="+PurchaseId;
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

        private void TotalBags_SelectedIndexChanged(object sender, EventArgs e)
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
            string query = "select cost from tblProducts where Id=" + ItemName.SelectedValue ;
            string cost = database.ScalarQuery(query);
            txtRate.Text = cost;
            CalculateItemTotal();
        }

        private void ItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!first)
                GetCost();
        }
    }
}
