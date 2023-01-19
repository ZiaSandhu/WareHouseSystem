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
    public partial class ReportScreen : MetroTemplate
    {
        public string ReportAddress {get; set;}
        public DataTable ReportDataSet { get; set; }
        public string RName { get; set; }
        public ReportScreen()
        {
            InitializeComponent();
        }
        private void ReportScreen_Load(object sender, EventArgs e)
        {
            ReportView.SelectionMode = CrystalDecisions.Windows.Forms.SelectionMode.None;

            ReportDocument report = new ReportDocument();
            report.Load(ReportAddress);
            report.SetDataSource(ReportDataSet);
            report.SetParameterValue("Name", Name);
            ReportView.ReportSource = report;
        }
    }
}
