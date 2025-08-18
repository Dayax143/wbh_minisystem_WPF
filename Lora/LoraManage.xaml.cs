using fortest.Lora;
using fortest.Models;
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
        private List<tblLora> _loraDataCollection = new List<tblLora>();

        public void filterData()
        {
            // 1. Initialize the query with the full dataset to avoid NullReferenceException.
            IEnumerable<tblLora> query = _loraDataCollection;

            // --- Apply filters based on user selections ---

            // Filter by ComboBox (cmbFilter1)
            if (cmbFilter1.SelectedItem is ComboBoxItem selectedItem)
            {
                string filterValue = selectedItem.Content.ToString();
                if (!string.IsNullOrEmpty(filterValue))
                {
                    query = query.Where(lora => lora.status == filterValue);
                }
            }

            // Filter by Date Range (dpStartDate and dpEndDate)
            if (dpStartDate.SelectedDate.HasValue && dpEndDate.SelectedDate.HasValue)
            {
                DateTime startDate = dpStartDate.SelectedDate.Value.Date;
                DateTime endDate = dpEndDate.SelectedDate.Value.Date;

                query = query.Where(lora => lora.date >= startDate && lora.date <= endDate);
            }
            else if (dpStartDate.SelectedDate.HasValue)
            {
                DateTime startDate = dpStartDate.SelectedDate.Value.Date;
                query = query.Where(lora => lora.date >= startDate);
            }
            else if (dpEndDate.SelectedDate.HasValue)
            {
                DateTime endDate = dpEndDate.SelectedDate.Value.Date;
                query = query.Where(lora => lora.date <= endDate);
            }

            // Convert the query to a list to check for results
            var filteredData = query.ToList();

            // 2. Check the result count and update visibility
            if (filteredData.Any())
            {
                // Data found: Show the DataGrid, hide the message
                dgvLora.Visibility = Visibility.Visible;
                //txtNoData.Visibility = Visibility.Collapsed;
                dgvLora.ItemsSource = filteredData;
            }
            else
            {
                // No data found: Hide the DataGrid, show the message
                dgvLora.Visibility = Visibility.Collapsed;
                //txtNoData.Visibility = Visibility.Visible;
            }
        }

        // Event handlers for your UI controls
        private void cmbFilter1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // We only call filterData here. It's the central hub for all filtering logic.
            filterData();
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            filterData();
        }

        // Add the other event handlers for your controls, e.g.
        private void btnToday_Click(object sender, RoutedEventArgs e)
        {
            // Example: To filter by today's date
            // You could set the date pickers' values and then call filterData()
            dpStartDate.SelectedDate = DateTime.Today;
            dpEndDate.SelectedDate = DateTime.Today;
            filterData();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            // As the user types, the data is filtered.
            // You may want to add a debounce to avoid frequent updates.
            filterData();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddNewLora_Click(object sender, RoutedEventArgs e)
        {
            RegLora regLora = new RegLora();
            regLora.ShowDialog();
        }
    }
}