using PingPongManagmantSystem.Desktop.Windows.AddPanel;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Common.Utils;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Services.AdminService;
using System.Windows;
using System.Windows.Controls;

namespace PingPongManagmantSystem.Desktop.Pages
{
    public partial class PingPongTablePage : Page
    {
        IPingPongTableService pingPongTableService = new PingPongTableService();
        int pageSize = 15;
        public PingPongTablePage()
        {
            InitializeComponent();
            RefreshDataPing();
        }

        public async void RefreshDataPing()
        {
            try
            {
                var item = await pingPongTableService.GetAllAsync("", new PaginationParams(1, pageSize));
                pingPongDataGrid.ItemsSource = item;
            }
            catch
            {
                MessageBox.Show("Error");
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
                MessageBox.Show("Error");
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
                MessageBox.Show("Error");
            }
        }

        private async void Search(object sender, TextChangedEventArgs e)
        {
            try
            {
                var item = await pingPongTableService.GetAllAsync(tb.Text.ToString().ToLower(), new PaginationParams(1, pageSize));
                pingPongDataGrid.ItemsSource = item;
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void UserAdd_Button(object sender, RoutedEventArgs e)
        {

        }

        private void Next_Button(object sender, RoutedEventArgs e)
        {

        }

        private void Prewiew_Button(object sender, RoutedEventArgs e)
        {

        }
    }
}
