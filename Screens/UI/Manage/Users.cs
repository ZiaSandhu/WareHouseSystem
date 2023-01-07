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
using WareHouseSystem.General;

namespace WareHouseSystem.Screens.UI.Manage
{
    public partial class Users : MetroTemplate
    {
        private string UserName { get; set; }
        private string UserID { get; set; }

        public Users()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Valid())
            {
                if (this.UserName == string.Empty || this.UserName == null)
                    InsertValues();
                else
                    UpdateValues();
                //MessageBox.Show("User Inserted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateValues()
        {
            if (RequireFields())
            {
                string query = "Update tblUsers set Name='"+txtUserName.Text.Trim()+"' ,Password='"+txtPassword.Text.Trim()+"' where Id='"+this.UserID+"'";
                if (database.RunQuery(query))
                {
                    MessageBox.Show("User Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetFormControls();
                    PopulateUserGrid();
                }
                else
                {
                    MessageBox.Show("Something Went Wrong \n Plz try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void InsertValues()
        {
            string query="Insert into tblUsers Values('"+txtUserName.Text.Trim()+"','"+txtPassword.Text.Trim()+"')";
            if (database.RunQuery(query))
            {
                MessageBox.Show("User Inserted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetFormControls();
                PopulateUserGrid();
            }
            else
            {
                MessageBox.Show("Something Went Wrong \n Plz try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool Valid()
        {
            if(RequireFields() || !RequireFields())
            {
                if (this.UserName == string.Empty || this.UserName == null)//It means saving new record
                {
                    using (SqlConnection con = new SqlConnection(database.ConnectionString))
                    {
                        string query = "select * from tblUsers where name='" + txtUserName.Text.Trim() + "'";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            if (con.State != ConnectionState.Open)
                                con.Open();

                            SqlDataReader sdr = cmd.ExecuteReader();
                            if (sdr.HasRows)
                            {
                                MessageBox.Show("UserName already Exsist! \n Plz Choose Different Name!", "UserName Exsist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                            else
                                return true;
                        }
                    }
                }
            }
            
            return true;
        }

        private bool RequireFields()
        {
            if (txtUserName.Text == string.Empty)
            {
                MessageBox.Show("UserName is Required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
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

        private void Users_Load(object sender, EventArgs e)
        {
            PopulateUserGrid();
        }

        private void PopulateUserGrid()
        {
            string Query = "Select * from tblUsers";
            database.PopulatGrid(Query, GDVUser);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFormControls();
        }

        private void ResetFormControls()
        {
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            this.UserID = null;
            this.UserName = null;
            btnDelete.Enabled = false;
            btnSave.Text = "Save";

        }

        private void GDVUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (GDVUser.Rows.Count > 0)
            {
                this.UserID = GDVUser.CurrentRow.Cells[0].Value.ToString();
                this.UserName = GDVUser.CurrentRow.Cells[1].Value.ToString();
                txtUserName.Text = GDVUser.CurrentRow.Cells[1].Value.ToString();
                txtPassword.Text = GDVUser.CurrentRow.Cells[2].Value.ToString();

                btnDelete.Enabled = true;
                btnSave.Text = "Update";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (RequireFields())
            {
                string query = "Delete from tblUsers where Id='"+this.UserID+"'";
                if (database.RunQuery(query))
                {
                    MessageBox.Show("User Inserted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetFormControls();
                    PopulateUserGrid();
                }
                else
                {
                    MessageBox.Show("Something Went Wrong \n Plz try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
