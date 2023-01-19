namespace WareHouseSystem.Screens.UI.View
{
    partial class ViewPurchase
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
            this.components = new System.ComponentModel.Container();
            this.UserRecords = new System.Windows.Forms.GroupBox();
            this.CBdate = new System.Windows.Forms.CheckBox();
            this.CBName = new System.Windows.Forms.CheckBox();
            this.GDVInvoice = new System.Windows.Forms.DataGridView();
            this.ViewReocord = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FilterNameBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ToDate = new System.Windows.Forms.DateTimePicker();
            this.FromDate = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.UserRecords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GDVInvoice)).BeginInit();
            this.ViewReocord.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserRecords
            // 
            this.UserRecords.Controls.Add(this.CBdate);
            this.UserRecords.Controls.Add(this.CBName);
            this.UserRecords.Controls.Add(this.GDVInvoice);
            this.UserRecords.Controls.Add(this.FilterNameBox);
            this.UserRecords.Controls.Add(this.label1);
            this.UserRecords.Controls.Add(this.ToDate);
            this.UserRecords.Controls.Add(this.FromDate);
            this.UserRecords.Controls.Add(this.label14);
            this.UserRecords.Controls.Add(this.label13);
            this.UserRecords.Controls.Add(this.btnRefresh);
            this.UserRecords.Controls.Add(this.btnSearch);
            this.UserRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserRecords.ForeColor = System.Drawing.Color.Black;
            this.UserRecords.Location = new System.Drawing.Point(12, 63);
            this.UserRecords.Name = "UserRecords";
            this.UserRecords.Size = new System.Drawing.Size(824, 481);
            this.UserRecords.TabIndex = 131;
            this.UserRecords.TabStop = false;
            this.UserRecords.Text = "Transaction Records";
            // 
            // CBdate
            // 
            this.CBdate.AutoSize = true;
            this.CBdate.Location = new System.Drawing.Point(372, 27);
            this.CBdate.Name = "CBdate";
            this.CBdate.Size = new System.Drawing.Size(112, 21);
            this.CBdate.TabIndex = 28;
            this.CBdate.Text = "Filter By Date";
            this.CBdate.UseVisualStyleBackColor = true;
            // 
            // CBName
            // 
            this.CBName.AutoSize = true;
            this.CBName.Location = new System.Drawing.Point(372, 65);
            this.CBName.Name = "CBName";
            this.CBName.Size = new System.Drawing.Size(136, 21);
            this.CBName.TabIndex = 28;
            this.CBName.Text = "Filter BY Supplier";
            this.CBName.UseVisualStyleBackColor = true;
            // 
            // GDVInvoice
            // 
            this.GDVInvoice.AllowUserToAddRows = false;
            this.GDVInvoice.AllowUserToDeleteRows = false;
            this.GDVInvoice.AllowUserToResizeRows = false;
            this.GDVInvoice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GDVInvoice.BackgroundColor = System.Drawing.SystemColors.MenuBar;
            this.GDVInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GDVInvoice.ContextMenuStrip = this.ViewReocord;
            this.GDVInvoice.Location = new System.Drawing.Point(6, 106);
            this.GDVInvoice.MultiSelect = false;
            this.GDVInvoice.Name = "GDVInvoice";
            this.GDVInvoice.ReadOnly = true;
            this.GDVInvoice.RowHeadersVisible = false;
            this.GDVInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GDVInvoice.Size = new System.Drawing.Size(812, 369);
            this.GDVInvoice.TabIndex = 15;
            // 
            // ViewReocord
            // 
            this.ViewReocord.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewDetailsToolStripMenuItem});
            this.ViewReocord.Name = "contextMenuStrip1";
            this.ViewReocord.Size = new System.Drawing.Size(193, 26);
            this.ViewReocord.Opening += new System.ComponentModel.CancelEventHandler(this.ViewReocord_Opening);
            // 
            // viewDetailsToolStripMenuItem
            // 
            this.viewDetailsToolStripMenuItem.Name = "viewDetailsToolStripMenuItem";
            this.viewDetailsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.viewDetailsToolStripMenuItem.Text = "View Details or Update";
            this.viewDetailsToolStripMenuItem.Click += new System.EventHandler(this.viewDetailsToolStripMenuItem_Click);
            // 
            // FilterNameBox
            // 
            this.FilterNameBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.FilterNameBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.FilterNameBox.BackColor = System.Drawing.Color.White;
            this.FilterNameBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FilterNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterNameBox.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.FilterNameBox.Location = new System.Drawing.Point(73, 60);
            this.FilterNameBox.Name = "FilterNameBox";
            this.FilterNameBox.Size = new System.Drawing.Size(293, 28);
            this.FilterNameBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(16, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "Name";
            // 
            // ToDate
            // 
            this.ToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ToDate.Location = new System.Drawing.Point(239, 22);
            this.ToDate.Name = "ToDate";
            this.ToDate.Size = new System.Drawing.Size(127, 26);
            this.ToDate.TabIndex = 26;
            // 
            // FromDate
            // 
            this.FromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FromDate.Location = new System.Drawing.Point(73, 22);
            this.FromDate.Name = "FromDate";
            this.FromDate.Size = new System.Drawing.Size(127, 26);
            this.FromDate.TabIndex = 26;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(206, 27);
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
            this.label13.Location = new System.Drawing.Point(21, 27);
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
            this.btnRefresh.Location = new System.Drawing.Point(704, 59);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(114, 35);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "    Reset";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Firebrick;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(704, 21);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(114, 35);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ViewPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 564);
            this.Controls.Add(this.UserRecords);
            this.Name = "ViewPurchase";
            this.Text = "Purchase Invoice Record";
            this.Load += new System.EventHandler(this.ViewPurchase_Load);
            this.UserRecords.ResumeLayout(false);
            this.UserRecords.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GDVInvoice)).EndInit();
            this.ViewReocord.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox UserRecords;
        private System.Windows.Forms.CheckBox CBdate;
        private System.Windows.Forms.CheckBox CBName;
        private System.Windows.Forms.DataGridView GDVInvoice;
        private System.Windows.Forms.ComboBox FilterNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker ToDate;
        private System.Windows.Forms.DateTimePicker FromDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ContextMenuStrip ViewReocord;
        private System.Windows.Forms.ToolStripMenuItem viewDetailsToolStripMenuItem;
    }
}