using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Services;
using System.Windows;

namespace PingPongManagmantSystem.Desktop.Windows.AddPanel
{
    /// <summary>
    /// Interaction logic for SportProductAddPanel.xaml
    /// </summary>
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
                if (name.Text != null && arrivalPrice.Text != null && salePrice.Text != null && count.Text != null)
                {
                    SportProduct sportProduct = new SportProduct();
                    sportProduct.Name = name.Text;
                    sportProduct.ArrivalPrice = double.Parse(arrivalPrice.Text);
                    sportProduct.SalePrice = double.Parse(salePrice.Text);
                    sportProduct.Count = int.Parse(count.Text);
                    await sportProductService.CreateAsync(sportProduct);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("To'ldirilmagan qator");
                }
            }
            catch
            { 
            
            }
        }

        private async void Update_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                if (name.Text != null && arrivalPrice.Text != null && salePrice.Text != null && count.Text != null)
                {
                    SportProduct sportProduct = new SportProduct();
                    sportProduct.Id = int.Parse(id.Content.ToString());
                    sportProduct.Name = name.Text;
                    sportProduct.ArrivalPrice = double.Parse(arrivalPrice.Text);
                    sportProduct.SalePrice = double.Parse(salePrice.Text);
                    sportProduct.Count = int.Parse(count.Text.ToString());
                    await sportProductService.UpdateAsync(sportProduct);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("To'ldirilmagan qator");
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
