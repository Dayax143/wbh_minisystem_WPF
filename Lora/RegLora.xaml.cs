using fortest.Models;
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
    /// Interaction logic for RegLora.xaml
    /// </summary>
    public partial class RegLora : Window
    {
        public RegLora()
        {
            InitializeComponent();
            txtRefference.IsEnabled = chbStatus.IsChecked ?? false;
        }

        public void saveEf()
        {
            try
            {
                // Assume select_status() sets the 'status' and 'supply' variables
                string status = chbStatus.IsChecked == true ? "Taken" : "Pending";
                string havePlate = chbStatus.IsChecked == true ? "YES" : "NO";

                if (chbStatus.IsChecked==true && string.IsNullOrEmpty(txtRefference.Text))
                {
                    MessageBox.Show("Please mention the reference person or uncheck the related checkbox", "User mistake");
                }
                else
                {
                    // Use a DbContext instance, typically injected via dependency injection
                    using (var context = new MyDbContext())
                    {
                        var newLora = new tblLora
                        {
                            cor_supply = txtSupply.Text, // Assuming txtSupply is a TextBox for supply input
                            status = status,
                            refference = txtRefference.Text, // Assuming txtRefference is a TextBox for reference input
                            date = DateTime.Now,
                            lora_serial = txtSerial.Text, // Assuming txtSerial is a TextBox for Lora Serial input
                            receipt_rv = txtRv.Text, // Assuming txtRv is a TextBox for receipt RV input
                            note = txtNote.Text // Assuming txtNote is a TextBox for notes input,
                            ,
                            ref_user = Settings.Default.audit_user,
                            if_deleted = "Never", // Assuming this is a default value for new records
                        };
                        // Simplified conditional logic
                        if (chbPlate.IsChecked==true)
                        {
                            newLora.plate = "YES";
                            var newPlate = new TblPlate
                            {
                                quantity = 1,
                                cor_supply = txtSupply.Text,
                                status = status,
                                refference = txtRefference.Text,
                                date = DateTime.Now,
                                note = txtNote.Text // Assuming txtNote is a TextBox for notes input
                                ,
                                ref_user = Settings.Default.audit_user,
                                if_deleted = "Never",
                            };
                            context.tblPlates.Add(newPlate);
                        }
                        else
                        {
                            newLora.plate = "NO";
                        }

                        context.tblLora.Add(newLora);

                        // Save all changes to the database in a single transaction
                        context.SaveChanges();

                        MessageBox.Show("Successfully Inserted");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions gracefully
                MessageBox.Show(ex.Message, "from saving");
                MessageBox.Show(ex.InnerException.ToString());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            saveEf();
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            updateEf();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // for updating lora if DELETED COLUMN to yes if deleted and never if not
            //string status = chbStatus.IsChecked == true ? "Taken" : "Pending";
            //int updatedLoraId = int.Parse(txtLora_id.Text); // Assuming you have a TextBox for Lora ID

            //using (MyDbContext myDbContext = new MyDbContext())
            //{
            //    // Retrieve the existing entity
            //    var lora = myDbContext.tblLora.FirstOrDefault(l => l.lora_id == updatedLoraId);

            //    if (lora != null)
            //    {
            //        // Update properties
            //        lora.if_deleted = "Yes"; 
            //        lora.last_update = DateTime.Now;
            //        myDbContext.SaveChanges();
            //        MessageBox.Show("Lora updated successfully!");
            //        Close(); // Close the window after successful update
            //    }
            //    else
            //    {
            //        MessageBox.Show("Lora record not found.");
            //    }
            //}

            try
            {
                int loraIdToDelete = int.Parse(txtLora_id.Text); // Assuming you have a TextBox for Lora ID

                using (MyDbContext myDbContext = new MyDbContext())
                {
                    // Retrieve the entity to delete
                    var lora = myDbContext.tblLora.FirstOrDefault(l => l.lora_id == loraIdToDelete);

                    if (lora != null)
                    {
                        myDbContext.tblLora.Remove(lora);
                        myDbContext.SaveChanges();
                        MessageBox.Show("Lora deleted successfully!");
                        Close(); // Close the window after successful deletion
                    }
                    else
                    {
                        MessageBox.Show("Lora record not found.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting Lora: {ex.Message}");
            }
        }

        private void chbStatus_Checked(object sender, RoutedEventArgs e)
        {
            txtRefference.IsEnabled = chbStatus.IsChecked ?? false;
        }

        private void chbStatus_Unchecked(object sender, RoutedEventArgs e)
        {
            txtRefference.IsEnabled = chbStatus.IsChecked ?? false;
        }
    }
}
