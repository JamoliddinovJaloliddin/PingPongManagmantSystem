using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;
using PingPongManagmantSystem.Service.Services.EmpolyeeService;
using PingPongManagmantSystem.Service.ViewModels;
using System.Collections.Generic;
using System.Windows;

namespace PingPongManagmantSystem.Desktop.Windows.EmpolyeeWindow
{

    public partial class EmpolyeeBarProduct : Window
    {
        IEmpolyeeBarProductService barProductService = new EmpolyeeBarProductService();
        double sumPrice = 0;
        int countNumber = 0;

        public EmpolyeeBarProduct()
        {
            InitializeComponent();
            RefreshDataBar();
        }

        public async void RefreshDataBar()
        {
            try
            {
                if (countNumber == 0)
                {
                    List<BarCount> item = (List<BarCount>)await barProductService.GetAllAsync();
                    empolyeProductDataGrid.ItemsSource = item;
                    countNumber++;

                }
                else
                {
                    List<BarCount> item = (List<BarCount>)await barProductService.GetAllBarCountAsync();
                    empolyeProductDataGrid.ItemsSource = item;
                }

            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private async void Sum(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = (BarView)empolyeProductDataGrid.SelectedItem;

                MessageBox.Show(item.Price.ToString());
                MessageBox.Show(sumPrice.ToString());
            }
            catch
            {
                MessageBox.Show("Error Button");
            }
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {
            var resault = (BarCount)empolyeProductDataGrid.SelectedItem;
            barProductService.CreateAsync(1, resault);
            RefreshDataBar();
        }

        private void Delete_Button(object sender, RoutedEventArgs e)
        {
            var resault = (BarCount)empolyeProductDataGrid.SelectedItem;
            barProductService.CreateAsync(2, resault);
            RefreshDataBar();
        }
    }
}
