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
    /// Interaction logic for PlatesManagement.xaml
    /// </summary>
    public partial class PlatesManagement : UserControl
    {
        public PlatesManagement()
        {
            InitializeComponent();
            // Load data when the UserControl is initialized
            LoadData();
        }

        public void LoadData()
        {
            // This method can be used to load data into the UserControl if needed
            // For example, you can bind data to a DataGrid or ListView here
            MyDbContext context = new MyDbContext();
            try
            {
                // Attempt to retrieve data from the database
                var plate = context.tblPlates.ToList();
                //var plate = context.TblPlates.ToList();
                if (plate.Count > 0)
                {
                    // If data is found, bind it to the DataGrid
                    dgvPlate.ItemsSource = plate;
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
    }
}
