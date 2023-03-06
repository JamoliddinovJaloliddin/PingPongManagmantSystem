using PingPongManagmantSystem.Desktop.Windows.AddPanel;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Common.Utils;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Services.AdminService;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows;
using System.Windows.Controls;

namespace PingPongManagmantSystem.Desktop.Pages
{
    public partial class BarProductpage : Page
    {
        IBarProductService barProductService = new BarProductService();
        int pageSize = 15;
        public BarProductpage()
        {
            InitializeComponent();
            RefreshDataBar();
        }

        public async void RefreshDataBar()
        {
            try
            {
                List<BarProduct> barProducts = (List<BarProduct>)await barProductService.GetAllAsync("", new PaginationParams(1, pageSize));
                barDataGrid.ItemsSource = barProducts;
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

                BarProductAddPanel barProductAddPanel = new BarProductAddPanel();
                barProductAddPanel.addbtn.IsEnabled = false;
                barProductAddPanel.updbtn.IsEnabled = true;
                var barPro = (BarProduct)barDataGrid.SelectedItem;

                barProductAddPanel.id.Content = barPro.Id;
                barProductAddPanel.name.Text = barPro.Name;
                barProductAddPanel.arrivalPrice.Text = barPro.ArrivalPrice.ToString();
                barProductAddPanel.salePrice.Text = barPro.SalePrice.ToString();
                barProductAddPanel.count.Text = barPro.Count.ToString();
                barProductAddPanel.ShowDialog();
                RefreshDataBar();
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
                var barPro = barDataGrid.SelectedItem as BarProduct;
                var res = await barProductService.DeleteAsync(barPro.Id);
                RefreshDataBar();
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
                List<BarProduct> barProducts = (List<BarProduct>)await barProductService.GetAllAsync(tb.Text.ToString().ToLower(), new PaginationParams(1, pageSize));
                barDataGrid.ItemsSource = barProducts;
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
