using PingPongManagmantSystem.Service.Common.Utils;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface.StatisticSrvices;
using PingPongManagmantSystem.Service.Services.AdminServices.StatisticServices;
using PingPongManagmantSystem.Service.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace PingPongManagmantSystem.Desktop.Pages.AdminPages.StatisticsPage
{
    /// <summary>
    /// Interaction logic for StatisticPage.xaml
    /// </summary>
    public partial class StatisticPage : Page
    {
        ITableStatisticService tableStatisticService = new TableStatisticService();
        int pageSize = 1;


        public StatisticPage()
        {
            InitializeComponent();
            Refresh_TableStatistic();
        }

        public async void Refresh_TableStatistic()
        {
            try
            {

                int page = (int)(double)GlobalVariable.Page;

                var statisticResult = await tableStatisticService.GetAllAsync("", new PaginationParams(page, pageSize));
                tableStatisticDataGrid.ItemsSource = statisticResult;
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
                var statisticResult = await tableStatisticService.GetAllAsync(tb.Text.ToString().ToLower(), new PaginationParams(1, pageSize));
                tableStatisticDataGrid.ItemsSource = statisticResult;
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
