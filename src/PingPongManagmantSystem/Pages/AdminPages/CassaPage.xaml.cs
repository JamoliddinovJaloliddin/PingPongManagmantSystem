using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Common.Utils;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Services.AdminService;
using PingPongManagmantSystem.Service.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

#pragma warning disable

namespace PingPongManagmantSystem.Desktop.Pages
{
    public partial class CassaPage : Page
    {
        ICassaService cassa = new CassaService();
        int pageSize = 30;
        int pagination = (int)GlobalVariable.Page;
        public CassaPage()
        {
            InitializeComponent();
            Refresh_Page();
            Refresh_Old();
            tb.Text = GlobalVariable.Search;
        }

        public async void Refresh_Page()
        {
            try
            {
                var res = await cassa.GetAllAsync("", new PaginationParams((int)GlobalVariable.Page, pageSize));
                cassaDataGrid.ItemsSource = res;
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private async void Check_Button(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                var resault = (Cassa)cassaDataGrid.SelectedItem;
                var check = await cassa.GetByIdAsync(resault.Id);
                MessageBox.Show(check);
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private async void Delete_Button(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                var resault = (Cassa)cassaDataGrid.SelectedItem;
                var res = await cassa.DeleteAsync(resault.Id);
                if (res)
                {
                    this.NavigationService.Refresh();
                }
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
                var res = await cassa.GetAllAsync(tb.Text.ToString(), new PaginationParams((int)GlobalVariable.Page, pageSize));
                cassaDataGrid.ItemsSource = res;
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void UserAdd_Button(object sender, RoutedEventArgs e)
        {

        }

        private async void Prewiew_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                GlobalVariable.Search = tb.Text.ToString();
                GlobalVariable.Prewiew = 1;
                GlobalVariable.Next = 0;
                if (GlobalVariable.NextPage != 1)
                {
                    GlobalVariable.NextPage--;
                    GlobalVariable.Page--;

                    this.NavigationService.Refresh();
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private async void Next_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                GlobalVariable.Search = tb.Text.ToString();
                GlobalVariable.Prewiew = 0;
                GlobalVariable.Next = 1;
                if (GlobalVariable.NextPage < GlobalVariable.Pagination)
                {
                    GlobalVariable.NextPage++;
                    GlobalVariable.Page++;
                    this.NavigationService.Refresh();
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private async void Refresh_Old()
        {
            try
            {
                BrushConverter brushConverter = new BrushConverter();

                if (GlobalVariable.Pagination == 1 || GlobalVariable.Pagination == 2 && GlobalVariable.Page == 2)
                {
                    next_button.IsEnabled = false;
                }
                if (GlobalVariable.Pagination == 2 && GlobalVariable.Page == 2)
                {
                    button1_Name.Content = GlobalVariable.NextPage - 1;
                    button1_Name.Background = new SolidColorBrush(Colors.White);
                    button1_Name.Foreground = brushConverter.ConvertFromString("#6c7682") as SolidColorBrush;
                    button2_Name.Content = GlobalVariable.NextPage;
                    button2_Name.Background = brushConverter.ConvertFromString("#7950f2") as SolidColorBrush;
                    button2_Name.Foreground = new SolidColorBrush(Colors.White);
                    button3_Name.Content = GlobalVariable.NextPage + 1;
                    button3_Name.Background = new SolidColorBrush(Colors.White);
                    button3_Name.Foreground = brushConverter.ConvertFromString("#6c7682") as SolidColorBrush;
                    GlobalVariable.Page = GlobalVariable.NextPage;
                }
                else
                {

                    if (GlobalVariable.NextPage == 1)
                    {
                        button1_Name.Content = 1;
                        button1_Name.Background = brushConverter.ConvertFromString("#7950f2") as SolidColorBrush;
                        button1_Name.Foreground = new SolidColorBrush(Colors.White);
                        button2_Name.Content = 2;
                        button2_Name.Background = new SolidColorBrush(Colors.White);
                        button2_Name.Foreground = brushConverter.ConvertFromString("#6c7682") as SolidColorBrush;
                        button3_Name.Content = 3;
                        button3_Name.Background = new SolidColorBrush(Colors.White);
                        button3_Name.Foreground = brushConverter.ConvertFromString("#6c7682") as SolidColorBrush;
                    }
                    if (GlobalVariable.NextPage > 1)
                    {
                        if (GlobalVariable.Next == 1)
                        {
                            if (pagination < GlobalVariable.Pagination)
                            {
                                button1_Name.Content = GlobalVariable.NextPage - 1;
                                button1_Name.Background = new SolidColorBrush(Colors.White);
                                button1_Name.Foreground = brushConverter.ConvertFromString("#6c7682") as SolidColorBrush;
                                button2_Name.Content = GlobalVariable.NextPage;
                                button2_Name.Background = brushConverter.ConvertFromString("#7950f2") as SolidColorBrush;
                                button2_Name.Foreground = new SolidColorBrush(Colors.White);
                                button3_Name.Content = GlobalVariable.NextPage + 1;
                                button3_Name.Background = new SolidColorBrush(Colors.White);
                                button3_Name.Foreground = brushConverter.ConvertFromString("#6c7682") as SolidColorBrush;
                                GlobalVariable.Page = GlobalVariable.NextPage;
                            }
                            else if (pagination == GlobalVariable.Pagination)
                            {
                                button1_Name.Content = GlobalVariable.NextPage - 2;
                                button1_Name.Background = new SolidColorBrush(Colors.White);
                                button1_Name.Foreground = brushConverter.ConvertFromString("#6c7682") as SolidColorBrush;
                                button2_Name.Content = GlobalVariable.NextPage - 1;
                                button2_Name.Background = new SolidColorBrush(Colors.White);
                                button2_Name.Foreground = brushConverter.ConvertFromString("#6c7682") as SolidColorBrush;
                                button3_Name.Content = GlobalVariable.NextPage;
                                button3_Name.Background = brushConverter.ConvertFromString("#7950f2") as SolidColorBrush;
                                button3_Name.Foreground = new SolidColorBrush(Colors.White);
                                GlobalVariable.Page = GlobalVariable.NextPage;
                            }
                        }
                        else if (GlobalVariable.Prewiew == 1)
                        {
                            if (GlobalVariable.NextPage > 1)
                            {
                                button1_Name.Content = GlobalVariable.NextPage - 1;
                                button1_Name.Background = new SolidColorBrush(Colors.White);
                                button1_Name.Foreground = brushConverter.ConvertFromString("#6c7682") as SolidColorBrush;
                                button2_Name.Content = GlobalVariable.NextPage;
                                button2_Name.Background = brushConverter.ConvertFromString("#7950f2") as SolidColorBrush;
                                button2_Name.Foreground = new SolidColorBrush(Colors.White);
                                button3_Name.Content = GlobalVariable.NextPage + 1;
                                button3_Name.Background = new SolidColorBrush(Colors.White);
                                button3_Name.Foreground = brushConverter.ConvertFromString("#6c7682") as SolidColorBrush;
                                GlobalVariable.Pagination = GlobalVariable.NextPage;
                            }
                            else if (GlobalVariable.NextPage == 1)
                            {
                                button1_Name.Content = GlobalVariable.NextPage;
                                button1_Name.Background = brushConverter.ConvertFromString("#7950f2") as SolidColorBrush;
                                button1_Name.Foreground = new SolidColorBrush(Colors.White);
                                button2_Name.Content = GlobalVariable.NextPage + 1;
                                button2_Name.Background = new SolidColorBrush(Colors.White);
                                button2_Name.Foreground = brushConverter.ConvertFromString("#6c7682") as SolidColorBrush;
                                button3_Name.Content = GlobalVariable.NextPage + 2;
                                button3_Name.Background = new SolidColorBrush(Colors.White);
                                button3_Name.Foreground = brushConverter.ConvertFromString("#6c7682") as SolidColorBrush;
                                GlobalVariable.Pagination = GlobalVariable.NextPage;
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
