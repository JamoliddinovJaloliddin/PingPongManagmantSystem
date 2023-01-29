﻿using Dynamitey.DynamicObjects;
using PingPongManagmantSystem.Desktop.Windows.AddPanel;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PingPongManagmantSystem.Desktop.Pages
{
    public partial class SportProductPage : Page
    {
        ISportProductService sportProductService = new SportProductService();
        public SportProductPage()
        {
            InitializeComponent();
            RefreshDataSpor();
        }

        public async Task RefreshDataSpor()
        {
            List<SportProduct> sportProduct = (List<SportProduct>)await sportProductService.GetAllAsync();
            sportrDataGrid.ItemsSource = sportProduct;
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
                await RefreshDataSpor();
            }
            catch
            { 
            
            }
        }

        private async void Delete_Button(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                var item = (SportProduct)sportrDataGrid.SelectedItem;
                await sportProductService.DeleteAsync(item.Id);
                await RefreshDataSpor();
            }
            catch
            { 
            
            }
        }
    }
}
