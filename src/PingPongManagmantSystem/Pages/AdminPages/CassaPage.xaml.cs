using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Services.AdminService;
using System.Windows;
using System.Windows.Controls;

namespace PingPongManagmantSystem.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for CassaPage.xaml
    /// </summary>
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
            var res = await cassa.GetAllAsync();
            cassaDataGrid.ItemsSource = res;
        }

        private async void Check_Button(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                var resault = (Cassa)cassaDataGrid.SelectedItem;
                
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void Delete_Button(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {

            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
