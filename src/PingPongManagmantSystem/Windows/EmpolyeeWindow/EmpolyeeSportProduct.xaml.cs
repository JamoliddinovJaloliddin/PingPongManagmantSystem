using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;
using PingPongManagmantSystem.Service.Services.EmpolyeeService;
using System;
using System.Collections.Generic;
using System.Windows;

namespace PingPongManagmantSystem.Desktop.Windows.EmpolyeeWindow
{
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
            try
            {
                if (countNumber == 0)
                {
                    List<SportCount> resault = (List<SportCount>)await sportService.GetAllAsync();
                    sportDataGrid.ItemsSource = resault;
                    countNumber++;
                }
                else
                {
                    List<SportCount> sportCounts = (List<SportCount>)await sportService.GetAllSportProductAsync();
                    sportDataGrid.ItemsSource = sportCounts;
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private async void Buy_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sportDataGrid.Items.Count > 0 && combo_CardCash.Text == "Naxt" || combo_CardCash.Text == "Karta")
                {
                    foreach (SportCount bar in sportDataGrid.Items)
                    {
                        if (bar.Count > 0)
                        {
                            sumPrice += bar.Price * bar.Count;

                            accountBook += (String.Format("{0, -20}{1,-20}{2, -20}{3,-20}\n\n", bar.Name, bar.Price, bar.Count, bar.Count * bar.Price));
                            keyValuePairs.Add(key: bar.Name, value: bar.Count);
                        }
                    }
                    if (keyValuePairs.Count > 0)
                    {
                        var res = await sportService.DeleteSportProductAsync(keyValuePairs);
                        if (res)
                        {
                            var sportCount = await sportService.DeleteSportCountAsync();
                        }
                        this.Close();
                        await sportService.DeleteSportCountAsync();
                        MessageBox.Show($"{accountBook} \nUmumiy:   {sumPrice}");
                        sumPrice = 0;
                        countNumber = 0;
                        accountBook = "";
                        keyValuePairs.Clear();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error");
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
                MessageBox.Show("Error");
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
                MessageBox.Show("Error");
            }
        }

        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                sportService.DeleteSportCountAsync();
                keyValuePairs.Clear();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
