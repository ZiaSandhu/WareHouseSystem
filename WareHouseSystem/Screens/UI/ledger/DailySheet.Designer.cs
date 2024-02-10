namespace WareHouseSystem.Screens.UI.ledger
{
    partial class DailySheet
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DailySheet));
            this.UserRecords = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.labelBalance = new System.Windows.Forms.Label();
            this.labelExpense = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelIncome = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.GDVCashbook = new System.Windows.Forms.DataGridView();
            this.ToDate = new System.Windows.Forms.DateTimePicker();
            this.FromDate = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExpenseForm = new System.Windows.Forms.Button();
            this.btnSupplierLedgerForm = new System.Windows.Forms.Button();
            this.btnCustomerLedgerForm = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.UserRecords.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GDVCashbook)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserRecords
            // 
            this.UserRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserRecords.Controls.Add(this.panel2);
            this.UserRecords.Controls.Add(this.label1);
            this.UserRecords.Controls.Add(this.btnReport);
            this.UserRecords.Controls.Add(this.GDVCashbook);
            this.UserRecords.Controls.Add(this.ToDate);
            this.UserRecords.Controls.Add(this.FromDate);
            this.UserRecords.Controls.Add(this.label14);
            this.UserRecords.Controls.Add(this.label13);
            this.UserRecords.Controls.Add(this.btnRefresh);
            this.UserRecords.Controls.Add(this.btnSearch);
            this.UserRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserRecords.ForeColor = System.Drawing.Color.Black;
            this.UserRecords.Location = new System.Drawing.Point(0, 97);
            this.UserRecords.Name = "UserRecords";
            this.UserRecords.Size = new System.Drawing.Size(684, 410);
            this.UserRecords.TabIndex = 17;
            this.UserRecords.TabStop = false;
            this.UserRecords.Text = "Transaction Records";
            this.UserRecords.Enter += new System.EventHandler(this.UserRecords_Enter);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.labelBalance);
            this.panel2.Controls.Add(this.labelExpense);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.labelIncome);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(574, 86);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(104, 318);
            this.panel2.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(6, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Summary";
            // 
            // labelBalance
            // 
            this.labelBalance.AutoSize = true;
            this.labelBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBalance.Location = new System.Drawing.Point(3, 237);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelBalance.Size = new System.Drawing.Size(82, 20);
            this.labelBalance.TabIndex = 5;
            this.labelBalance.Text = "Rs. 00000";
            this.labelBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelExpense
            // 
            this.labelExpense.AutoSize = true;
            this.labelExpense.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelExpense.Location = new System.Drawing.Point(3, 171);
            this.labelExpense.Name = "labelExpense";
            this.labelExpense.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelExpense.Size = new System.Drawing.Size(82, 20);
            this.labelExpense.TabIndex = 4;
            this.labelExpense.Text = "Rs. 00000";
            this.labelExpense.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(3, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Balance";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(3, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Expense";
            // 
            // labelIncome
            // 
            this.labelIncome.AutoSize = true;
            this.labelIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIncome.Location = new System.Drawing.Point(3, 85);
            this.labelIncome.Name = "labelIncome";
            this.labelIncome.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelIncome.Size = new System.Drawing.Size(82, 20);
            this.labelIncome.TabIndex = 1;
            this.labelIncome.Text = "Rs. 00000";
            this.labelIncome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(3, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Income";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(286, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 26);
            this.label1.TabIndex = 30;
            this.label1.Text = "Cashbook";
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.Firebrick;
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.White;
            this.btnReport.Location = new System.Drawing.Point(590, 45);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(77, 35);
            this.btnReport.TabIndex = 29;
            this.btnReport.Text = "Report";
            this.btnReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReport.UseVisualStyleBackColor = false;
            // 
            // GDVCashbook
            // 
            this.GDVCashbook.AllowUserToAddRows = false;
            this.GDVCashbook.AllowUserToDeleteRows = false;
            this.GDVCashbook.AllowUserToResizeRows = false;
            this.GDVCashbook.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GDVCashbook.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GDVCashbook.BackgroundColor = System.Drawing.SystemColors.MenuBar;
            this.GDVCashbook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GDVCashbook.Location = new System.Drawing.Point(6, 86);
            this.GDVCashbook.MultiSelect = false;
            this.GDVCashbook.Name = "GDVCashbook";
            this.GDVCashbook.ReadOnly = true;
            this.GDVCashbook.RowHeadersVisible = false;
            this.GDVCashbook.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GDVCashbook.Size = new System.Drawing.Size(562, 318);
            this.GDVCashbook.TabIndex = 15;
            // 
            // ToDate
            // 
            this.ToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ToDate.Location = new System.Drawing.Point(229, 54);
            this.ToDate.Name = "ToDate";
            this.ToDate.Size = new System.Drawing.Size(127, 26);
            this.ToDate.TabIndex = 26;
            // 
            // FromDate
            // 
            this.FromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FromDate.Location = new System.Drawing.Point(63, 54);
            this.FromDate.Name = "FromDate";
            this.FromDate.Size = new System.Drawing.Size(127, 26);
            this.FromDate.TabIndex = 26;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(196, 59);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(27, 20);
            this.label14.TabIndex = 25;
            this.label14.Text = "To";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(11, 59);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 20);
            this.label13.TabIndex = 25;
            this.label13.Text = "From";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(495, 45);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(89, 35);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "    Reset";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Firebrick;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(400, 44);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 35);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnExpenseForm);
            this.panel1.Controls.Add(this.btnSupplierLedgerForm);
            this.panel1.Controls.Add(this.btnCustomerLedgerForm);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 91);
            this.panel1.TabIndex = 18;
            // 
            // btnExpenseForm
            // 
            this.btnExpenseForm.BackColor = System.Drawing.Color.Teal;
            this.btnExpenseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpenseForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpenseForm.ForeColor = System.Drawing.Color.White;
            this.btnExpenseForm.Location = new System.Drawing.Point(347, 22);
            this.btnExpenseForm.Name = "btnExpenseForm";
            this.btnExpenseForm.Size = new System.Drawing.Size(157, 36);
            this.btnExpenseForm.TabIndex = 3;
            this.btnExpenseForm.Text = "Expense Form";
            this.btnExpenseForm.UseVisualStyleBackColor = false;
            this.btnExpenseForm.Click += new System.EventHandler(this.btnExpenseForm_Click);
            // 
            // btnSupplierLedgerForm
            // 
            this.btnSupplierLedgerForm.BackColor = System.Drawing.Color.Teal;
            this.btnSupplierLedgerForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupplierLedgerForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupplierLedgerForm.ForeColor = System.Drawing.Color.White;
            this.btnSupplierLedgerForm.Location = new System.Drawing.Point(184, 22);
            this.btnSupplierLedgerForm.Name = "btnSupplierLedgerForm";
            this.btnSupplierLedgerForm.Size = new System.Drawing.Size(157, 36);
            this.btnSupplierLedgerForm.TabIndex = 2;
            this.btnSupplierLedgerForm.Text = "Supplier Ledger";
            this.btnSupplierLedgerForm.UseVisualStyleBackColor = false;
            this.btnSupplierLedgerForm.Click += new System.EventHandler(this.btnSupplierLedgerForm_Click);
            // 
            // btnCustomerLedgerForm
            // 
            this.btnCustomerLedgerForm.BackColor = System.Drawing.Color.Teal;
            this.btnCustomerLedgerForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomerLedgerForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomerLedgerForm.ForeColor = System.Drawing.Color.White;
            this.btnCustomerLedgerForm.Location = new System.Drawing.Point(21, 22);
            this.btnCustomerLedgerForm.Name = "btnCustomerLedgerForm";
            this.btnCustomerLedgerForm.Size = new System.Drawing.Size(157, 36);
            this.btnCustomerLedgerForm.TabIndex = 1;
            this.btnCustomerLedgerForm.Text = "Customer Ledger";
            this.btnCustomerLedgerForm.UseVisualStyleBackColor = false;
            this.btnCustomerLedgerForm.Click += new System.EventHandler(this.btnCustomerLedgerForm_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(289, 110);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 35);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(510, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 36);
            this.button1.TabIndex = 4;
            this.button1.Text = "Employee Ledger";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DailySheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 519);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.UserRecords);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DailySheet";
            this.Text = "DailySheet";
            this.UserRecords.ResumeLayout(false);
            this.UserRecords.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GDVCashbook)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox UserRecords;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.DataGridView GDVCashbook;
        private System.Windows.Forms.DateTimePicker ToDate;
        private System.Windows.Forms.DateTimePicker FromDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExpenseForm;
        private System.Windows.Forms.Button btnSupplierLedgerForm;
        private System.Windows.Forms.Button btnCustomerLedgerForm;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelIncome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelExpense;
        private System.Windows.Forms.Label labelBalance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}