using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WareHouseSystem.Reports
{
    public partial class InvoiceReportScreen : MetroTemplate
    {
        public DataTable ReportDataSet { get; set; }
        public string PName { get; set; }
        public string ReportAddress { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceId { get; set; }
        public InvoiceReportScreen()
        {
            InitializeComponent();
        }

        private void InvoiceReportScreen_Load(object sender, EventArgs e)
        {
            crystalReportViewer1.SelectionMode = CrystalDecisions.Windows.Forms.SelectionMode.None;

            ReportDocument report = new ReportDocument();
            report.Load(ReportAddress);
            report.SetDataSource(ReportDataSet);
            report.SetParameterValue("Name", PName);
            report.SetParameterValue("Date", InvoiceDate);
            report.SetParameterValue("InvoiceId", InvoiceId);
            crystalReportViewer1.ReportSource = report;
        }
    }
}
