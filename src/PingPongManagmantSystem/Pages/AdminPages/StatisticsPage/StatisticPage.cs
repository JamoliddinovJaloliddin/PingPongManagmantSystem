using PingPongManagmantSystem.Service.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace PingPongManagmantSystem.Desktop.Pages
{
    public partial class StatisticPage : Page
    {

        public StatisticPage()
        {
            InitializeComponent();
            day_Name.IsChecked = true;
        }

        private void Day_Button(object sender, RoutedEventArgs e)
        {

        }

        private void Bar_Button(object sender, RoutedEventArgs e)
        {

        }

        private void Sport_Button(object sender, RoutedEventArgs e)
        {
            GlobalVariable.AdminWindow = "sport";
        }
    }
}
