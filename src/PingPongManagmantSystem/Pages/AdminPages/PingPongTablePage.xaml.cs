using PingPongManagmantSystem.Desktop.Windows.AddPanel;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Services.AdminService;
using System.Windows.Controls;

namespace PingPongManagmantSystem.Desktop.Pages
{
    public partial class PingPongTablePage : Page
    {
        IPingPongTableService pingPongTableService = new PingPongTableService();
        public PingPongTablePage()
        {
            InitializeComponent();
            RefreshDataPing();
        }

        public async void RefreshDataPing()
        {
            try
            {
                var item = await pingPongTableService.GetAllAsync();
                pingPongDataGrid.ItemsSource = item;
            }
            catch
            {

            }
        }

        private async void Update_Button(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                PingPongTableAddPanel pingPongTable = new PingPongTableAddPanel();
                pingPongTable.upd_btn.IsEnabled = true;

                var item = (PingPongTable)pingPongDataGrid.SelectedItem;

                pingPongTable.id.Content = item.Id;
                pingPongTable.status.Text = item.Number.ToString();
                pingPongTable.priceCheap.Text = item.PriceCheap.ToString();
                pingPongTable.priceExpires.Text = item.PriceExpensive.ToString();
                pingPongTable.ShowDialog();
                RefreshDataPing();
            }
            catch
            {

            }
        }

        private async void Delete_Button(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                var item = (PingPongTable)pingPongDataGrid.SelectedItem;
                await pingPongTableService.DeleteAsync(item.Id);
                RefreshDataPing();
            }
            catch
            {

            }
        }
    }
}
