using fortest.Properties;
using fortest.Services;
using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using System.Data.OleDb;
using System.IO;
using System.Windows;

namespace fortest
{
	/// <summary>
	/// Interaction logic for winConfig.xaml
	/// </summary>
	public partial class winConfig : Window
	{
		public winConfig()
		{
			InitializeComponent();
		}

		private void Continue_Click(object sender, RoutedEventArgs e)
		{
			winLogin window = new winLogin();
			window.Show();
			this.Close();
        }

		private void SaveConfig_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (File.Exists(DbPathBox.Text))
				{
					// For DYNAMIC connection path
					//Settings.Default.ConnectionString = "Datasource =.; ";

					// For static ACCESS connection path
					//string conPath = $"Provider=Microsoft.ACE.OLEDB.12.0; Data source=C:\\Users\\pc\\Desktop\\testC#.accdb; Jet OLEDB:Database Password=123;

					// For dynamic ACCESS connection path
					Settings.Default.ConnectionString = $"Provider = Microsoft.ACE.OLEDB.12.0; Data source={DbPathBox.Text}; Jet OLEDB:Database Password={DbPasswordBox.Password};";
					Settings.Default.Save();
					MessageBox.Show("Configuration saved. Test the connection");
				}
				else
				{
					MessageBox.Show("Please select a valid SQLite database file.");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void TestConnection_Click(object sender, RoutedEventArgs e)
		{

		}

		private void ResetConnection_Click(object sender, RoutedEventArgs e)
		{
			
		}

		private void Browse_Click(object sender, RoutedEventArgs e)
		{

		}

		private void RestoreDb_Click(object sender, RoutedEventArgs e)
		{

		}
        private void EncryptedCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            PasswordPanel.Visibility = Visibility.Visible;
        }

        private void EncryptedCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordPanel.Visibility = Visibility.Collapsed;
        }

        private void btnTestCon_Click(object sender, RoutedEventArgs e)
        {
            // Test the connection using the connection string from settings

            try
            {
                // Create a new connection using the connection string from settings
                using (SqlConnection connection = new SqlConnection(Settings.Default.ConnectionString))
                {
                    connection.Open();
                    MessageBox.Show("Connection successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Connection failed: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
			winLogin login = new winLogin();
            login.Show();
			this.Close();
        }

		ConnectionClass connectionClass = new ConnectionClass();
        private void btnSaveSQLConfig_Click(object sender, RoutedEventArgs e)
		{
			string newConnectionString = $"Data source={txtServerName.Text}; Initial Catalog={txtDatabaseName.Text}; User ID={txtUsername.Text}; Password={txtPassword.Password}; trustservercertificate=true;";
			// Save the connection string to application settings
			connectionClass.ConfigureConnection(newConnectionString);
        }

        private void btnSaveOracleConfig_Click(object sender, RoutedEventArgs e)
        {
            string fullTnsDescriptor = $"(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={txtOracleDataSource.Text})(PORT={txtOraclePort.Text}))(CONNECT_DATA=(SERVICE_NAME={txtOracleDataSource.Text})))";
            string newConnectionString = $"Data Source={fullTnsDescriptor};User ID={txtOracleUsername.Text};Password={txtOraclePassword.Password};";
            connectionClass.ConfigureConnection(newConnectionString);
        }

        private void btnTestOracleCon_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOracleContinue_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
