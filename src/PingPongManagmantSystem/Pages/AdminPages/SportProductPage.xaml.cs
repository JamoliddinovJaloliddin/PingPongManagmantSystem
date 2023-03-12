using PingPongManagmantSystem.Desktop.Windows.AddPanel;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Common.Utils;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Services.AdminService;
using PingPongManagmantSystem.Service.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

#pragma warning disable

namespace PingPongManagmantSystem.Desktop.Pages
{
    public partial class SportProductPage : Page
    {
        ISportProductService sportProductService = new SportProductService();
        int pageSize = 30;
        int pagination = (int)GlobalVariable.Page;
        public SportProductPage()
        {
            InitializeComponent();
            RefreshDataSpor();
            Refresh_Old();
            tb.Text = GlobalVariable.Search;
        }

        public async Task RefreshDataSpor()
        {
            try
            {
                List<SportProduct> sportProduct = (List<SportProduct>)await sportProductService.GetAllAsync("", new PaginationParams((int)GlobalVariable.Page, pageSize));
                sportrDataGrid.ItemsSource = sportProduct;
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private async void Update_button(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                SportProductAddPanel sportProduct = new SportProductAddPanel();
                sportProduct.add_btn.IsEnabled = false;
                sportProduct.upd_btn.IsEnabled = true;

                var item = (SportProduct)sportrDataGrid.SelectedItem;

                sportProduct.id.Content = item.Id;
                sportProduct.name.Text = item.Name;
                sportProduct.arrivalPrice.Text = item.ArrivalPrice.ToString();
                sportProduct.salePrice.Text = item.SalePrice.ToString();
                sportProduct.count.Text = item.Count.ToString();
                sportProduct.ShowDialog();
                this.NavigationService.Refresh();
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
                var item = (SportProduct)sportrDataGrid.SelectedItem;
                await sportProductService.DeleteAsync(item.Id);
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
                List<SportProduct> sportProduct = (List<SportProduct>)await sportProductService.GetAllAsync(tb.Text.ToString().ToLower(), new PaginationParams(1, pageSize));
                sportrDataGrid.ItemsSource = sportProduct;
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void SportAdd_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                SportProductAddPanel sportProductAddPanel = new SportProductAddPanel();
                sportProductAddPanel.add_btn.IsEnabled = true;
                sportProductAddPanel.upd_btn.IsEnabled = false;
                sportProductAddPanel.ShowDialog();
                this.NavigationService.Refresh();
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
