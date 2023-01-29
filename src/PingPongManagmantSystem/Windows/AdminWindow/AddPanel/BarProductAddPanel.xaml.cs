using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Services;
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
                BarProduct product = new BarProduct();
                product.Name = name.Text;
                product.ArrivalPrice = double.Parse(arrivalPrice.Text);
                product.SalePrice = double.Parse(salePrice.Text);
                product.Count = int.Parse(count.Text);
                await barProductService.CreateAsync(product);
                this.Close();
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
                    BarProduct product = new BarProduct();
                    product.Id = int.Parse(id.Content.ToString());
                    product.Name = name.Text;
                    product.ArrivalPrice = double.Parse(arrivalPrice.Text);
                    product.SalePrice = double.Parse(arrivalPrice.Text);
                    product.Count = int.Parse(count.Text);
                    var res = await  barProductService.UpdateAsync(product);
                    if (res == false)
                    {
                        MessageBox.Show("Error");
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("To'ldirilmagan qator mavjud");
                }

            }
            catch
            { 
            
            }
        }
    }
}
