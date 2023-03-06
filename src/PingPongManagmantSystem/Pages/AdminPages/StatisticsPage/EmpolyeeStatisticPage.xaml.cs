using PingPongManagmantSystem.Service.Interfaces.AdminIntefaces.StatisticSrvices;
using PingPongManagmantSystem.Service.Services.AdminServices.StatisticServices;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace PingPongManagmantSystem.Desktop.Pages.AdminPages.StatisticsPage
{
    /// <summary>
    /// Interaction logic for EmpolyeeStatisticPage.xaml
    /// </summary>
    public partial class EmpolyeeStatisticPage : Page
    {
        IEmpolyeeStatsiticService empolyeeStatsiticService = new EmpolyeeStatisticService();

        public EmpolyeeStatisticPage()
        {
            InitializeComponent();
            empolyee_Name.IsChecked = true;
            Refresh_EmpolyeeStatistic();
        }

        private async void Refresh_EmpolyeeStatistic()
        {
            try
            {
                var statisticResault = await empolyeeStatsiticService.GetAllEmpolyeeStatistic("");
                empolyeeStatisticDataGrid.ItemsSource = statisticResault;
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
                var statisticResult = await empolyeeStatsiticService.GetAllEmpolyeeStatistic(tb.Text.ToString().ToLower());
                empolyeeStatisticDataGrid.ItemsSource = statisticResult;
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
