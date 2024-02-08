using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace WareHouseSystem.General
{
    public class database
    {
        public static string ConnectionString = @"Data Source=DESKTOP-1ULGF16\SQLEXPRESS;Initial Catalog=warehouse;Integrated Security=True";


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

        public static int InsertAndGetId(string query)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    return (int)cmd.ExecuteScalar(); 
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
        public static void DigitValidation(Object sender,KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
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

        public static string FormatAmount(decimal number)
        {
            string suffix = "";
            if (number >= 1000)
            {
                suffix = "K";
                number /= 1000;
            }
            if (number >= 1000)
            {
                suffix = "M";
                number /= 1000;
            }
            if (number >= 1000)
            {
                suffix = "B";
                number /= 1000;
            }

            return $"{number:F2}{suffix}";
        }
        public static decimal CalculateColumnSum(DataGridView dataGridView, string columnName)
        {
            decimal sum = 0;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!row.IsNewRow && row.Cells[columnName].Value != null)
                {
                    decimal cellValue;
                    if (Decimal.TryParse(row.Cells[columnName].Value.ToString(), out cellValue))
                    {
                        sum += cellValue;
                    }
                }
            }
            return sum;
        }

        public static void SetDateTimePickerToFirstDayOfMonth(DateTimePicker dateTimePicker)
        {
            // Get the current date
            DateTime currentDate = DateTime.Today;

            // Set the date to the first day of the current month
            DateTime firstDayOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);

            // Set the value of the DateTimePicker to the first day of the current month
            dateTimePicker.Value = firstDayOfMonth;
        }


    }

}
