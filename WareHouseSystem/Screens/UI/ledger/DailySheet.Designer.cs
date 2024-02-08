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
            this.label1 = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.GDVCusLedger = new System.Windows.Forms.DataGridView();
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
            this.UserRecords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GDVCusLedger)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserRecords
            // 
            this.UserRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UserRecords.Controls.Add(this.label1);
            this.UserRecords.Controls.Add(this.btnReport);
            this.UserRecords.Controls.Add(this.GDVCusLedger);
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
            // GDVCusLedger
            // 
            this.GDVCusLedger.AllowUserToAddRows = false;
            this.GDVCusLedger.AllowUserToDeleteRows = false;
            this.GDVCusLedger.AllowUserToResizeRows = false;
            this.GDVCusLedger.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GDVCusLedger.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GDVCusLedger.BackgroundColor = System.Drawing.SystemColors.MenuBar;
            this.GDVCusLedger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GDVCusLedger.Location = new System.Drawing.Point(6, 86);
            this.GDVCusLedger.MultiSelect = false;
            this.GDVCusLedger.Name = "GDVCusLedger";
            this.GDVCusLedger.ReadOnly = true;
            this.GDVCusLedger.RowHeadersVisible = false;
            this.GDVCusLedger.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GDVCusLedger.Size = new System.Drawing.Size(668, 318);
            this.GDVCusLedger.TabIndex = 15;
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
            this.btnExpenseForm.Location = new System.Drawing.Point(368, 24);
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
            this.btnSupplierLedgerForm.Location = new System.Drawing.Point(205, 24);
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
            this.btnCustomerLedgerForm.Location = new System.Drawing.Point(42, 24);
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
            ((System.ComponentModel.ISupportInitialize)(this.GDVCusLedger)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox UserRecords;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.DataGridView GDVCusLedger;
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
    }
}