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
    public partial class EmployeeLedger : Form
    {
        public EmployeeLedger()
        {
            InitializeComponent();
            LoadComboBox();
            PopulateGrid();
            customSetting();
        }
        private bool isFirstSelection = true;

        private void customSetting()
        {
            btnReport.Visible = false;
        }
        private void PopulateGrid()
        {
            int userId = (int)FilterNameBox.SelectedValue;

            database.LedgerGridPopulate(GDVCusLedger, userId);

            decimal income = database.CalculateColumnSum(GDVCusLedger, "income");
            decimal expense = database.CalculateColumnSum(GDVCusLedger, "expense");
            decimal balance = expense - income;

            labelBalance.Text = "Rs." + database.FormatAmount(balance);
            labelIncome.Text = "Rs." + database.FormatAmount(income);
            labelExpense.Text = "Rs." + database.FormatAmount(expense);

        }

        private void LoadComboBox()
        {
            string query = "Select Id,Name from tblStakeholders where role='Employee'";
            database.LoadComboBox(query, FilterNameBox);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
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
    }
}