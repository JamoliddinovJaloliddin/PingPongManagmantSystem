using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Services.AdminService;
using PingPongManagmantSystem.Service.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

#pragma warning disable

namespace PingPongManagmantSystem.Desktop.Windows
{
    public partial class AdminPanel : Window
    {
        int count = 1;

        IUserService userService = new UserService();
        ICustomerService customerService = new CustomerService();

        private bool IsMaximized = false;
        int pageSize = 15;



        public AdminPanel()
        {
            InitializeComponent();
            Page();
            Empolyee_But();
        }

        private void Page()
        {
            GlobalVariable.Search = "";
            GlobalVariable.Page = 1;
            GlobalVariable.NextPage = 1;
            GlobalVariable.Next = 0;
            GlobalVariable.Prewiew = 0;
        }

        private async void Empolyee_But()
        {
            Page();
            PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/EmpolyeeUserPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private async void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
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
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private async void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                {
                    this.DragMove();
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private async void SpotProduct_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                Page();
                PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/SportProductPage.xaml", UriKind.RelativeOrAbsolute));

            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private async void BarProduct_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                Page();
                PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/BarProductpage.xaml", UriKind.RelativeOrAbsolute));
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private async void Cassa_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                Page();
                PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/CassaPage.xaml", UriKind.RelativeOrAbsolute));

            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private async void Exit_Button(object sender, RoutedEventArgs e)
        {
            try
            {

                count = 1;
                MainWindow mainWindow = new MainWindow();
                this.Close();
                mainWindow.ShowDialog();

            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private async void PingPongTable_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                Page();
                PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/PingPongTablePage.xaml", UriKind.RelativeOrAbsolute));

            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private async void Card_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                Page();
                PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/CardPage.xaml", UriKind.RelativeOrAbsolute));
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private async void Empolyee_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                Page();
                PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/EmpolyeeUserPage.xaml", UriKind.RelativeOrAbsolute));
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private async void MenuEmpolye_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                Page();
                CustomerPanel customerPanel = new CustomerPanel();
                customerPanel.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private async void MenuTime_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                Page();
                Timepanel timepanel = new Timepanel();
                timepanel.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private async void Table_Button(object sender, RoutedEventArgs e)
        {
            Page();
            PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/StatisticsPage/StatisticPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private async void Bar_Button(object sender, RoutedEventArgs e)
        {
            Page();
            PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/StatisticsPage/BarStatisticPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private async void Sport_Button(object sender, RoutedEventArgs e)
        {
            Page();
            PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/StatisticsPage/SportStatisticPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private async void EmpolyeeStatistic_Button(object sender, RoutedEventArgs e)
        {
            Page();
            PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/StatisticsPage/EmpolyeeStatisticPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}