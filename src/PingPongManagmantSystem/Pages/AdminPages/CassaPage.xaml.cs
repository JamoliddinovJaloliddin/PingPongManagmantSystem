using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Services.AdminService;
using System.Windows;
using System.Windows.Controls;

namespace PingPongManagmantSystem.Desktop.Pages
{
    public partial class CassaPage : Page
    {
        ICassaService cassa = new CassaService();
        public CassaPage()
        {
            InitializeComponent();
            Refresh_Page();
        }

        public async void Refresh_Page()
        {
            try
            {
                var res = await cassa.GetAllAsync();
                cassaDataGrid.ItemsSource = res;
            }
            catch
            { 
            
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
    }
}
