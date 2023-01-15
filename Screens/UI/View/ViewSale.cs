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
    public partial class ViewSale : MetroTemplate
    {
        public ViewSale()
        {
            InitializeComponent();
        }

        private void ViewSale_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            LoadGrid();
        }

        private void LoadComboBox()
        {
            string query = "Select Id,Name from tblCustomers";
            database.LoadComboBox(query, FilterNameBox);
        }

        private void LoadGrid()
        {
            string query = "Select tp.Id as 'Invoice_Id',tp.CustomerId,ts.Name,tp.TotalBill,tp.Cash,tp.Balance,tp.Date FROM (tblSaleInvoice tp INNER JOIN tblCustomers ts ON tp.CustomerId = ts.Id)";
            database.PopulatGrid(query, GDVInvoice);
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
            string query = "Select tp.Id as 'Invoice_Id',tp.CustomerId, ts.Name, tp.TotalBill,tp.Cash, tp.Balance,tp.Date FROM (tblSaleInvoice tp INNER JOIN tblCustomers ts ON tp.CustomerId = ts.Id)";
            query += " where tp.date >= '" + FromDate.Value.ToShortDateString() + "' and tp.date<= '" + ToDate.Value.ToShortDateString() + "'";
            database.PopulatGrid(query, GDVInvoice);
        }

        private void FilterByNameWithoutDate()
        {
            string query = "Select tp.Id as 'Invoice_Id' ,tp.CustomerId, ts.Name, tp.TotalBill,tp.Cash, tp.Balance,tp.Date FROM (tblSaleInvoice tp INNER JOIN tblCustomers ts ON tp.CustomerId = ts.Id)";
            query += " where tp.CustomerId = " + FilterNameBox.SelectedValue;
            database.PopulatGrid(query, GDVInvoice);

        }

        private void FilterByNameDate()
        {
            string query = "Select tp.Id as 'Invoice_Id',tp.CustomerId , ts.Name, tp.TotalBill, tp.Cash,tp.Balance,tp.Date FROM (tblSaleInvoice tp INNER JOIN tblCustomers ts ON tp.CustomerId = ts.Id)";
            query += " where tp.date >= '" + FromDate.Value.ToShortDateString() + "' and tp.date<= '" + ToDate.Value.ToShortDateString() + "'";
            query += " and tp.CustomerId = " + FilterNameBox.SelectedValue;
            database.PopulatGrid(query, GDVInvoice);

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CBdate.Checked = false;
            CBName.Checked = false;
            LoadGrid();
        }

        private void ViewReocord_Opening(object sender, CancelEventArgs e)
        {
            if (GDVInvoice.SelectedRows.Count <= 0)
            {
                e.Cancel = true;
            }
        }

        private void viewDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sale purchase = new Sale();
            purchase.IsUpdate = true;
            purchase.SaleId = GDVInvoice.SelectedRows[0].Cells["Invoice_Id"].Value.ToString();
            purchase.CustomerId = GDVInvoice.SelectedRows[0].Cells["CustomerId"].Value.ToString();
            purchase.Date = GDVInvoice.SelectedRows[0].Cells["Date"].Value.ToString();
            purchase.CashPaid = Convert.ToDecimal(GDVInvoice.SelectedRows[0].Cells["Cash"].Value);
            purchase.ShowDialog();
            LoadGrid();


        }
    }
}
