using PingPongManagmantSystem.Service.Interfaces.AdminIntefaces.StatisticSrvices;
using PingPongManagmantSystem.Service.Services.AdminServices.StatisticServices;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PingPongManagmantSystem.Desktop.Pages.AdmiPages.StatisticsPage
{
    public partial class SportStatisticPage : Page
    {
        ISportStatisticService sportStatisticService = new SportStatisticService();

        public SportStatisticPage()
        {
            InitializeComponent();
            sport_Name.IsChecked = true;
            Refresh_SportStatistic();
        }

        private async void Refresh_SportStatistic()
        {
            try
            {
                var statisticResult = await sportStatisticService.GetAllSportStatistic("");
                sportStatisticDataGrid.ItemsSource = statisticResult;
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void Day_Button(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                NavigationService nav = NavigationService.GetNavigationService(this);

                nav.Navigate(new System.Uri("Pages/AdminPages/StatisticsPage/StatisticPage.xaml", UriKind.RelativeOrAbsolute));
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void Bar_Button(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                NavigationService nav = NavigationService.GetNavigationService(this);

                nav.Navigate(new System.Uri("Pages/AdminPages/StatisticsPage/BarStatisticPage.xaml", UriKind.RelativeOrAbsolute));
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void Sport_Button(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                NavigationService nav = NavigationService.GetNavigationService(this);

                nav.Navigate(new System.Uri("Pages/AdminPages/StatisticsPage/SportStatisticPage.xaml", UriKind.RelativeOrAbsolute));
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void Empolyee_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService nav = NavigationService.GetNavigationService(this);

                nav.Navigate(new System.Uri("Pages/AdminPages/StatisticsPage/EmpolyeeStatisticPage.xaml", UriKind.RelativeOrAbsolute));
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
                var statisticResult = await sportStatisticService.GetAllSportStatistic(tb.Text.ToString().ToLower());
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
    }
}
