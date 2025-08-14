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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace fortest
{
    /// <summary>
    /// Interaction logic for UserManage.xaml
    /// </summary>
    public partial class UserManage : UserControl
    {
        public UserManage()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            // This method can be used to load data into the UserControl if needed
            // For example, you can bind data to a DataGrid or ListView here
            MyDbContext context = new MyDbContext();
            try
            {
                // Attempt to retrieve data from the database
                var users = context.TblUser.ToList();
                //var plate = context.TblPlates.ToList();
                if (users.Count > 0)
                {
                    // If data is found, bind it to the DataGrid
                    dgvUsers.ItemsSource = users;
                }
                else
                {
                    MessageBox.Show("No Lora data found.");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during data retrieval
                MessageBox.Show($"An error occurred while loading Lora data: {ex.Message}");
                MessageBox.Show(ex.Source);
                MessageBox.Show(ex.Data.ToString());
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
