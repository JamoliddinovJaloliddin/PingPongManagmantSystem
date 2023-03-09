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
                    var result =  await customerService.CreateAsync(customer);
                    if (result)
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Bu nomdagi mijoz mavjud");
                    }
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
                    var res = await customerService.UpdateAsync(customer);
                    if (res)
                    {
                        this.Close();
                        CustomerPanel customerPanel = new CustomerPanel();
                        customerPanel.Show();
                    }
                    else
                    {
                        MessageBox.Show("Bu nomdagi mijoz mavjud");
                    }
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
