using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Services;
using System.Reflection.PortableExecutable;
using System.Windows;

namespace PingPongManagmantSystem.Desktop.Windows.AdminWindow.AddPanel
{
    /// <summary>
    /// Interaction logic for CustomerAddPanel.xaml
    /// </summary>
    public partial class CustomerAddPanel : Window
    {
        ICustomerService customerService = new CustomerService();
        public CustomerAddPanel()
        {
            InitializeComponent();
        }

        private async void Add_Btn(object sender, RoutedEventArgs e)
        {
            if (status.Text != null && percest.Text != null)
            {
                Customer customer = new Customer();
                customer.Status = status.Text;
                customer.Percent = float.Parse(percest.Text.ToString());
                await customerService.CreateAsync(customer);
                this.Close();
            }
            else
            {
                MessageBox.Show("To'ldirilmagan qator");
            }
        }

        private async void Upd_Btn(object sender, RoutedEventArgs e)
        {
            if (status.Text != null && percest.Text != null)
            {
                Customer customer = new Customer();
                customer.Id = int.Parse(id.Content.ToString());
                customer.Status = status.Text;
                customer.Percent = float.Parse(percest.Text.ToString());
                await customerService.UpdateAsync(customer);
                this.Close();
            }
            else
            {
                MessageBox.Show("To'ldirilmagan qator");
            }
        }
    }
}
