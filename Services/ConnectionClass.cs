using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace fortest.Services
{
    public class ConnectionClass
    {
        //string connectionString = Properties.Settings.Default.ConnectionString;
              
        ////this checks if the app has connection configuration (if yes go to login, else configure the connection)
        public static bool SqlConnectionIsValid()
        {
            try
            {
                string connString = Properties.Settings.Default.ConnectionString;
                if (string.IsNullOrEmpty(connString))
                    return false; // No saved connection

                using (SqlConnection con = new SqlConnection(connString))
                {
                    con.Open();
                    return true; // Connection successful
                }
            }
            catch (Exception)
            {
                return false; // Connection failed
            }
        }

        //  this function is for creating dynamic connection using application settings, properties
        public void ConfigureConnection(string newConnectionString)
        {
            try
            {
                // if connection is in the resources use this variable value THIS WILL SAVE IN THE RESOURCES
                //Application.Current.Resources["DBConnectionString"] = newConnectionString;

                //else if connection is in the properties.settings use this variable value
                Properties.Settings.Default.ConnectionString = newConnectionString;
                Properties.Settings.Default.Save();
                // Save the connection string to a secure location, e.g., encrypted file or settings

                MessageBox.Show("Connection Established, Test and GO ", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
