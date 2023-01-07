using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace WareHouseSystem.General
{
    public class database
    {
        public static string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ziar4\OneDrive\Documents\WareHouseSystem.mdf;Integrated Security=True;Connect Timeout=30";

        public static void PopulatGrid(string query, DataGridView datagrid)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        DataTable dtUser = new DataTable();
                        dtUser.Load(sdr);
                        datagrid.DataSource = dtUser;
                    }
                    else
                        datagrid.DataSource = null;
                }
            }
        }
        public static bool RunQuery(string query)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    int res=cmd.ExecuteNonQuery();
                    if (res == 0)
                    {
                        return false;
                    }
                    else
                        return true;
                }
            }
        }

        public static void DeleteQuery(string query)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

}
