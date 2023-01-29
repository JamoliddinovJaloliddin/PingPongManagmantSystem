using PingPongManagmantSystem.Desktop.Pages;
using PingPongManagmantSystem.Desktop.Windows.AddPanel;
using PingPongManagmantSystem.Desktop.Windows.AdminWindow.AddPanel;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Services;
using PingPongManagmantSystem.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PingPongManagmantSystem.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        int count = 1;
        IUserService userService = new UserService();
        public ObservableCollection<User> cassaDatas = new ObservableCollection<User>();
        public AdminPanel()
        {
            InitializeComponent();
            RefreshDataAsync();
        }

        public async Task RefreshDataAsync()
        {
            List<UserView> user = (List<UserView>)await userService.GetAllAsync();
            userDataGrid.ItemsSource = user;
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

        private async void BarProduct_Button(object sender, RoutedEventArgs e)
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

        private async void UserAdd_Button(object sender, RoutedEventArgs e)
        {
            
            switch (count)
            {
                
                case 1:
                    UserAddPanel userAddPanel = new UserAddPanel();
                    userAddPanel.addBut.IsEnabled = true;
                    userAddPanel.updBut.IsEnabled = false;
                    userAddPanel.ShowDialog();
                    break;
                case 2:
                    SportProductAddPanel sportProductPage = new SportProductAddPanel();
                    sportProductPage.add_btn.IsEnabled = true;
                    sportProductPage.upd_btn.IsEnabled = false;
                    sportProductPage.ShowDialog();
                    break;
                case 3:
                    BarProductAddPanel barProductPage = new BarProductAddPanel();
                    barProductPage.addbtn.IsEnabled = true;
                    barProductPage.updbtn.IsEnabled = false;
                    barProductPage.ShowDialog();
                    break;
                case 6:
                    PingPongTableAddPanel pingPongTableAddPanel = new PingPongTableAddPanel();
                    pingPongTableAddPanel.add_btn.IsEnabled = true;
                    pingPongTableAddPanel.upd_btn.IsEnabled = false;
                    pingPongTableAddPanel.ShowDialog();
                    break;
                default:
                    break;
            }
            if (count == 1)
            {
                await RefreshDataAsync();
            }
            else if (count == 3)
            {
                BarProductpage barProductpage = new BarProductpage();
                barProductpage.RefreshDataBar();
            }

        }

        private async void Add_Button(object sender, RoutedEventArgs e)
        {
            UserAddPanel userAddPanel = new UserAddPanel();

            userAddPanel.addBut.IsEnabled = false;
            userAddPanel.updBut.IsEnabled = true;


            var item = (UserView)userDataGrid.SelectedItem;

            userAddPanel.id.Content = item.Id;
            userAddPanel.name.Text = item.Name;
            userAddPanel.passportinfo.Text = item.Passport;
            userAddPanel.password.Text = item.Password;
            userAddPanel.ShowDialog();
            await RefreshDataAsync();
        }

        private async void Delete_Button(object sender, RoutedEventArgs e)
        {
            var item = (UserView)userDataGrid.SelectedItem;
            int res = item.Id;
            var resault = userService.DeleteAsync(res);
            await RefreshDataAsync();
        }
    }
}