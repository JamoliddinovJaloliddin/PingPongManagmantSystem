using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Services.AdminService;
using System.Windows;

namespace PingPongManagmantSystem.Desktop.Windows.AddPanel
{
    public partial class BarProductAddPanel : Window
    {
        IBarProductService barProductService = new BarProductService();
        public BarProductAddPanel()
        {
            InitializeComponent();
        }

        private async void Add_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                if (name.Text != "" && arrivalPrice.Text != "" && salePrice.Text != "" && count.Text != "")
                {
                    BarProduct product = new BarProduct();
                    product.Name = name.Text;
                    product.ArrivalPrice = double.Parse(arrivalPrice.Text);
                    product.SalePrice = double.Parse(salePrice.Text);
                    product.Count = int.Parse(count.Text);
                    await barProductService.CreateAsync(product);
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

        private async void Update_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                if (name.Text != "" && arrivalPrice.Text != "" && salePrice.Text != "" && count.Text != "")
                {
                    BarProduct product = new BarProduct();
                    product.Id = int.Parse(id.Content.ToString());
                    product.Name = name.Text;
                    product.ArrivalPrice = double.Parse(arrivalPrice.Text);
                    product.SalePrice = double.Parse(salePrice.Text);
                    product.Count = int.Parse(count.Text);
                    var res = await barProductService.UpdateAsync(product);
                    if (res == false)
                    {
                        MessageBox.Show("Error");
                    }
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

        private void Exit_Button(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
