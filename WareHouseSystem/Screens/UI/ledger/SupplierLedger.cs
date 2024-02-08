using System;
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
    public partial class SupplierLedger : Form
    {
        public SupplierLedger()
        {
            InitializeComponent();
            PopulateGrid();
            LoadComboBox();
            CustomSetting();
        }
        private void CustomSetting()
        {
            database.SetDateTimePickerToFirstDayOfMonth(FromDate);
        }
        private void PopulateGrid()
        {
            string query = "select * from tblSuppliersLedger";
            database.PopulatGrid(query, GDVCusLedger);
        }

        private void LoadComboBox()
        {
            string query = "Select Id,Name from tblCustomers";
            database.LoadComboBox(query, CusNameBox);
            database.LoadComboBox(query, FilterNameBox);
        }
    }
}
