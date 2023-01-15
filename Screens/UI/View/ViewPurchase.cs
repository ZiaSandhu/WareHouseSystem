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
using WareHouseSystem.Screens.UI.Invoices;

namespace WareHouseSystem.Screens.UI.View
{
    public partial class ViewPurchase :MetroTemplate
    {
        public ViewPurchase()
        {
            InitializeComponent();
        }

        private void ViewPurchase_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            LoadGrid();
        }

        private void LoadComboBox()
        {
            string query = "Select Id,Name from tblSuppliers";
            database.LoadComboBox(query, FilterNameBox);
        }

        private void LoadGrid(string w="")
        {
            string query = "Select tp.Id as 'Invoice_Id',tp.SupplierId,ts.Name,tp.TotalBill,tp.Cash,tp.Balance,tp.Date FROM (tblPurchaseInvoice tp INNER JOIN tblSuppliers ts ON tp.SupplierId = ts.Id) " + w;
            database.PopulatGrid(query, GDVInvoice);
            GDVInvoice.Columns["SupplierId"].Visible = false;
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
            string query = " where tp.date >= '"+dateString+"' and tp.date<= '"+dateString1+"'";
            LoadGrid(query);
        }

        private void FilterByNameWithoutDate()
        {
           string query = " where tp.SupplierId = "+FilterNameBox.SelectedValue;
           LoadGrid(query);

        }

        private void FilterByNameDate()
        {
            DateTime selectedDate = FromDate.Value; //get the selected date from the date picker
            string dateString = selectedDate.ToString("yyyy-MM-dd");
            DateTime selectedDate1 = ToDate.Value; //get the selected date from the date picker
            string dateString1 = selectedDate.ToString("yyyy-MM-dd");
            
           string query = " where tp.date >= '" + dateString + "' and tp.date<= '" + dateString1 + "'";
            query += " and tp.SupplierId = " + FilterNameBox.SelectedValue;
            LoadGrid(query);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CBdate.Checked = false;
            CBName.Checked = false;
            LoadGrid();
        }

        private void ViewReocord_Opening(object sender, CancelEventArgs e)
        {
            if(GDVInvoice.SelectedRows.Count <= 0)
            {
                e.Cancel = true;
            }
        }

        private void viewDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Purchase purchase = new Purchase();
            purchase.IsUpdate = true;
            purchase.PurchaseId = GDVInvoice.SelectedRows[0].Cells["Invoice_Id"].Value.ToString();
            purchase.Supplier = GDVInvoice.SelectedRows[0].Cells["SupplierId"].Value.ToString();
            purchase.Date = GDVInvoice.SelectedRows[0].Cells["Date"].Value.ToString();
            purchase.CashPaid = Convert.ToDecimal(GDVInvoice.SelectedRows[0].Cells["Cash"].Value);
            purchase.ShowDialog();
            LoadGrid();


        }
    }
}
