﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WareHouseSystem.General;

namespace WareHouseSystem.Screens.UI.ledger
{
    public partial class SupplierLedger : Form
    {
        public SupplierLedger()
        {
            InitializeComponent();
            LoadComboBox();
            PopulateGrid();
            customSetting();
        }

        private void customSetting()
        {
           btnReport.Visible = false;
        }

        private bool isFirstSelection = true;

        
        private void PopulateGrid()
        {
            int userId = (int)FilterNameBox.SelectedValue;

            database.LedgerGridPopulate(GDVCusLedger, userId);
            decimal income = database.CalculateColumnSum(GDVCusLedger, "income");
            decimal expense = database.CalculateColumnSum(GDVCusLedger, "expense");
            decimal balance =  income - expense ;

            labelBalance.Text = "Rs." + database.FormatAmount(balance);
            labelIncome.Text = "Rs." + database.FormatAmount(income);
            labelExpense.Text = "Rs." + database.FormatAmount(expense);
        }

        private void LoadComboBox()
        {
            string query = "Select Id,Name from tblStakeholders where role='Supplier'";
            database.LoadComboBox(query, FilterNameBox);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
          this.Close();
        }

        private void FromDate_ValueChanged(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void ToDate_ValueChanged(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void FilterNameBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!isFirstSelection)
            {
                PopulateGrid();
            }
        }

        private void btnBillPayment_Click(object sender, EventArgs e)
        {
            SupplierLedgerForm supplierLedgerForm = new SupplierLedgerForm(true);
            supplierLedgerForm.FormClosed += SupplierLedgerForm_FormClosed;
            supplierLedgerForm.ShowDialog();
        }
        private void SupplierLedgerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            PopulateGrid();
        }
    }
}
