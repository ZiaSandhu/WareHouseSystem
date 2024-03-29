﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.IO;

namespace WareHouseSystem.General
{
    public class database
    {
        public static string ConnectionString = @"Data Source=DESKTOP-4CCDK29;Initial Catalog=ScrapSystem;Integrated Security=True";
        //public static string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ziar4\OneDrive\Documents\WareHouseSystem.mdf;Integrated Security=True;Connect Timeout=30";
        //public static string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Projects\Software C#\WareHouseSystem\WarHouseSystem.mdf;Integrated Security=True";

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

        public static string ScalarQuery(string query)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    return cmd.ExecuteScalar().ToString();
                }
            }
        }
        
        public static void DigitValidWithoutDecimal(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public static void DigitValidation(Object sender,KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        
        public static void LoadComboBox(string query,ComboBox box)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    DataTable dt = new DataTable();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows) { 
                        dt.Load(sdr);
                        box.DataSource = dt;
                        box.DisplayMember = "Name";
                        box.ValueMember = "Id";
                    }
                    else
                    {
                        box.DataSource = null;
                    }
                }
            }
        }
        
        public static void StockAdd(string Pid,string Newstock)
        {
            string query = "select stock from tblProducts where Id="+Pid;
            string stock = ScalarQuery(query);
            stock = (Convert.ToDecimal(stock) + Convert.ToDecimal(Newstock)).ToString();
            query = "Update tblProducts Set Stock=" + stock + " where Id=" + Pid;
            RunQuery(query);
        }

        public static void StockMinus(string Pid,string netweight)
        {
            string query = "select stock from tblProducts where Id=" + Pid;
            string stock = ScalarQuery(query);
            stock = (Convert.ToDecimal(stock) - Convert.ToDecimal(netweight)).ToString();
            query = "Update tblProducts Set Stock=" + stock + " where Id=" + Pid;
            RunQuery(query);
        }

        public static DataTable GetTable(string query)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    if (sdr.HasRows)
                    {
                        dt.Load(sdr);
                        return dt;
                    }
                    else
                        return dt ;
                }
            }
        }
        public static void BackupDatabase()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(currentDirectory, "backup.txt");
            if (File.Exists(filePath))
            {
                string[] path = File.ReadLines(filePath).ToArray();
                string query = "BACKUP DATABASE ScrapSystem TO DISK='" + path[0] + "\\Buisness_Solution " + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".bak'";
                database.RunQuery(query);
                MessageBox.Show("Backuped Successfully","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        //public static int RowsCount(string query)
        //{
        //    using (SqlConnection con = new SqlConnection(ConnectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(query, con))
        //        {
        //            if (con.State != ConnectionState.Open)
        //                con.Open();
        //            SqlDataReader sdr = cmd.ExecuteReader();
        //            if (sdr.HasRows)
        //            {
        //                return sdr.Cast<int>().Count();
        //            }
        //            else
        //                return dt;
        //        }
        //    }
        //}

    }

}
