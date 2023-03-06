using PingPongManagmantSystem.Desktop.Windows.AddPanel;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Common.Utils;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Services.AdminService;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PingPongManagmantSystem.Desktop.Pages
{
    public partial class SportProductPage : Page
    {
        ISportProductService sportProductService = new SportProductService();
        int pageSize = 15;
        public SportProductPage()
        {
            InitializeComponent();
            RefreshDataSpor();
        }

        public async Task RefreshDataSpor()
        {
            try
            {
                List<SportProduct> sportProduct = (List<SportProduct>)await sportProductService.GetAllAsync("", new PaginationParams(1, pageSize));
                sportrDataGrid.ItemsSource = sportProduct;
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }


        private async void Update_button(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {

                SportProductAddPanel sportProduct = new SportProductAddPanel();
                sportProduct.add_btn.IsEnabled = false;
                sportProduct.upd_btn.IsEnabled = true;

                var item = (SportProduct)sportrDataGrid.SelectedItem;

                sportProduct.id.Content = item.Id;
                sportProduct.name.Text = item.Name;
                sportProduct.arrivalPrice.Text = item.ArrivalPrice.ToString();
                sportProduct.salePrice.Text = item.SalePrice.ToString();
                sportProduct.count.Text = item.Count.ToString();
                sportProduct.ShowDialog();
                await RefreshDataSpor();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private async void Delete_Button(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                var item = (SportProduct)sportrDataGrid.SelectedItem;
                await sportProductService.DeleteAsync(item.Id);
                await RefreshDataSpor();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private async void Search(object sender, TextChangedEventArgs e)
        {
            try
            {
                List<SportProduct> sportProduct = (List<SportProduct>)await sportProductService.GetAllAsync(tb.Text.ToString().ToLower(), new PaginationParams(1, pageSize));
                sportrDataGrid.ItemsSource = sportProduct;
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
