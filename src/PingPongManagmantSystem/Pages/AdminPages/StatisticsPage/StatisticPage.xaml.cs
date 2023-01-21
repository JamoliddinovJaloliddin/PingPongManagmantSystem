using PingPongManagmantSystem.Desktop.Windows;
using System;
using System.Windows.Controls;

namespace PingPongManagmantSystem.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for StatisticPage.xaml
    /// </summary>
    public partial class StatisticPage : Page
    {
        public StatisticPage()
        {
            InitializeComponent();
        }

        private void BarProductPage(object sender, System.Windows.RoutedEventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel();

            adminPanel.PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/StatisticsPage/BarStatisticPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void SportProductPage(object sender, System.Windows.RoutedEventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel();
            adminPanel.PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/StatisticsPage/SportStatisticPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
