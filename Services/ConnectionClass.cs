using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Oracle.ManagedDataAccess.Client;
using System.Data.Common; // Ensure you have the Oracle.ManagedDataAccess package installed

namespace fortest.Services
{
    public class ConnectionClass
    {
        //string connectionString = Properties.Settings.Default.ConnectionString;

        ////this checks if the app has connection configuration (if yes go to login, else configure the connection)
        // This is the original method to validate a SQL Server connection.
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
                // This catch-all is fine for a simple boolean check,
                // but for production code, you might want to log the specific exception.
                return false; // Connection failed
            }
        }

        // This is the new method to validate an Oracle connection.
        public static bool OracleConnectionIsValid()
        {
            try
            {
                // Retrieve the connection string from application settings.
                string connString = Properties.Settings.Default.ConnectionString;
                if (string.IsNullOrEmpty(connString))
                    return false; // No saved connection

                // Use the OracleConnection class to test the connection string.
                using (OracleConnection con = new OracleConnection(connString))
                {
                    con.Open();
                    return true; // Connection successful
                }
            }
            catch (Exception)
            {
                // If any part of the connection fails, a variety of exceptions can be thrown.
                // The most common is OracleException, but others can occur.
                // We'll just return false here for simplicity.
                return false; // Connection failed
            }
        }

        // AND THIS WORKS FOR BOTH
        public static bool ConnectionIsValid(DbProviderFactory factory, string connectionString)
        {
            // If the factory is null, we can't create a connection.
            if (factory == null)
            {
                return false;
            }

            // Check if the connection string is null or empty.
            if (string.IsNullOrEmpty(connectionString))
            {
                return false;
            }

            try
            {
                // Create a generic DbConnection object using the provided factory.
                using (DbConnection con = factory.CreateConnection())
                {
                    // Set the connection string and attempt to open the connection.
                    con.ConnectionString = connectionString;
                    con.Open();
                    return true; // Connection successful
                }
            }
            catch (Exception)
            {
                // Catch any exception thrown during the connection process.
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
