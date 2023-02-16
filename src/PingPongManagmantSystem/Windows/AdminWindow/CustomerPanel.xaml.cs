using PingPongManagmantSystem.Desktop.Windows.AdminWindow.AddPanel;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Services.AdminService;
using System.Collections.Generic;
using System.Windows;

namespace PingPongManagmantSystem.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for CustomerPanel.xaml
    /// </summary>
    public partial class CustomerPanel : Window
    {
        ICustomerService customer = new CustomerService();
        public CustomerPanel()
        {
            InitializeComponent();
            RefreshDataCustomer();
        }

        public async void RefreshDataCustomer()
        {
            List<Customer> cutomers = (List<Customer>)await customer.GetAllAsync();
            customerDataGrid.ItemsSource = cutomers;
        }

        private void Customer_AddButton(object sender, RoutedEventArgs e)
        {
            CustomerAddPanel customerAddPanel = new CustomerAddPanel();
            customerAddPanel.add_btn.IsEnabled = true;
            customerAddPanel.upd_btn.IsEnabled = false;
            customerAddPanel.ShowDialog();
            RefreshDataCustomer();
        }

        private void Update_Button(object sender, RoutedEventArgs e)
        {
            CustomerAddPanel customerPanel = new CustomerAddPanel();
            customerPanel.add_btn.IsEnabled = false;
            customerPanel.upd_btn.IsEnabled = true;

            var cutomers = (Customer)customerDataGrid.SelectedItem;
            customerPanel.id.Content = cutomers.Id;
            customerPanel.status.Text = cutomers.Status;
            customerPanel.percest.Text = cutomers.Percent.ToString();
            customerPanel.ShowDialog();
            RefreshDataCustomer();
        }

        private async void Delete_Button(object sender, RoutedEventArgs e)
        {
            var item = (Customer)customerDataGrid.SelectedItem;
            await customer.DeleteAsync(item.Id);
            RefreshDataCustomer();
        }
    }
}
