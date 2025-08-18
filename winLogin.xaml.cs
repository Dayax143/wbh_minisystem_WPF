using fortest.Models;
using fortest.Properties; // Assuming Settings.Default.ConnectionString is here
using fortest.Services; // Assuming MyAppContext is in this namespace
using fortest.User;
using System;
using fortest.Lora;
using System.Linq;
using System.Windows;
using System.Windows.Controls; // For PasswordBox

namespace fortest
{
    /// <summary>
    /// Interaction logic for winLogin.xaml
    /// </summary>
    public partial class winLogin : Window
    {
        public winLogin()
        {
            InitializeComponent();
        }

        // This method encapsulates the login logic
        public void LoginFunction(string username, string password)
        {
            try
            {
                // Create a new instance of your DbContext
                using (var context = new MyDbContext())
                {
                    // Attempt to find a user with the provided username and password
                    var user = context.TblUser.FirstOrDefault(u => u.userName == username && u.passWord == password);
                    if (user != null)
                    {
                        Settings.Default.audit_user = user.userName;
                        // User found, proceed with login
                        MessageBox.Show("Login successful!");
                        MainWindow dashboard = new MainWindow();
                        if (user.usertype == "Admin")
                        {
                            this.Hide(); // Hide the current login window
                            dashboard.Show(); // Show the dashboard window
                            this.Close(); // Close the login window (optional, depending on flow)
                        }
                        else if (user.usertype != "Admin")
                        {
                            dashboard.btnManageUsers.Visibility = Visibility.Hidden;
                            this.Hide(); // Hide the current login window
                            dashboard.Show(); // Show the dashboard window
                            this.Close(); // Close the login window (optional, depending on flow)
                        }
                        dashboard.welcomeLabel.Text = $" : {user.fullname}"; // Set welcome message
                        dashboard.Show();
                        // You can redirect to another window or perform other actions here
                    }
                    else
                    {
                        // User not found, show an error message
                        MessageBox.Show("Invalid username or password.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the login process
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Call the login function with text from your UI controls
            // Assuming UsernameTextBox is a TextBox and PasswordBox is a PasswordBox
            LoginFunction(UsernameTextBox.Text, PasswordBox.Password);
        }

        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            RegSignup signup = new RegSignup();
            this.Hide();
            signup.ShowDialog();
            this.Close();
        }

    }
}