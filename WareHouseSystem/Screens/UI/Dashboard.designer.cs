namespace WareHouseSystem.Screens.UI
{
    partial class Dashboard
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
            this.panelSide = new System.Windows.Forms.Panel();
            this.panelInvoiceSubmenu = new System.Windows.Forms.Panel();
            this.btnViewPurchaseInvoice = new System.Windows.Forms.Button();
            this.btnViewSaleInvoice = new System.Windows.Forms.Button();
            this.btnPurchaseInvoice = new System.Windows.Forms.Button();
            this.btnSaleInvoice = new System.Windows.Forms.Button();
            this.btnInvoices = new System.Windows.Forms.Button();
            this.panelLedger = new System.Windows.Forms.Panel();
            this.btnDailySheet = new System.Windows.Forms.Button();
            this.btnCustomerLedger = new System.Windows.Forms.Button();
            this.btnSupplierLedger = new System.Windows.Forms.Button();
            this.btnEmployeeLedger = new System.Windows.Forms.Button();
            this.btnLedgers = new System.Windows.Forms.Button();
            this.panelManagement = new System.Windows.Forms.Panel();
            this.btnProductList = new System.Windows.Forms.Button();
            this.btnEmployeeList = new System.Windows.Forms.Button();
            this.btnSupplierList = new System.Windows.Forms.Button();
            this.btnCustomerList = new System.Windows.Forms.Button();
            this.btnManagement = new System.Windows.Forms.Button();
            this.btnExpenses = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelClose = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelSide.SuspendLayout();
            this.panelInvoiceSubmenu.SuspendLayout();
            this.panelLedger.SuspendLayout();
            this.panelManagement.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSide
            // 
            this.panelSide.AutoScroll = true;
            this.panelSide.BackColor = System.Drawing.Color.DarkCyan;
            this.panelSide.Controls.Add(this.panelInvoiceSubmenu);
            this.panelSide.Controls.Add(this.btnInvoices);
            this.panelSide.Controls.Add(this.panelLedger);
            this.panelSide.Controls.Add(this.btnLedgers);
            this.panelSide.Controls.Add(this.panelManagement);
            this.panelSide.Controls.Add(this.btnManagement);
            this.panelSide.Controls.Add(this.btnExpenses);
            this.panelSide.Controls.Add(this.panelLogo);
            this.panelSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSide.Location = new System.Drawing.Point(0, 0);
            this.panelSide.Name = "panelSide";
            this.panelSide.Size = new System.Drawing.Size(200, 600);
            this.panelSide.TabIndex = 0;
            // 
            // panelInvoiceSubmenu
            // 
            this.panelInvoiceSubmenu.Controls.Add(this.btnViewPurchaseInvoice);
            this.panelInvoiceSubmenu.Controls.Add(this.btnViewSaleInvoice);
            this.panelInvoiceSubmenu.Controls.Add(this.btnPurchaseInvoice);
            this.panelInvoiceSubmenu.Controls.Add(this.btnSaleInvoice);
            this.panelInvoiceSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInvoiceSubmenu.Location = new System.Drawing.Point(0, 650);
            this.panelInvoiceSubmenu.Name = "panelInvoiceSubmenu";
            this.panelInvoiceSubmenu.Size = new System.Drawing.Size(183, 161);
            this.panelInvoiceSubmenu.TabIndex = 13;
            // 
            // btnViewPurchaseInvoice
            // 
            this.btnViewPurchaseInvoice.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnViewPurchaseInvoice.FlatAppearance.BorderSize = 0;
            this.btnViewPurchaseInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewPurchaseInvoice.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewPurchaseInvoice.ForeColor = System.Drawing.Color.White;
            this.btnViewPurchaseInvoice.Location = new System.Drawing.Point(0, 120);
            this.btnViewPurchaseInvoice.Name = "btnViewPurchaseInvoice";
            this.btnViewPurchaseInvoice.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnViewPurchaseInvoice.Size = new System.Drawing.Size(183, 40);
            this.btnViewPurchaseInvoice.TabIndex = 5;
            this.btnViewPurchaseInvoice.Text = "View Purchase Inv.";
            this.btnViewPurchaseInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewPurchaseInvoice.UseVisualStyleBackColor = true;
            // 
            // btnViewSaleInvoice
            // 
            this.btnViewSaleInvoice.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnViewSaleInvoice.FlatAppearance.BorderSize = 0;
            this.btnViewSaleInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewSaleInvoice.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewSaleInvoice.ForeColor = System.Drawing.Color.White;
            this.btnViewSaleInvoice.Location = new System.Drawing.Point(0, 80);
            this.btnViewSaleInvoice.Name = "btnViewSaleInvoice";
            this.btnViewSaleInvoice.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnViewSaleInvoice.Size = new System.Drawing.Size(183, 40);
            this.btnViewSaleInvoice.TabIndex = 4;
            this.btnViewSaleInvoice.Text = "View Sale Invoice";
            this.btnViewSaleInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewSaleInvoice.UseVisualStyleBackColor = true;
            // 
            // btnPurchaseInvoice
            // 
            this.btnPurchaseInvoice.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPurchaseInvoice.FlatAppearance.BorderSize = 0;
            this.btnPurchaseInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPurchaseInvoice.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPurchaseInvoice.ForeColor = System.Drawing.Color.White;
            this.btnPurchaseInvoice.Location = new System.Drawing.Point(0, 40);
            this.btnPurchaseInvoice.Name = "btnPurchaseInvoice";
            this.btnPurchaseInvoice.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnPurchaseInvoice.Size = new System.Drawing.Size(183, 40);
            this.btnPurchaseInvoice.TabIndex = 3;
            this.btnPurchaseInvoice.Text = "Purchase Invoice";
            this.btnPurchaseInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPurchaseInvoice.UseVisualStyleBackColor = true;
            // 
            // btnSaleInvoice
            // 
            this.btnSaleInvoice.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSaleInvoice.FlatAppearance.BorderSize = 0;
            this.btnSaleInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaleInvoice.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaleInvoice.ForeColor = System.Drawing.Color.White;
            this.btnSaleInvoice.Location = new System.Drawing.Point(0, 0);
            this.btnSaleInvoice.Name = "btnSaleInvoice";
            this.btnSaleInvoice.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnSaleInvoice.Size = new System.Drawing.Size(183, 40);
            this.btnSaleInvoice.TabIndex = 2;
            this.btnSaleInvoice.Text = "Sale Invoice";
            this.btnSaleInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaleInvoice.UseVisualStyleBackColor = true;
            // 
            // btnInvoices
            // 
            this.btnInvoices.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInvoices.FlatAppearance.BorderSize = 0;
            this.btnInvoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvoices.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvoices.ForeColor = System.Drawing.Color.White;
            this.btnInvoices.Location = new System.Drawing.Point(0, 605);
            this.btnInvoices.Name = "btnInvoices";
            this.btnInvoices.Size = new System.Drawing.Size(183, 45);
            this.btnInvoices.TabIndex = 12;
            this.btnInvoices.Text = "Invoices";
            this.btnInvoices.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInvoices.UseVisualStyleBackColor = true;
            // 
            // panelLedger
            // 
            this.panelLedger.Controls.Add(this.btnDailySheet);
            this.panelLedger.Controls.Add(this.btnCustomerLedger);
            this.panelLedger.Controls.Add(this.btnSupplierLedger);
            this.panelLedger.Controls.Add(this.btnEmployeeLedger);
            this.panelLedger.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLedger.Location = new System.Drawing.Point(0, 418);
            this.panelLedger.Name = "panelLedger";
            this.panelLedger.Size = new System.Drawing.Size(183, 187);
            this.panelLedger.TabIndex = 11;
            // 
            // btnDailySheet
            // 
            this.btnDailySheet.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDailySheet.FlatAppearance.BorderSize = 0;
            this.btnDailySheet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDailySheet.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDailySheet.ForeColor = System.Drawing.Color.White;
            this.btnDailySheet.Location = new System.Drawing.Point(0, 129);
            this.btnDailySheet.Name = "btnDailySheet";
            this.btnDailySheet.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnDailySheet.Size = new System.Drawing.Size(183, 45);
            this.btnDailySheet.TabIndex = 7;
            this.btnDailySheet.Text = "Cashbook";
            this.btnDailySheet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDailySheet.UseVisualStyleBackColor = true;
            this.btnDailySheet.Click += new System.EventHandler(this.btnDailySheet_Click);
            // 
            // btnCustomerLedger
            // 
            this.btnCustomerLedger.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCustomerLedger.FlatAppearance.BorderSize = 0;
            this.btnCustomerLedger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomerLedger.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomerLedger.ForeColor = System.Drawing.Color.White;
            this.btnCustomerLedger.Location = new System.Drawing.Point(0, 84);
            this.btnCustomerLedger.Name = "btnCustomerLedger";
            this.btnCustomerLedger.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnCustomerLedger.Size = new System.Drawing.Size(183, 45);
            this.btnCustomerLedger.TabIndex = 5;
            this.btnCustomerLedger.Text = "Customer Ledger";
            this.btnCustomerLedger.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomerLedger.UseVisualStyleBackColor = true;
            this.btnCustomerLedger.Click += new System.EventHandler(this.btnCustomerLedger_Click);
            // 
            // btnSupplierLedger
            // 
            this.btnSupplierLedger.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSupplierLedger.FlatAppearance.BorderSize = 0;
            this.btnSupplierLedger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupplierLedger.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupplierLedger.ForeColor = System.Drawing.Color.White;
            this.btnSupplierLedger.Location = new System.Drawing.Point(0, 45);
            this.btnSupplierLedger.Name = "btnSupplierLedger";
            this.btnSupplierLedger.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnSupplierLedger.Size = new System.Drawing.Size(183, 39);
            this.btnSupplierLedger.TabIndex = 4;
            this.btnSupplierLedger.Text = "Supplier Ledger";
            this.btnSupplierLedger.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSupplierLedger.UseVisualStyleBackColor = true;
            this.btnSupplierLedger.Click += new System.EventHandler(this.btnSupplierLedger_Click);
            // 
            // btnEmployeeLedger
            // 
            this.btnEmployeeLedger.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEmployeeLedger.FlatAppearance.BorderSize = 0;
            this.btnEmployeeLedger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployeeLedger.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployeeLedger.ForeColor = System.Drawing.Color.White;
            this.btnEmployeeLedger.Location = new System.Drawing.Point(0, 0);
            this.btnEmployeeLedger.Name = "btnEmployeeLedger";
            this.btnEmployeeLedger.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnEmployeeLedger.Size = new System.Drawing.Size(183, 45);
            this.btnEmployeeLedger.TabIndex = 3;
            this.btnEmployeeLedger.Text = "Employee Ledger";
            this.btnEmployeeLedger.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployeeLedger.UseVisualStyleBackColor = true;
            this.btnEmployeeLedger.Click += new System.EventHandler(this.btnEmployeeLedger_Click);
            // 
            // btnLedgers
            // 
            this.btnLedgers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLedgers.FlatAppearance.BorderSize = 0;
            this.btnLedgers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLedgers.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLedgers.ForeColor = System.Drawing.Color.White;
            this.btnLedgers.Location = new System.Drawing.Point(0, 373);
            this.btnLedgers.Name = "btnLedgers";
            this.btnLedgers.Size = new System.Drawing.Size(183, 45);
            this.btnLedgers.TabIndex = 10;
            this.btnLedgers.Text = "Ledgers";
            this.btnLedgers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLedgers.UseVisualStyleBackColor = true;
            this.btnLedgers.Click += new System.EventHandler(this.btnLedgers_Click);
            // 
            // panelManagement
            // 
            this.panelManagement.Controls.Add(this.btnProductList);
            this.panelManagement.Controls.Add(this.btnEmployeeList);
            this.panelManagement.Controls.Add(this.btnSupplierList);
            this.panelManagement.Controls.Add(this.btnCustomerList);
            this.panelManagement.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelManagement.Location = new System.Drawing.Point(0, 190);
            this.panelManagement.Name = "panelManagement";
            this.panelManagement.Size = new System.Drawing.Size(183, 183);
            this.panelManagement.TabIndex = 5;
            // 
            // btnProductList
            // 
            this.btnProductList.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProductList.FlatAppearance.BorderSize = 0;
            this.btnProductList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductList.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductList.ForeColor = System.Drawing.Color.White;
            this.btnProductList.Location = new System.Drawing.Point(0, 135);
            this.btnProductList.Name = "btnProductList";
            this.btnProductList.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnProductList.Size = new System.Drawing.Size(183, 45);
            this.btnProductList.TabIndex = 5;
            this.btnProductList.Text = "Product List";
            this.btnProductList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductList.UseVisualStyleBackColor = true;
            this.btnProductList.Click += new System.EventHandler(this.btnProductList_Click);
            // 
            // btnEmployeeList
            // 
            this.btnEmployeeList.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEmployeeList.FlatAppearance.BorderSize = 0;
            this.btnEmployeeList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployeeList.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployeeList.ForeColor = System.Drawing.Color.White;
            this.btnEmployeeList.Location = new System.Drawing.Point(0, 90);
            this.btnEmployeeList.Name = "btnEmployeeList";
            this.btnEmployeeList.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnEmployeeList.Size = new System.Drawing.Size(183, 45);
            this.btnEmployeeList.TabIndex = 4;
            this.btnEmployeeList.Text = "Employee List";
            this.btnEmployeeList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployeeList.UseVisualStyleBackColor = true;
            this.btnEmployeeList.Click += new System.EventHandler(this.btnEmployeeList_Click);
            // 
            // btnSupplierList
            // 
            this.btnSupplierList.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSupplierList.FlatAppearance.BorderSize = 0;
            this.btnSupplierList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupplierList.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupplierList.ForeColor = System.Drawing.Color.White;
            this.btnSupplierList.Location = new System.Drawing.Point(0, 45);
            this.btnSupplierList.Name = "btnSupplierList";
            this.btnSupplierList.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnSupplierList.Size = new System.Drawing.Size(183, 45);
            this.btnSupplierList.TabIndex = 3;
            this.btnSupplierList.Text = "Supplier List";
            this.btnSupplierList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSupplierList.UseVisualStyleBackColor = true;
            this.btnSupplierList.Click += new System.EventHandler(this.btnSupplierList_Click);
            // 
            // btnCustomerList
            // 
            this.btnCustomerList.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCustomerList.FlatAppearance.BorderSize = 0;
            this.btnCustomerList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomerList.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomerList.ForeColor = System.Drawing.Color.White;
            this.btnCustomerList.Location = new System.Drawing.Point(0, 0);
            this.btnCustomerList.Name = "btnCustomerList";
            this.btnCustomerList.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnCustomerList.Size = new System.Drawing.Size(183, 45);
            this.btnCustomerList.TabIndex = 2;
            this.btnCustomerList.Text = "Customer List";
            this.btnCustomerList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomerList.UseVisualStyleBackColor = true;
            this.btnCustomerList.Click += new System.EventHandler(this.btnCustomerList_Click);
            // 
            // btnManagement
            // 
            this.btnManagement.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnManagement.FlatAppearance.BorderSize = 0;
            this.btnManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManagement.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManagement.ForeColor = System.Drawing.Color.White;
            this.btnManagement.Location = new System.Drawing.Point(0, 145);
            this.btnManagement.Name = "btnManagement";
            this.btnManagement.Size = new System.Drawing.Size(183, 45);
            this.btnManagement.TabIndex = 4;
            this.btnManagement.Text = "Management";
            this.btnManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManagement.UseVisualStyleBackColor = true;
            this.btnManagement.Click += new System.EventHandler(this.btnManagement_Click);
            // 
            // btnExpenses
            // 
            this.btnExpenses.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExpenses.FlatAppearance.BorderSize = 0;
            this.btnExpenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpenses.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpenses.ForeColor = System.Drawing.Color.White;
            this.btnExpenses.Location = new System.Drawing.Point(0, 100);
            this.btnExpenses.Name = "btnExpenses";
            this.btnExpenses.Size = new System.Drawing.Size(183, 45);
            this.btnExpenses.TabIndex = 3;
            this.btnExpenses.Text = "Dashboard";
            this.btnExpenses.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExpenses.UseVisualStyleBackColor = true;
            this.btnExpenses.Click += new System.EventHandler(this.btnExpenses_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(183, 100);
            this.panelLogo.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.DarkCyan;
            this.panelTop.Controls.Add(this.labelClose);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelTop.Location = new System.Drawing.Point(200, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(700, 42);
            this.panelTop.TabIndex = 1;
            // 
            // labelClose
            // 
            this.labelClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelClose.AutoSize = true;
            this.labelClose.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClose.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelClose.Location = new System.Drawing.Point(661, 9);
            this.labelClose.Name = "labelClose";
            this.labelClose.Size = new System.Drawing.Size(27, 30);
            this.labelClose.TabIndex = 1;
            this.labelClose.Text = "X";
            this.labelClose.Click += new System.EventHandler(this.labelClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(185, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Pride PVC Pipe";
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(200, 42);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(700, 558);
            this.panelMain.TabIndex = 2;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelSide);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelSide.ResumeLayout(false);
            this.panelInvoiceSubmenu.ResumeLayout(false);
            this.panelLedger.ResumeLayout(false);
            this.panelManagement.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSide;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnLedgers;
        private System.Windows.Forms.Panel panelManagement;
        private System.Windows.Forms.Button btnCustomerList;
        private System.Windows.Forms.Button btnManagement;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelLedger;
        private System.Windows.Forms.Button btnDailySheet;
        private System.Windows.Forms.Button btnCustomerLedger;
        private System.Windows.Forms.Button btnSupplierLedger;
        private System.Windows.Forms.Button btnEmployeeLedger;
        private System.Windows.Forms.Button btnProductList;
        private System.Windows.Forms.Button btnEmployeeList;
        private System.Windows.Forms.Button btnSupplierList;
        private System.Windows.Forms.Button btnExpenses;
        private System.Windows.Forms.Panel panelInvoiceSubmenu;
        private System.Windows.Forms.Button btnViewPurchaseInvoice;
        private System.Windows.Forms.Button btnViewSaleInvoice;
        private System.Windows.Forms.Button btnPurchaseInvoice;
        private System.Windows.Forms.Button btnSaleInvoice;
        private System.Windows.Forms.Button btnInvoices;
    }
}