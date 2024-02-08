using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WareHouseSystem.Screens.UI.ledger
{
    public partial class Expenses : MetroTemplate
    {
        public Expenses()
        {
            InitializeComponent();
            CustomizeSetting();
        }

        private void CustomizeSetting()
        {
            listType.SelectedIndex = 0;
            int currentMonth = DateTime.Today.Month;
            listBill.SelectedIndex = 0;
            listMonths.SelectedIndex = currentMonth-1;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        
        private void btnSave_Click(object sender, EventArgs e)
        {

        }

      

        private void listType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listType.SelectedIndex == 0)
            {
                panelBill.Visible = false;
                panelDescription.Visible = true;
                panelMonth.Visible = false;
            }
            if (listType.SelectedIndex == 1)
            {
                panelBill.Visible = true;
                panelDescription.Visible = false ;
                panelMonth.Visible = true;
            }if(listType.SelectedIndex == 2)
            {
                panelBill.Visible = false;
                panelDescription.Visible = false ;
                panelMonth.Visible = true;
            }
        }
    }
}
