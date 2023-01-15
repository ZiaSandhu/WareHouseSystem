using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WareHouseSystem.General;

namespace WareHouseSystem.Screens.UI
{
    public partial class Login : MetroTemplate
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (InputValidation())
            {
                CredentialValidaiton();
            }
        }

        private void CredentialValidaiton()
        {
            using(SqlConnection con=new SqlConnection(database.ConnectionString))
            {
                string query = "Select * from tblUsers where Name='"+txtName.Text.Trim()+"' and Password = '"+txtPassword.Text.Trim()+"'";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows) {
                        SaveLoginHistory();
                        ShowDashboard();
                        reader.Close();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect  UserName and Password", "Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ShowDashboard()
        {
            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.SettingLabel(txtName.Text);
            dashboard.Show();
        }

        private void SaveLoginHistory()
        {
            using (SqlConnection con = new SqlConnection(database.ConnectionString))
            {
                string query = "INSERT INTO tblLoginHistory(Name,DataTime) Values('"+txtName.Text.Trim()+"',GetDate())";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private bool InputValidation()
        {
            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("UserName is Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return false;
            }
            if (txtPassword.Text == string.Empty)
            {
                MessageBox.Show("Password is Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return false;
            }
            return true;

        }

        private void checkShowpass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkShowpass.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
                txtPassword.UseSystemPasswordChar = true;
        }
    }
}
