using fortest.Models;
using fortest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace fortest.User
{
    /// <summary>
    /// Interaction logic for RegSignup.xaml
    /// </summary>
    public partial class RegSignup : Window
    {
        public RegSignup()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {

            // Perform basic input validation
            if (string.IsNullOrWhiteSpace(FullnameTextBox.Text) ||
                string.IsNullOrWhiteSpace(UsernameTextBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                MessageBox.Show("Please fill out all fields to register a new user.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // Instantiate your database context
                // Replace MyAppContext with your actual Entity Framework or database context class name
                using (var context = new MyDbContext())
                {
                    // Check if the username already exists using FirstOrDefault()
                    var existingUser = context.TblUser.FirstOrDefault(u => u.userName == UsernameTextBox.Text);
                    if (existingUser != null)
                    {
                        MessageBox.Show("This username already exists. Please choose a different one.", "Registration Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    // Create a new user object from the input data
                    var newUser = new TblUser
                    {
                        fullname = FullnameTextBox.Text,
                        userName = UsernameTextBox.Text,
                        usertype = "User",
                        // Note: A real-world application should hash the password before saving!
                        passWord = PasswordBox.Password,
                        userStatus = "Inactive", // Default status for a new user
                        date = DateTime.Now,
                    };

                    // Add the new user to the database and save changes
                    context.TblUser.Add(newUser);
                    context.SaveChanges();

                    MessageBox.Show("New user registered successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Optionally clear the form or close the window after successful registration
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while registering the user: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            winLogin winLogin = new winLogin();
            this.Hide();
            winLogin.Show();
            this.Close();
        }
    }
}
