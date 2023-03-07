using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Common.Utils;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Services.AdminService;
using System.Windows;
using System.Windows.Controls;

namespace PingPongManagmantSystem.Desktop.Pages
{
    public partial class CassaPage : Page
    {
        ICassaService cassa = new CassaService();
        int pageSize = 15;
        public CassaPage()
        {
            InitializeComponent();
            Refresh_Page();
        }

        public async void Refresh_Page()
        {
            try
            {
                var res = await cassa.GetAllAsync("", new PaginationParams(1, pageSize));
                cassaDataGrid.ItemsSource = res;
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private async void Check_Button(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                var resault = (Cassa)cassaDataGrid.SelectedItem;
                var check = await cassa.GetByIdAsync(resault.Id);
                MessageBox.Show(check);
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
                var resault = (Cassa)cassaDataGrid.SelectedItem;
                var res = await cassa.DeleteAsync(resault.Id);
                Refresh_Page();
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
                var res = await cassa.GetAllAsync(tb.Text.ToString(), new PaginationParams(1, pageSize));
                cassaDataGrid.ItemsSource = res;
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void UserAdd_Button(object sender, RoutedEventArgs e)
        {

        }

        private void Prewiew_Button(object sender, RoutedEventArgs e)
        {

        }

        private void Next_Button(object sender, RoutedEventArgs e)
        {

        }
    }
}
