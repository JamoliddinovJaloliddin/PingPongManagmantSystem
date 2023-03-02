using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Services.AdminService;
using System.Windows;
using System.Windows.Controls;

namespace PingPongManagmantSystem.Desktop.Pages.AdminPages.StatisticsPage
{
    public partial class CardPage : Page
    {
        ICardAdminService cardService = new CardAdminService();
        public CardPage()
        {
            InitializeComponent();
            Refresh_DataGrid();
        }

        private async void Refresh_DataGrid()
        {
            try
            {
                var cards = await cardService.GetAllAsync("");
                cardDataGrid.ItemsSource = cards;
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
                var cards = await cardService.GetAllAsync(tb.Text.ToString().ToLower());
                cardDataGrid.ItemsSource = cards;
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private async void Delete_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                var card = cardDataGrid.SelectedItem as Card;
                var resault = await cardService.DeleteAsync(card.Id);
                Refresh_DataGrid();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
