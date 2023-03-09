using PingPongManagmantSystem.Desktop.Windows.AdminWindow.AddPanel;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Common.Utils;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Services.AdminService;
using System.Collections.Generic;
using System.Windows;

namespace PingPongManagmantSystem.Desktop.Windows
{
    public partial class CustomerPanel : Window
    {
        ICustomerService customer = new CustomerService();
        int pageSize = 15;
        public CustomerPanel()
        {
            InitializeComponent();
            RefreshDataCustomer();
        }

        public async void RefreshDataCustomer()
        {
            try
            {
                string search = "";
                List<Customer> cutomers = (List<Customer>)await customer.GetAllAsync(search, new PaginationParams(1, pageSize));
                customerDataGrid.ItemsSource = cutomers;
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void Customer_AddButton(object sender, RoutedEventArgs e)
        {
            try
            {
                CustomerAddPanel customerAddPanel = new CustomerAddPanel();
                customerAddPanel.add_btn.IsEnabled = true;
                customerAddPanel.upd_btn.IsEnabled = false;
                this.Close();
                customerAddPanel.ShowDialog();
                RefreshDataCustomer();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void Update_Button(object sender, RoutedEventArgs e)
        {
            try
            {

                CustomerAddPanel customerPanel = new CustomerAddPanel();
                customerPanel.add_btn.IsEnabled = false;
                customerPanel.upd_btn.IsEnabled = true;

                var cutomers = (Customer)customerDataGrid.SelectedItem;
                customerPanel.id.Content = cutomers.Id;
                customerPanel.status.Text = cutomers.Status;
                customerPanel.percest.Text = cutomers.Percent.ToString();
                customerPanel.status.IsEnabled = false;
                this.Close();
                customerPanel.ShowDialog();
                RefreshDataCustomer();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private async void Delete_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = (Customer)customerDataGrid.SelectedItem;
                var result = await customer.DeleteAsync(item.Id);
                if (result)
                {
                    RefreshDataCustomer();
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void Exit_Button(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
