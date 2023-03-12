using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;
using PingPongManagmantSystem.Service.Services.EmpolyeeService;
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

                            accountBook += $"{bar.Name}  {bar.Price}   {bar.Count}   {bar.Price * bar.Count}\n";
                            keyValuePairs.Add(key: bar.Name, value: bar.Count);
                        }
                    }
                    if (keyValuePairs.Count > 0)
                    {
                        var resultSport = await sportService.CheckSportProductAsync(keyValuePairs);

                        if (resultSport)
                        {
                            this.Close();
                            var res = await sportService.DeleteSportProductAsync(keyValuePairs, combo_CardCash.Text.ToString());
                            var result = await sportService.DeleteSportCountAsync();
                            MessageBox.Show($"{accountBook} \nUmumiy:   {sumPrice} so'm");
                            keyValuePairs.Clear();
                            await sportService.DeleteSportCountAsync();
                            sumPrice = 0;
                            countNumber = 0;
                            accountBook = "";

                        }
                        else
                        {
                            MessageBox.Show("Mahsulot soni yetarli emas");
                            keyValuePairs.Clear();
                            await sportService.DeleteSportCountAsync();
                            sumPrice = 0;
                            countNumber = 0;
                            accountBook = "";
                            GridRefresh();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ma'lumot to'liq kiritilmadi");
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

        private async void Exit_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = await sportService.DeleteSportCountAsync();
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
