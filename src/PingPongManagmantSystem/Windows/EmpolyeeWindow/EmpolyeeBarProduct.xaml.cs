using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace PingPongManagmantSystem.Desktop.Windows.EmpolyeeWindow
{
    /// <summary>
    /// Interaction logic for EmpolyeeBarProduct.xaml
    /// </summary>
    public partial class EmpolyeeBarProduct : Window
    {
        IBarProductService barProductService = new BarProductService();

        public EmpolyeeBarProduct()
        {
            InitializeComponent();
            RefreshDataBar();
        }

        public async Task RefreshDataBar()
        { 
            List<BarProduct> item = (List<BarProduct>) await barProductService.GetAllAsync();
            empolyeProductDataGrid.ItemsSource = item;
        }


    }
}
