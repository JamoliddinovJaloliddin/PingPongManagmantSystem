using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;
using PingPongManagmantSystem.Service.Services.EmpolyeeService;
using PingPongManagmantSystem.Service.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace PingPongManagmantSystem.Desktop.Windows.EmpolyeeWindow
{
    /// <summary>
    /// Interaction logic for EmpolyeeBarProduct.xaml
    /// </summary>
    public partial class EmpolyeeBarProduct : Window
    {
        IEmpolyeeBarProductService barProductService = new EmpolyeeBarProductService();
        double sumPrice = 0;
        int countNumber = 0;

        public EmpolyeeBarProduct()
        {
            InitializeComponent();
            RefreshDataBar();
        }

        public async Task RefreshDataBar()
        {
            try
            {
                countNumber += 1;
                if (countNumber == 1)
                {
                    List<BarView> item = (List<BarView>)await barProductService.GetAllAsync();
                    empolyeProductDataGrid.ItemsSource = item;
                }
                else
                {

                }
            }
            catch
            {
                MessageBox.Show("Error Bar");
            }
        }

        private async void Sum(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = (BarProduct)empolyeProductDataGrid.SelectedItem;

                MessageBox.Show(item.SalePrice.ToString());
                MessageBox.Show(sumPrice.ToString());
            }
            catch
            {
                MessageBox.Show("Error Button");
            }
        }

        private async void Add_Button(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Button(object sender, RoutedEventArgs e)
        {

        }
    }
}
