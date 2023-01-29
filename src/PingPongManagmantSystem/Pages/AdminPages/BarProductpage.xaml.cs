using PingPongManagmantSystem.Desktop.Windows.AddPanel;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Services;
using System.Collections.Generic;
using System.Windows.Controls;

namespace PingPongManagmantSystem.Desktop.Pages
{
    public partial class BarProductpage : Page
    {
        IBarProductService barProductService = new BarProductService();
        public BarProductpage()
        {
            InitializeComponent();
            RefreshDataBar();
        }

        public async void RefreshDataBar()
        {
            List<BarProduct> barProducts = (List<BarProduct>)await barProductService.GetAllAsync();
            barDataGrid.ItemsSource = barProducts;
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
            
            }
        }
    }
}
