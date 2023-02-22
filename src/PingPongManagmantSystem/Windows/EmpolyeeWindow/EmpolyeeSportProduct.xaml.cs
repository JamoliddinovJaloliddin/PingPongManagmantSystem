using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;
using PingPongManagmantSystem.Service.Services.EmpolyeeService;
using System.Collections.Generic;
using System.Windows;

namespace PingPongManagmantSystem.Desktop.Windows.EmpolyeeWindow
{
    /// <summary>
    /// Interaction logic for EmpolyeeSportProduct.xaml
    /// </summary>
    public partial class EmpolyeeSportProduct : Window
    {
        IEmpolyeeSportProductService sportService = new EmpolyeeSportProductService();
        Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
        double sumPrice = 0;
        int countNumber = 0;
        string accountBook = "";

        public EmpolyeeSportProduct()
        {
            InitializeComponent();
            GridRefresh();
        }

        public async void GridRefresh()
        {
            if (countNumber == 0)
            {
                List<SportCount> resault = (List<SportCount>)await sportService.GetAllAsync();
                sportDataGrid.ItemsSource = resault;
                countNumber++;
            }
            else
            {
                List<SportCount> sportCounts = (List<SportCount>)await sportService.GetAllAsync();
                sportDataGrid.ItemsSource = sportCounts;
            }
        }

        private async void Buy_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (SportCount bar in sportDataGrid.Items)
                {
                    sumPrice += bar.Price * bar.Count;
                    accountBook += $"{bar.Name}  {bar.Price}   {bar.Count}   {bar.Price * bar.Count}\n";
                    keyValuePairs.Add(key: bar.Name, value: bar.Count);
                }

                var res = await sportService.DeleteProductAsync(keyValuePairs);
                if (res)
                {
                    var sportCount = await sportService.DeleteCountAsync();
                }
                this.Close();
                MessageBox.Show($"{accountBook} \nUmumiy: {sumPrice}");
                sumPrice = 0;
                countNumber = 0;
                accountBook = "";
                keyValuePairs.Clear();
            }
            catch
            {

            }
        }

        private void Delete_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = (SportCount)sportDataGrid.SelectedItem;
                sportService.CreateAsync(2, item);
                GridRefresh();
            }
            catch
            {

            }
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = (SportCount)sportDataGrid.SelectedItem;
                sportService.CreateAsync(1, item);
                GridRefresh();
            }
            catch
            {

            }
        }

        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            foreach (BarCount bar in sportDataGrid.Items)
            {
                keyValuePairs.Add(key: bar.Name, value: bar.Count);
            }
            sportService.DeleteCountAsync();
            keyValuePairs.Clear();
            this.Close();
        }
    }
}
