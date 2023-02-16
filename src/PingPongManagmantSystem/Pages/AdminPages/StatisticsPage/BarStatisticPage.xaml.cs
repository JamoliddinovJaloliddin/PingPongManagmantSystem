using PingPongManagmantSystem.Desktop.Windows;
using System;
using System.Windows.Controls;

namespace PingPongManagmantSystem.Desktop.Pages.AdmiPages.StatisticsPage
{
    /// <summary>
    /// Interaction logic for BarStatisticPage.xaml
    /// </summary>
    public partial class BarStatisticPage : Page
    {
        public BarStatisticPage()
        {
            InitializeComponent();
        }

        private void SportPage(object sender, System.Windows.RoutedEventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel();
            adminPanel.PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/StatisticsPage/SportStatisticPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void StatisticPage(object sender, System.Windows.RoutedEventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel();

            adminPanel.PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/StatisticsPage/BarStatisticPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
