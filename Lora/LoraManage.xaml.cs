using fortest.Services;
using System.Windows;
using System.Windows.Controls;

namespace fortest
{
    /// <summary>
    /// Interaction logic for LoraManage.xaml
    /// </summary>
    public partial class LoraManage : UserControl
    {
        public LoraManage()
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
                var plate = context.tblLora.ToList();
                //var plate = context.TblPlates.ToList();
                if (plate.Count > 0)
                {
                    // If data is found, bind it to the DataGrid
                    dgvLora.ItemsSource = plate;
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
