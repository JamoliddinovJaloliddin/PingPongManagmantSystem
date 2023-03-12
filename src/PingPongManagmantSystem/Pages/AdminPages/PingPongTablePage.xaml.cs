using PingPongManagmantSystem.Desktop.Windows.AddPanel;
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
    public partial class PingPongTablePage : Page
    {
        IPingPongTableService pingPongTableService = new PingPongTableService();
        int pageSize = 2;
        int pagination = (int)GlobalVariable.Page;
        public PingPongTablePage()
        {
            InitializeComponent();
            RefreshDataPing();
            Refresh_Old();
            tb.Text = GlobalVariable.Search;
        }

        public async void RefreshDataPing()
        {
            try
            {
                var item = await pingPongTableService.GetAllAsync("", new PaginationParams((int)GlobalVariable.Page, pageSize));
                pingPongDataGrid.ItemsSource = item;
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private async void Update_Button(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                PingPongTableAddPanel pingPongTable = new PingPongTableAddPanel();
                pingPongTable.upd_btn.IsEnabled = true;

                var item = (PingPongTable)pingPongDataGrid.SelectedItem;

                pingPongTable.id.Content = item.Id;
                pingPongTable.status.Text = item.Number.ToString();
                pingPongTable.priceCheap.Text = item.PriceCheap.ToString();
                pingPongTable.priceExpires.Text = item.PriceExpensive.ToString();
                pingPongTable.ShowDialog();
                this.NavigationService.Refresh();
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
                var item = await pingPongTableService.GetAllAsync(tb.Text.ToString().ToLower(), new PaginationParams((int)GlobalVariable.Page, pageSize));
                pingPongDataGrid.ItemsSource = item;
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void Prewiew_Button(object sender, RoutedEventArgs e)
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

        private void Next_Button(object sender, RoutedEventArgs e)
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

        private void UserAdd_Button(object sender, RoutedEventArgs e)
        {

        }
    }
}
