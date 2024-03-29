﻿using System;
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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            customeDesign();
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

        private void customeDesign()
        {
            panelManagement.Visible = false;
            panelInvoiceSubmenu.Visible = false;
            panelLedger.Visible = false;

            btnInvoices.Enabled = false;
            btnProductList.Enabled = false; 
            //btnEmployeeList.Enabled = false;
            //btnEmployeeLedger.Enabled = false;

            openChildFormInPanel(new Stats());
        }

        private void hideSubMenus()
        {
            if(panelManagement.Visible)
            {
                panelManagement.Visible = false;
            }
            if(panelInvoiceSubmenu.Visible)
            {
                panelInvoiceSubmenu.Visible = false;
            }
            if(panelLedger.Visible)
            {
                panelLedger.Visible = false;
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

        private void btnManagement_Click(object sender, EventArgs e)
        {
            showSubMenu(panelManagement);
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
            showSubMenu(panelLedger);
        }

        private void btnExpenses_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Stats());
        }

        private void btnEmployeeList_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Employeers()); 
        }

        private void btnEmployeeLedger_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new EmployeeLedger()); 
        }

        private void btnDailySheet_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Cashbook());
        }

        private void btnProductList_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new Products());
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
