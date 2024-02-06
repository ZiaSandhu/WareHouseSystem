using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WareHouseSystem.Screens.UI.Manage;
using WareHouseSystem.Screens.UI.ledger;

namespace WareHouseSystem.Screens.UI
{
    public partial class Dashboard2 : Form
    {
        public Dashboard2()
        {
            InitializeComponent();
            customeDesign();
        }

        private void customeDesign()
        {
            panelEmployees.Visible = false;
            panelCustomer.Visible = false;
            panelInvoiceSubmenu.Visible = false;
            panelSuppliers.Visible = false;

            btnInvoices.Enabled = false;
            btnEmployees.Enabled = false;
        }

        private void hideSubMenus()
        {
            if(panelCustomer.Visible)
            {
                panelCustomer.Visible = false;
            }
            if(panelInvoiceSubmenu.Visible)
            {
                panelInvoiceSubmenu.Visible = false;
            }
            if(panelSuppliers.Visible)
            {
                panelSuppliers.Visible = false;
            }
            if(panelEmployees.Visible)
            {
                panelEmployees.Visible = false;
            }
        }

        private void showSubMenu(Panel subPanel)
        {
            if (!subPanel.Visible)
            {
                hideSubMenus();
                subPanel.Visible = true;
            }
            else
            {
               subPanel.Visible=false;
            }
        }

        

        private void btnInvoices_Click(object sender, EventArgs e)
        {
            showSubMenu(panelInvoiceSubmenu);
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            showSubMenu(panelCustomer);
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            showSubMenu(panelSuppliers);
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            showSubMenu(panelEmployees);
        }

        private Form activeForm = null;
        private void openChildFormInPanel(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void btnCustomerList_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Customers());
        }

        private void btnSupplierList_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Suppliers());
        }

        private void btnCustomerLedger_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new customerLedger());
        }

        private void btnSupplierLedger_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new SupplierLedger()); 
        }

        private void btnLedgers_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new DailySheet());
        }

        private void btnExpenses_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Expenses());
        }
    }
}
