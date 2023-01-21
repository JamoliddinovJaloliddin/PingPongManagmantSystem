using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using PingPongManagmantSystem.Desktop.Windows.AdminWindow.AddPanel;
using PingPongManagmantSystem.Desktop.Pages;
using PingPongManagmantSystem.Desktop.Windows.AddPanel;

namespace PingPongManagmantSystem.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        int count = 1;
        public AdminPanel()
        {
            InitializeComponent();
        }


        private bool IsMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;

                    IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    IsMaximized = true;
                }
            }
        }



        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void SpotProduct_Button(object sender, RoutedEventArgs e)
        {
            count = 2;
            PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/SportProductPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void BarProduct_Button(object sender, RoutedEventArgs e)
        {
            count = 3;
            PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/BarProductpage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Statistik_Button(object sender, RoutedEventArgs e)
        {
            count = 4;
            PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/StatisticsPage/StatisticPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Cassa_Button(object sender, RoutedEventArgs e)
        {
            count = 5;
            PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/CassaPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            count = 1;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
           
        }

        private void PingPongTable_Button(object sender, RoutedEventArgs e)
        {
            count = 6;
            PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/PingPongTablePage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Empolyee_Button(object sender, RoutedEventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel();
            adminPanel.Show();
            this.Close();

        }

        private void MenuEmpolye_Button(object sender, RoutedEventArgs e)
        {
            CustomerPanel customerPanel = new CustomerPanel();
            customerPanel.Show();
        }

        private void MenuTime_Button(object sender, RoutedEventArgs e)
        {
            Timepanel timepanel = new Timepanel();
            timepanel.Show();
        }

        private void UserAdd_Button(object sender, RoutedEventArgs e)
        {
            switch (count) { 
                case 1:
                    UserAddPanel userAddPanel = new UserAddPanel();
                    userAddPanel.Show();
                    break;
                case 2:
                    SportProductAddPanel sportProductPage = new SportProductAddPanel();
                    sportProductPage.Show();
                    break;
                case 3:
                    BarProductAddPanel barProductPage = new BarProductAddPanel();
                    barProductPage.Show();
                    break;
                case 6:
                    PingPongTableAddPanel pingPongTableAddPanel = new PingPongTableAddPanel();
                    pingPongTableAddPanel.Show();
                    break;
                default:
                    break;
            }



        }
    }
}
