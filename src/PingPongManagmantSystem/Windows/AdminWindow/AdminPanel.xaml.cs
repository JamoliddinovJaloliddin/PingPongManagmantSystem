using PingPongManagmantSystem.Desktop.Pages.AdminPages.StatisticsPage;
using PingPongManagmantSystem.Desktop.Windows.AddPanel;
using PingPongManagmantSystem.Desktop.Windows.AdminWindow.AddPanel;
using PingPongManagmantSystem.Service.Common.Utils;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Services.AdminService;
using PingPongManagmantSystem.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace PingPongManagmantSystem.Desktop.Windows
{
    public partial class AdminPanel : Window
    {
        int count = 1;

        IUserService userService = new UserService();
        ICustomerService customerService = new CustomerService();
   
        private bool IsMaximized = false;
        int pageSize = 15;
        int pagination = 1;
        
        

        public AdminPanel()
        {
            //GlobalVariable.Page = 1;
            InitializeComponent();
            //RefreshDataAsync();
            Empolyee_But();
           
        }

        private async void Empolyee_But()
        {
            PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/EmpolyeeUserPage.xaml", UriKind.RelativeOrAbsolute));
        }

        public async void RefreshDataAsync()
        {


            //try
            //{
            //    List<UserView> user = (List<UserView>)await userService.GetAllAsync("", new PaginationParams(1, pageSize));
            //    userDataGrid.ItemsSource = user;
            //}
            //catch
            //{
            //    MessageBox.Show("Error");
            //}
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
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

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
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

        private void SpotProduct_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                count = 2;
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
                count = 3;
                PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/BarProductpage.xaml", UriKind.RelativeOrAbsolute));
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void Statistik_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                count = 4;
                PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/StatisticsPage/StatisticPage.xaml", UriKind.RelativeOrAbsolute));
                

              
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void Cassa_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                count = 5;
                PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/CassaPage.xaml", UriKind.RelativeOrAbsolute));
                
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void Exit_Button(object sender, RoutedEventArgs e)
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

        private void PingPongTable_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                count = 6;
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
                count = 7;
                PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/CardPage.xaml", UriKind.RelativeOrAbsolute));
               
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
                PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/EmpolyeeUserPage.xaml", UriKind.RelativeOrAbsolute));
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void MenuEmpolye_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                CustomerPanel customerPanel = new CustomerPanel();
                customerPanel.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void MenuTime_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                Timepanel timepanel = new Timepanel();
                timepanel.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        //private async void UserAdd_Button(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        switch (count)
        //        {
        //            case 1:
        //                UserAddPanel userAddPanel = new UserAddPanel();
        //                userAddPanel.addBut.IsEnabled = true;
        //                userAddPanel.updBut.IsEnabled = false;
        //                userAddPanel.ShowDialog();
        //                break;
        //            case 2:
        //                SportProductAddPanel sportProductPage = new SportProductAddPanel();
        //                sportProductPage.add_btn.IsEnabled = true;
        //                sportProductPage.upd_btn.IsEnabled = false;
        //                sportProductPage.ShowDialog();
        //                break;
        //            case 3:
        //                BarProductAddPanel barProductPage = new BarProductAddPanel();
        //                barProductPage.addbtn.IsEnabled = true;
        //                barProductPage.updbtn.IsEnabled = false;
        //                barProductPage.ShowDialog();
        //                break;
        //            case 6:

        //                break;
        //            default:
        //                break;
        //        }
        //        if (count == 1)
        //        {
        //            RefreshDataAsync();
        //        }
        //        else if (count == 2)
        //        {

        //        }
        //        else if (count == 3)
        //        {

        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Error");
        //    }

        //}

        //private void Add_Button(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        UserAddPanel userAddPanel = new UserAddPanel();

        //        userAddPanel.addBut.IsEnabled = false;
        //        userAddPanel.updBut.IsEnabled = true;
        //        var item = (UserView)userDataGrid.SelectedItem;

        //        userAddPanel.id.Content = item.Id;
        //        userAddPanel.name.Text = item.Name;
        //        userAddPanel.passportinfo.Text = item.Passport;
        //        userAddPanel.password.Text = item.Password;
        //        userAddPanel.ShowDialog();
        //        RefreshDataAsync();
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Error");
        //    }
        //}

        //private void Delete_Button(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        var item = (UserView)userDataGrid.SelectedItem;
        //        int res = item.Id;
        //        var resault = userService.DeleteAsync(res);
        //        RefreshDataAsync();
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Error");
        //    }
        //}


        //private async void Search(object sender, System.Windows.Controls.TextChangedEventArgs e)
        //{
        //    try
        //    {
        //        List<UserView> user = (List<UserView>)await userService.GetAllAsync(tb.Text.ToString(), new PaginationParams(1, pageSize));
        //        userDataGrid.ItemsSource = user;
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Error");
        //    }
        //}

        //private void Prewiew_Button(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        if (pagination != 1)
        //        {
        //            pagination--;
        //            Refresh_PreviewButton();
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Error");
        //    }
        //}

        //private void Next_Button(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        if (pagination < GlobalVariable.Pagination)
        //        {
        //            pagination++;
        //            Refresh_NextButton();
        //            PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/StatisticsPage/StatisticPage.xaml", UriKind.RelativeOrAbsolute));
                 
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Error");
        //    }
        //}

        //private async void Refresh_NextButton()
        //{
        //    try
        //    {
             
        //        BrushConverter brushConverter = new BrushConverter();

              

        //        if (pagination < GlobalVariable.Pagination)
        //        {
        //            button1_Name.Content = pagination - 1;
        //            button1_Name.Background = new SolidColorBrush(Colors.White);
        //            button1_Name.Foreground = brushConverter.ConvertFromString("#6c7682") as SolidColorBrush;
        //            button2_Name.Content = pagination;
        //            button2_Name.Background = brushConverter.ConvertFromString("#7950f2") as SolidColorBrush;
        //            button2_Name.Foreground = new SolidColorBrush(Colors.White);
        //            button3_Name.Content = pagination + 1;
        //            button3_Name.Background = new SolidColorBrush(Colors.White);
        //            button3_Name.Foreground = brushConverter.ConvertFromString("#6c7682") as SolidColorBrush;
        //            GlobalVariable.Page = pagination;
        //            PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/StatisticsPage/StatisticPage.xaml", UriKind.RelativeOrAbsolute));

        //        }
        //        else if (pagination == GlobalVariable.Pagination)
        //        {
        //            button1_Name.Content = pagination - 2;
        //            button1_Name.Background = new SolidColorBrush(Colors.White);
        //            button1_Name.Foreground = brushConverter.ConvertFromString("#6c7682") as SolidColorBrush;
        //            button2_Name.Content = pagination - 1;
        //            button2_Name.Background = new SolidColorBrush(Colors.White);
        //            button2_Name.Foreground = brushConverter.ConvertFromString("#6c7682") as SolidColorBrush;
        //            button3_Name.Content = pagination;
        //            button3_Name.Background = brushConverter.ConvertFromString("#7950f2") as SolidColorBrush;
        //            button3_Name.Foreground = new SolidColorBrush(Colors.White);
        //            GlobalVariable.Page = pagination;
        //            PagesNavigation.Navigate(new System.Uri("Pages/AdminPages/StatisticsPage/StatisticPage.xaml", UriKind.RelativeOrAbsolute));
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Error");
        //    }
        //}

        //private async void Refresh_PreviewButton()
        //{
        //    try
        //    {
        //        BrushConverter brushConverter = new BrushConverter();
            

        //        if (pagination > 1)
        //        {
        //            button1_Name.Content = pagination - 1;
        //            button1_Name.Background = new SolidColorBrush(Colors.White);
        //            button1_Name.Foreground = brushConverter.ConvertFromString("#6c7682") as SolidColorBrush;
        //            button2_Name.Content = pagination;
        //            button2_Name.Background = brushConverter.ConvertFromString("#7950f2") as SolidColorBrush;
        //            button2_Name.Foreground = new SolidColorBrush(Colors.White);
        //            button3_Name.Content = pagination + 1;
        //            button3_Name.Background = new SolidColorBrush(Colors.White);
        //            button3_Name.Foreground = brushConverter.ConvertFromString("#6c7682") as SolidColorBrush;
        //            GlobalVariable.Pagination = pagination;
                 
        //        }
        //        else if (pagination == 1)
        //        {
        //            button1_Name.Content = pagination;
        //            button1_Name.Background = brushConverter.ConvertFromString("#7950f2") as SolidColorBrush;
        //            button1_Name.Foreground = new SolidColorBrush(Colors.White);
        //            button2_Name.Content = pagination + 1;
        //            button2_Name.Background = new SolidColorBrush(Colors.White);
        //            button2_Name.Foreground = brushConverter.ConvertFromString("#6c7682") as SolidColorBrush;
        //            button3_Name.Content = pagination + 2;
        //            button3_Name.Background = new SolidColorBrush(Colors.White);
        //            button3_Name.Foreground = brushConverter.ConvertFromString("#6c7682") as SolidColorBrush;
        //            GlobalVariable.Pagination = pagination;
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Error");
        //    }
        //}

        //private async void Refresh_Old()
        //{
        //    try
        //    {
        //        BrushConverter brushConverter = new BrushConverter();

        //        button1_Name.Content = 1;
        //        button1_Name.Background = brushConverter.ConvertFromString("#7950f2") as SolidColorBrush;
        //        button1_Name.Foreground = new SolidColorBrush(Colors.White);
        //        button2_Name.Content = 2;
        //        button2_Name.Background = new SolidColorBrush(Colors.White);
        //        button2_Name.Foreground = brushConverter.ConvertFromString("#6c7682") as SolidColorBrush;
        //        button3_Name.Content = 3;
        //        button3_Name.Background = new SolidColorBrush(Colors.White);
        //        button3_Name.Foreground = brushConverter.ConvertFromString("#6c7682") as SolidColorBrush;
        //        GlobalVariable.Pagination = 1;
        //        pagination = 1;
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Error");
        //    }
        //}
    }
}