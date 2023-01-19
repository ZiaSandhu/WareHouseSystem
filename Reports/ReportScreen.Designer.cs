namespace WareHouseSystem.Reports
{
    partial class ReportScreen
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
            this.ReportView = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // ReportView
            // 
            this.ReportView.ActiveViewIndex = -1;
            this.ReportView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReportView.Cursor = System.Windows.Forms.Cursors.Default;
            this.ReportView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportView.Location = new System.Drawing.Point(20, 60);
            this.ReportView.Name = "ReportView";
            this.ReportView.ShowCloseButton = false;
            this.ReportView.ShowCopyButton = false;
            this.ReportView.ShowGotoPageButton = false;
            this.ReportView.ShowGroupTreeButton = false;
            this.ReportView.ShowLogo = false;
            this.ReportView.ShowPageNavigateButtons = false;
            this.ReportView.ShowParameterPanelButton = false;
            this.ReportView.ShowRefreshButton = false;
            this.ReportView.ShowTextSearchButton = false;
            this.ReportView.Size = new System.Drawing.Size(760, 370);
            this.ReportView.TabIndex = 0;
            this.ReportView.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // ReportScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ReportView);
            this.Name = "ReportScreen";
            this.Text = "ReportScreen";
            this.Load += new System.EventHandler(this.ReportScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer ReportView;
    }
}