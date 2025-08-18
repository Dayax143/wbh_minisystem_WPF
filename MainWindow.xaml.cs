using System.Data.Common;
using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Load the default user control when the window starts
            //LoadContent(new PlatesManagement());
        }

        /// <summary>
        /// A centralized method to clear the main panel and load a new UserControl.
        /// This is a much better approach than duplicating logic in each button's event handler.
        /// </summary>
        /// <param name="content">The UserControl to display in the main panel.</param>
        //private void LoadContent(UserControl content)
        //{
        //    mainGrid.Children.Clear();
        //    Grid.SetRow(content, 1);
        //    Grid.SetColumn(content, 1);
        //    mainGrid.Children.Add(content);
        //}

        /// <summary>
        /// A single, shared event handler for all navigation buttons.
        /// The content to load is determined by the button's tag or a switch statement.
        /// </summary>
        //private void NavButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Button clickedButton = (Button)sender;
        //    string buttonContent = clickedButton.Content.ToString();

        //    switch (buttonContent)
        //    {
        //        case "Dashboard":
        //            LoadContent(new LoraManage());
        //            break;
        //        case "Lora":
        //            LoadContent(new LoraManage());
        //            break;
        //        case "Plates":
        //            LoadContent(new PlatesManagement());
        //            break;
        //        case "Settings":
        //            // LoadContent(new SettingsUserControl());
        //            break;
        //        case "Manage users":
        //            // LoadContent(new ManageUsersUserControl());
        //            break;
        //        case "About":
        //            // LoadContent(new AboutUserControl());
        //            break;
        //        default:
        //            // Handle default case or errors
        //            break;
        //    }
        //}

        private void btnTasks_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var taskControl = new LoraManage();
                Grid.SetRow(taskControl, 1);
                Grid.SetColumn(taskControl, 1);
                mainGrid.Children.Clear(); // Clear previous controls
                mainGrid.Children.Add(taskControl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnManageUsers_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var taskControl = new UserManage();
                Grid.SetRow(taskControl, 1);
                Grid.SetColumn(taskControl, 1);
                mainGrid.Children.Clear(); // Clear previous controls
                mainGrid.Children.Add(taskControl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPlates_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var taskControl = new PlatesManagement();
                Grid.SetRow(taskControl, 1);
                Grid.SetColumn(taskControl, 1);
                mainGrid.Children.Clear(); // Clear previous controls
                mainGrid.Children.Add(taskControl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                winLogin login = new winLogin();
                login.Show();
                this.Close(); // Close the current window
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}