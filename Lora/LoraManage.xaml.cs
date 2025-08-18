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

        private void loadData()
        {
            // This method should load data from the database into _loraDataCollection
            // For example, using a service to fetch data
            using (var context = new MyDbContext())
            {
                _loraDataCollection = context.tblLora.Where(l=>l.if_deleted!="YES").ToList();
            }
            // Bind the loaded data to the DataGrid or any other UI control
            dgvLora.ItemsSource = _loraDataCollection;
        }

        private List<tblLora> _loraDataCollection = new List<tblLora>();

        public void filterData()
        {

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

        private void dgvLora_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgvLora_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            EditLora editLora = new EditLora();
            if (dgvLora.SelectedItem is tblLora selectedLora)
            {
                editLora.DataContext = selectedLora; // Bind the selected Lora data to the EditLora window
                editLora.txtLora_id.Text = selectedLora.lora_id.ToString();
                editLora.txtSupply.Text = selectedLora.cor_supply;
                editLora.txtRefference.Text = selectedLora.refference;
                editLora.txtSerial.Text = selectedLora.lora_serial;
                editLora.txtRv.Text = selectedLora.receipt_rv;
                editLora.txtNote.Text = selectedLora.note;
                editLora.chbPlate.IsChecked = (selectedLora.plate == "YES");
                editLora.chbStatus.IsChecked = (selectedLora.status=="Taken");
                //editLora.chbPlate.IsChecked = selectedLora.plate;
                //editLora.txtAssignedTo.Text = selectedLora.assigned_to;
                //editLora.txtTakenDate.Text = selectedLora.taken_date?.ToString("yyyy-MM-dd") ?? string.Empty;
                //editLora.txtDate.Text = selectedLora.date?.ToString("yyyy-MM-dd") ?? string.Empty;
                //editLora.txtRefUser.Text = selectedLora.ref_user;

                editLora.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a Lora to edit.");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            loadData();
        }
    }
}