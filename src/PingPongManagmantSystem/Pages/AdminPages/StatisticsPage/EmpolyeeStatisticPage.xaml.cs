using PingPongManagmantSystem.Service.Common.Utils;
using PingPongManagmantSystem.Service.Interfaces.AdminIntefaces.StatisticSrvices;
using PingPongManagmantSystem.Service.Services.AdminServices.StatisticServices;
using System.Windows;
using System.Windows.Controls;


namespace PingPongManagmantSystem.Desktop.Pages.AdminPages.StatisticsPage
{

    public partial class EmpolyeeStatisticPage : Page
    {
        IEmpolyeeStatsiticService empolyeeStatsiticService = new EmpolyeeStatisticService();
        int pageSize = 15;

        public EmpolyeeStatisticPage()
        {
            InitializeComponent();
            Refresh_EmpolyeeStatistic();
        }

        private async void Refresh_EmpolyeeStatistic()
        {
            try
            {
                var statisticResault = await empolyeeStatsiticService.GetAllEmpolyeeStatistic("", new PaginationParams(1, pageSize));
                empolyeeStatisticDataGrid.ItemsSource = statisticResault;
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
                var statisticResult = await empolyeeStatsiticService.GetAllEmpolyeeStatistic(tb.Text.ToString().ToLower(), new PaginationParams(1, pageSize));
                empolyeeStatisticDataGrid.ItemsSource = statisticResult;
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
