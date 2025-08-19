using fortest.Properties;
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

namespace fortest.Lora
{
    /// <summary>
    /// Interaction logic for EditLora.xaml
    /// </summary>
    public partial class EditLora : Window
    {
        public EditLora()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void updateEf()
        {
            // 1. Show a confirmation dialog
            string message = "Are you sure you want to update this record?";
            string title = "Confirmation";

            // 1. Get the status based on the checkbox.
            string status = chbStatus.IsChecked == true ? "Taken" : "Pending";
            string havePlate = chbStatus.IsChecked == true ? "YES" : "NO";

            // Using System.Windows.MessageBox
            var confirm = MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (confirm == MessageBoxResult.Yes)
            {
                try
                {
                    // 2. Instantiate DbContext within a using block for automatic disposal
                    using (var context = new MyDbContext())
                    {
                        // Retrieve the Lora and Plate entities from the database.
                        // Assuming you get the lora_id from a TextBox or a selected item.
                        int loraId = int.Parse(txtLora_id.Text);
                        var loraToUpdate = context.tblLora.Find(loraId);

                        // Assuming 'supply' is retrieved from cmbSupply.
                        string supply = txtSupply.Text;
                        var plateToUpdate = context.tblPlates.FirstOrDefault(p => p.cor_supply == supply);

                        if (loraToUpdate != null)
                        {
                            // 3. Update properties on the tracked entities
                            loraToUpdate.cor_supply = supply;
                            loraToUpdate.status = status; // 'status' is a variable from select_status()
                            loraToUpdate.date = DateTime.Now;
                            loraToUpdate.refference = txtRefference.Text;
                            loraToUpdate.lora_serial = txtSerial.Text;
                            loraToUpdate.receipt_rv = txtRv.Text;
                            loraToUpdate.plate = havePlate; // 'havePlate' is a variable from addPlate()
                            loraToUpdate.note = txtNote.Text;
                            loraToUpdate.ref_user = Settings.Default.audit_user; // Assuming you want to track the user who made the update

                            loraToUpdate.taken_date = DateTime.Now; // Assuming you want to set the taken date when marking as deleted

                            if (plateToUpdate != null)
                            {
                                plateToUpdate.status = status;
                                plateToUpdate.refference = txtRefference.Text;
                                plateToUpdate.date = DateTime.Now;
                                loraToUpdate.ref_user = Settings.Default.audit_user; // Assuming you want to track the user who made the update
                            }

                            // 4. Save changes to the database
                            context.SaveChanges();

                            MessageBox.Show("Successfully Updated", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                            // Optional: Refresh the data in your DataGrid or UI.
                            //load_data();
                        }
                        else
                        {
                            MessageBox.Show("Record not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    MessageBox.Show(ex.Source);
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            updateEf();
        }

        public void delete()
        {
            // 1. Show a confirmation dialog
            string message = "Are you sure you want to update this record?";
            string title = "Confirmation";
            // 1. Get the status based on the checkbox.
            string status = chbStatus.IsChecked == true ? "Taken" : "Pending";
            string havePlate = chbStatus.IsChecked == true ? "YES" : "NO";

            // Using System.Windows.MessageBox
            var confirm = MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (confirm == MessageBoxResult.Yes)
            {
                try
                {
                    // 2. Instantiate DbContext within a using block for automatic disposal
                    using (var context = new MyDbContext())
                    {
                        // Retrieve the Lora and Plate entities from the database.
                        // Assuming you get the lora_id from a TextBox or a selected item.
                        int loraId = int.Parse(txtLora_id.Text);
                        var loraToUpdate = context.tblLora.Find(loraId);

                        // Assuming 'supply' is retrieved from cmbSupply.
                        string supply = txtSupply.Text;
                        var plateToUpdate = context.tblPlates.FirstOrDefault(p => p.cor_supply == supply);

                        if (loraToUpdate != null)
                        {
                            // 3. Update properties on the tracked entities
                            loraToUpdate.cor_supply = supply;
                            loraToUpdate.status = status; // 'status' is a variable from select_status()
                            loraToUpdate.date = DateTime.Now;
                            loraToUpdate.refference = txtRefference.Text;
                            loraToUpdate.lora_serial = txtSerial.Text;
                            loraToUpdate.receipt_rv = txtRv.Text;
                            loraToUpdate.plate = havePlate; // 'havePlate' is a variable from addPlate()
                            loraToUpdate.note = txtNote.Text;
                            loraToUpdate.ref_user = Settings.Default.audit_user; // Assuming you want to track the user who made the update
                            loraToUpdate.if_deleted = "Yes"; // Mark as deleted

                            if (plateToUpdate != null)
                            {
                                plateToUpdate.status = status;
                                plateToUpdate.refference = txtRefference.Text;
                                plateToUpdate.date = DateTime.Now;
                                plateToUpdate.if_deleted = "Yes"; // Mark as deleted
                                plateToUpdate.ref_user = Settings.Default.audit_user; // Assuming you want to track the user who made the update
                            }

                            // 4. Save changes to the database
                            context.SaveChanges();

                            MessageBox.Show("Successfully Updated", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                            // Optional: Refresh the data in your DataGrid or UI.
                            //load_data();
                        }
                        else
                        {
                            MessageBox.Show("Record not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            delete();
        }
    }
}
