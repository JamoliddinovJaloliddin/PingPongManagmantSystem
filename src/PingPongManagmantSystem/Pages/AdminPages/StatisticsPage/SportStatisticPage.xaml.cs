using PingPongManagmantSystem.Service.Common.Utils;
using PingPongManagmantSystem.Service.Interfaces.AdminIntefaces.StatisticSrvices;
using PingPongManagmantSystem.Service.Services.AdminServices.StatisticServices;
using System.Windows;
using System.Windows.Controls;

namespace PingPongManagmantSystem.Desktop.Pages.AdmiPages.StatisticsPage
{
    public partial class SportStatisticPage : Page
    {
        ISportStatisticService sportStatisticService = new SportStatisticService();
        int pageSize = 15;



        public SportStatisticPage()
        {
            InitializeComponent();
            Refresh_SportStatistic();
        }

        private async void Refresh_SportStatistic()
        {
            try
            {
                var statisticResult = await sportStatisticService.GetAllSportStatistic("", new PaginationParams(1, pageSize));
                sportStatisticDataGrid.ItemsSource = statisticResult;
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
                var statisticResult = await sportStatisticService.GetAllSportStatistic(tb.Text.ToString().ToLower(), new PaginationParams(1, pageSize));
                sportStatisticDataGrid.ItemsSource = statisticResult;
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
