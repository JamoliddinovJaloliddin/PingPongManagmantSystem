using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Services.AdminService;
using System.Windows;

#pragma warning disable

namespace PingPongManagmantSystem.Desktop.Windows.AddPanel
{
    public partial class SportProductAddPanel : Window
    {
        ISportProductService sportProductService = new SportProductService();
        public SportProductAddPanel()
        {
            InitializeComponent();
        }

        private async void Add_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                if (name.Text != "" && arrivalPrice.Text != "" && salePrice.Text != "" && count.Text != "")
                {
                    SportProduct sportProduct = new SportProduct();
                    sportProduct.Name = name.Text;
                    sportProduct.ArrivalPrice = double.Parse(arrivalPrice.Text);
                    sportProduct.SalePrice = double.Parse(salePrice.Text);
                    sportProduct.Count = int.Parse(count.Text);
                    var result = await sportProductService.CreateAsync(sportProduct);
                    if (result)
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Bu nomdagi mahsulot mavjud");
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

        private async void Update_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                if (name.Text != "" && arrivalPrice.Text != "" && salePrice.Text != "" && count.Text != "")
                {
                    SportProduct sportProduct = new SportProduct();
                    sportProduct.Id = int.Parse(id.Content.ToString());
                    sportProduct.Name = name.Text;
                    sportProduct.ArrivalPrice = double.Parse(arrivalPrice.Text);
                    sportProduct.SalePrice = double.Parse(salePrice.Text);
                    sportProduct.Count = int.Parse(count.Text.ToString());

                    var result = await sportProductService.UpdateAsync(sportProduct);
                    if (result)
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Bu nomdagi mahsulot mavjud");
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

        private async void Exit_Button(object sender, System.Windows.Input.MouseButtonEventArgs e)
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
