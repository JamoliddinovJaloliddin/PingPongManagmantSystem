using PingPongManagmantSystem.Desktop.Windows;
using System;
using System.Windows.Controls;

namespace PingPongManagmantSystem.Desktop.Pages.AdmiPages.StatisticsPage
{
    /// <summary>
    /// Interaction logic for SportStatisticPage.xaml
    /// </summary>
    public partial class SportStatisticPage : Page
    {
        public SportStatisticPage()
        {
            InitializeComponent();
        }

        private void StatisticProductPage(object sender, System.Windows.RoutedEventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel();

            adminPanel.PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/StatisticsPage/StatisticPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void BarProductPage(object sender, System.Windows.RoutedEventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel();

            adminPanel.PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/StatisticsPage/BarStatisticPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
