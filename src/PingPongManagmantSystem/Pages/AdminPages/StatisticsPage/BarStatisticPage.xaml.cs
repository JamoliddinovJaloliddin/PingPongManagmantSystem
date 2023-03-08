using PingPongManagmantSystem.Service.Common.Utils;
using PingPongManagmantSystem.Service.Interfaces.AdminIntefaces.StatisticSrvices;
using PingPongManagmantSystem.Service.Services.AdminServices.StatisticServices;
using System.Windows;
using System.Windows.Controls;

namespace PingPongManagmantSystem.Desktop.Pages.AdmiPages.StatisticsPage
{


    public partial class BarStatisticPage : Page
    {
        IBarStatisticService barStatisticService = new BarStatisticService();
        int pageSize = 15;
        public BarStatisticPage()
        {
            InitializeComponent();
            Refresh_BarStatistic();
        }


        private async void Refresh_BarStatistic()
        {
            try
            {
                var statisticResult = await barStatisticService.GetAllBarStatistic("", new PaginationParams(1, pageSize));
                barStatisticDataGrid.ItemsSource = statisticResult;
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
                var statisticResult = await barStatisticService.GetAllBarStatistic(tb.Text.ToString().ToLower(), new PaginationParams(1, pageSize));
                barStatisticDataGrid.ItemsSource = statisticResult;
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void Check_Button(object sender, RoutedEventArgs e)
        {

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
