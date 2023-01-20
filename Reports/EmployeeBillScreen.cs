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
    public partial class EmployeeBillScreen : Form
    {
        public string Name { get; set; }

        public string Date { get; set; }
        public string ReportAddress { get; set; }
        public DataTable ReportDataSet { get; set; }
        public string TotalWeight { get; set; }
        public string Balance { get; set; }
        public string Advance { get; set; }
        public string Total { get; set; }
        public string Rate { get; set; }
        public string InvoiceId { get; set; }

        public EmployeeBillScreen()
        {
            InitializeComponent();
        }

        private void EmployeeBillScreen_Load(object sender, EventArgs e)
        {
            crystalReportViewer1.SelectionMode = CrystalDecisions.Windows.Forms.SelectionMode.None;

            ReportDocument report = new ReportDocument();
            report.Load(ReportAddress);
            report.SetDataSource(ReportDataSet);
            report.SetParameterValue("Name", Name);
            report.SetParameterValue("Date", Date);
            report.SetParameterValue("InvoiceId", InvoiceId);
            report.SetParameterValue("TotalWeight", TotalWeight);
            report.SetParameterValue("Rate", Rate);
            report.SetParameterValue("Total", Total);
            report.SetParameterValue("Advance", Advance);
            report.SetParameterValue("Balance", Balance);
            crystalReportViewer1.ReportSource = report;
        }
    }
}
