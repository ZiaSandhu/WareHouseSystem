namespace WareHouseSystem.Screens.UI.ledger
{
    partial class Expenses
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.panelMonth = new System.Windows.Forms.Panel();
            this.listMonths = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelDescription = new System.Windows.Forms.Panel();
            this.labelDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.panelBill = new System.Windows.Forms.Panel();
            this.listBill = new System.Windows.Forms.ComboBox();
            this.labelBill = new System.Windows.Forms.Label();
            this.panelDateType = new System.Windows.Forms.Panel();
            this.listType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.datepicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panelMonth.SuspendLayout();
            this.panelDescription.SuspendLayout();
            this.panelBill.SuspendLayout();
            this.panelDateType.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(23, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(311, 371);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(311, 73);
            this.panel2.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Teal;
            this.label3.Location = new System.Drawing.Point(66, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 26);
            this.label3.TabIndex = 38;
            this.label3.Text = "Add Expenses";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panelMonth);
            this.panel3.Controls.Add(this.panelDescription);
            this.panel3.Controls.Add(this.panelBill);
            this.panel3.Controls.Add(this.panelDateType);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 70);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(311, 301);
            this.panel3.TabIndex = 48;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnExit);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.btnSave);
            this.panel5.Controls.Add(this.txtAmount);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 183);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(311, 89);
            this.panel5.TabIndex = 37;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(157, 45);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(89, 40);
            this.btnExit.TabIndex = 46;
            this.btnExit.Text = "Exit";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(28, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.TabIndex = 31;
            this.label7.Text = "Amount";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(62, 45);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 40);
            this.btnSave.TabIndex = 43;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(99, 6);
            this.txtAmount.MaxLength = 18;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(114, 26);
            this.txtAmount.TabIndex = 30;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // panelMonth
            // 
            this.panelMonth.Controls.Add(this.listMonths);
            this.panelMonth.Controls.Add(this.label4);
            this.panelMonth.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMonth.Location = new System.Drawing.Point(0, 149);
            this.panelMonth.Name = "panelMonth";
            this.panelMonth.Size = new System.Drawing.Size(311, 34);
            this.panelMonth.TabIndex = 36;
            // 
            // listMonths
            // 
            this.listMonths.AutoCompleteCustomSource.AddRange(new string[] {
            "January",
            "Feburary",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.listMonths.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.listMonths.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.listMonths.BackColor = System.Drawing.Color.White;
            this.listMonths.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listMonths.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listMonths.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.listMonths.Items.AddRange(new object[] {
            "January",
            "Feburary",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.listMonths.Location = new System.Drawing.Point(99, 3);
            this.listMonths.Name = "listMonths";
            this.listMonths.Size = new System.Drawing.Size(187, 28);
            this.listMonths.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(39, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 36;
            this.label4.Text = "Month";
            // 
            // panelDescription
            // 
            this.panelDescription.Controls.Add(this.labelDescription);
            this.panelDescription.Controls.Add(this.txtDescription);
            this.panelDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDescription.Location = new System.Drawing.Point(0, 113);
            this.panelDescription.Name = "panelDescription";
            this.panelDescription.Size = new System.Drawing.Size(311, 36);
            this.panelDescription.TabIndex = 34;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription.ForeColor = System.Drawing.Color.Black;
            this.labelDescription.Location = new System.Drawing.Point(4, 9);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(89, 20);
            this.labelDescription.TabIndex = 37;
            this.labelDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(99, 6);
            this.txtDescription.MaxLength = 18;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(187, 26);
            this.txtDescription.TabIndex = 36;
            // 
            // panelBill
            // 
            this.panelBill.Controls.Add(this.listBill);
            this.panelBill.Controls.Add(this.labelBill);
            this.panelBill.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBill.Location = new System.Drawing.Point(0, 76);
            this.panelBill.Name = "panelBill";
            this.panelBill.Size = new System.Drawing.Size(311, 37);
            this.panelBill.TabIndex = 33;
            // 
            // listBill
            // 
            this.listBill.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.listBill.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.listBill.BackColor = System.Drawing.Color.White;
            this.listBill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBill.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.listBill.Items.AddRange(new object[] {
            "Water",
            "Electricity",
            "Gas",
            "Internet",
            "TV Fee"});
            this.listBill.Location = new System.Drawing.Point(99, 6);
            this.listBill.Name = "listBill";
            this.listBill.Size = new System.Drawing.Size(187, 28);
            this.listBill.TabIndex = 35;
            // 
            // labelBill
            // 
            this.labelBill.AutoSize = true;
            this.labelBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBill.ForeColor = System.Drawing.Color.Black;
            this.labelBill.Location = new System.Drawing.Point(64, 9);
            this.labelBill.Name = "labelBill";
            this.labelBill.Size = new System.Drawing.Size(29, 20);
            this.labelBill.TabIndex = 34;
            this.labelBill.Text = "Bill";
            // 
            // panelDateType
            // 
            this.panelDateType.Controls.Add(this.listType);
            this.panelDateType.Controls.Add(this.label2);
            this.panelDateType.Controls.Add(this.datepicker);
            this.panelDateType.Controls.Add(this.label1);
            this.panelDateType.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDateType.Location = new System.Drawing.Point(0, 0);
            this.panelDateType.Name = "panelDateType";
            this.panelDateType.Size = new System.Drawing.Size(311, 76);
            this.panelDateType.TabIndex = 32;
            // 
            // listType
            // 
            this.listType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.listType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.listType.BackColor = System.Drawing.Color.White;
            this.listType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listType.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.listType.Items.AddRange(new object[] {
            "Daily Expenses",
            "Utility Bills",
            "Rent"});
            this.listType.Location = new System.Drawing.Point(99, 45);
            this.listType.Name = "listType";
            this.listType.Size = new System.Drawing.Size(187, 28);
            this.listType.TabIndex = 29;
            this.listType.SelectedIndexChanged += new System.EventHandler(this.listType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(50, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "Type";
            // 
            // datepicker
            // 
            this.datepicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datepicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datepicker.Location = new System.Drawing.Point(99, 13);
            this.datepicker.Name = "datepicker";
            this.datepicker.Size = new System.Drawing.Size(145, 26);
            this.datepicker.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(49, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "Date";
            // 
            // Expenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(354, 434);
            this.Controls.Add(this.panel1);
            this.DisplayHeader = false;
            this.Name = "Expenses";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.DropShadow;
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Text = "Expenses";
            this.Theme = MetroFramework.MetroThemeStyle.Light;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Expenses_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panelMonth.ResumeLayout(false);
            this.panelMonth.PerformLayout();
            this.panelDescription.ResumeLayout(false);
            this.panelDescription.PerformLayout();
            this.panelBill.ResumeLayout(false);
            this.panelBill.PerformLayout();
            this.panelDateType.ResumeLayout(false);
            this.panelDateType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox listType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox listBill;
        private System.Windows.Forms.Label labelBill;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker datepicker;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelDescription;
        private System.Windows.Forms.Panel panelBill;
        private System.Windows.Forms.Panel panelDateType;
        private System.Windows.Forms.Panel panelMonth;
        private System.Windows.Forms.ComboBox listMonths;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
    }
}