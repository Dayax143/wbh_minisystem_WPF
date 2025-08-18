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
