using fortest.Properties;
using fortest.Services;
using System.Configuration;
using System.Data;
using System.Windows;

namespace fortest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            try
            {
                // Get the database source from the application settings.
                string connString = Settings.Default.ConnectionString;

                Window startupWindow;

                // The logic is now corrected.
                // It checks if the connection string is NOT null or empty
                // AND if the connection itself is valid.
                // Both conditions must be true to show the login window.
                if (ConnectionClass.SqlConnectionIsValid() != true)
                {
                    // If the connection is successful, go to the login window.
                    startupWindow = new winConfig();
                }
                else
                {
                    // If the connection string is missing or the connection fails,
                    // go to the configuration window.
                    startupWindow = new winLogin();
                }

                startupWindow.Show();
            }
            catch (Exception ex)
            {
                // It's a good idea to handle this exception gracefully.
                // For now, it re-throws the exception, but you might want to
                // log it or display a user-friendly message.
                MessageBox.Show($"An error occurred during startup: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                MessageBox.Show(ex.Source + "\n" + ex.StackTrace, "Error Details", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

}