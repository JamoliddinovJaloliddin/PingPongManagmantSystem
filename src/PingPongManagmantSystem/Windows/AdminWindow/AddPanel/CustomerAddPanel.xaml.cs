using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Services.AdminService;
using System.Windows;

namespace PingPongManagmantSystem.Desktop.Windows.AdminWindow.AddPanel
{
    public partial class CustomerAddPanel : Window
    {
        ICustomerService customerService = new CustomerService();
        public CustomerAddPanel()
        {
            InitializeComponent();
        }

        private async void Add_Btn(object sender, RoutedEventArgs e)
        {
            try
            {
                if (status.Text != "" && percest.Text != "")
                {
                    Customer customer = new Customer();
                    customer.Status = status.Text;
                    customer.Percent = float.Parse(percest.Text.ToString());
                    await customerService.CreateAsync(customer);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ma'lumotlar to'liq kiritilmadi");
                }
            }
            catch
            {
                MessageBox.Show("Ma'lumot noto'g'ri kiritildi");
            }
        }

        private async void Upd_Btn(object sender, RoutedEventArgs e)
        {
            try
            {
                if (status.Text != "" && percest.Text != "")
                {
                    Customer customer = new Customer();
                    customer.Id = int.Parse(id.Content.ToString());
                    customer.Status = status.Text;
                    customer.Percent = float.Parse(percest.Text.ToString());
                    await customerService.UpdateAsync(customer);
                    this.Close();
                    CustomerPanel customerPanel = new CustomerPanel();
                    customerPanel.Show();
                }
                else
                {
                    MessageBox.Show("Ma'lumotlar to'liq kiritilmadi");
                }
            }
            catch
            {
                MessageBox.Show("Ma'lumot noto'g'ri kiritildi");
            }
        }

        private void Exit_Button(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
            CustomerPanel customerPanel = new CustomerPanel();
            customerPanel.Show();
        }
    }
}
