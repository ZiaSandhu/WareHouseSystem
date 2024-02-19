using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using WareHouseSystem.General;
using System.ServiceProcess;
namespace WareHouseSystem.Screens.UI
{
    public partial class Login : MetroTemplate
    {
        public Login()
        {
            InitializeComponent();
            checkServerStatus();
           this.Focus();
        }

        private void checkServerStatus()
        {
            string serviceName = "MSSQL$SQLEXPRESS"; // This is the default service name for SQL Server
            ServiceController sc = new ServiceController(serviceName);

            try
            {
                if (sc != null && sc.Status == ServiceControllerStatus.Stopped)
                {
                    sc.Start();
                    lblStatus.Text = "SQL Server is Starting.";

                    sc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(30)); // Wait up to 30 seconds for the service to start
                }

                if (sc.Status == ServiceControllerStatus.Running)
                {
                    btnLogin.Enabled = true;
                }
                else
                {
                    lblStatus.Text = "SQL Server failed to start.";
                    btnLogin.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something Went wrong!", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
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
            //Dashboard dashboard = new Dashboard();
            //dashboard.SettingLabel(txtName.Text);
            //dashboard.Show();
            new Dashboard().Show();
        }

        private void SaveLoginHistory()
        {
            using (SqlConnection con = new SqlConnection(database.ConnectionString))
            {
                DateTime date = DateTime.Now;
                string formattedDateTime = date.ToString("yyyy-MM-dd HH:mm:ss");
                string query = "INSERT INTO tblLoginHistory(Name,Date) Values('"+txtName.Text.Trim()+"','"+ formattedDateTime + "')";
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

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
