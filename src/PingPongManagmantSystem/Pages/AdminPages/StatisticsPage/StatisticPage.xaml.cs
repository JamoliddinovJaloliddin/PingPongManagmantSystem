using PingPongManagmantSystem.Service.Interfaces.AdminInteface.StatisticSrvices;
using PingPongManagmantSystem.Service.Services.AdminServices.StatisticServices;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PingPongManagmantSystem.Desktop.Pages.AdminPages.StatisticsPage
{
    /// <summary>
    /// Interaction logic for StatisticPage.xaml
    /// </summary>
    public partial class StatisticPage : Page
    {
        ITableStatisticService tableStatisticService = new TableStatisticService();

        public StatisticPage()
        {
            InitializeComponent();
            day_Name.IsChecked = true;
            Refresh_TableStatistic();
        }


        private async void Refresh_TableStatistic()
        {
            try
            {
                var statisticResult = await tableStatisticService.GetAllAsync("");
                tableStatisticDataGrid.ItemsSource = statisticResult;
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }


        private void Day_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService nav = NavigationService.GetNavigationService(this);
                day_Name.IsChecked = true;
                nav.Navigate(new System.Uri("Pages/AdminPages/StatisticsPage/StatisticPage.xaml", UriKind.RelativeOrAbsolute));
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void Bar_Button(object sender, RoutedEventArgs e)
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

        private void Sport_Button(object sender, RoutedEventArgs e)
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
                var statisticResult = await tableStatisticService.GetAllAsync(tb.Text.ToString().ToLower());
                tableStatisticDataGrid.ItemsSource = statisticResult;
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
