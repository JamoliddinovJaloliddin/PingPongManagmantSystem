using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;
using PingPongManagmantSystem.Service.Services.EmpolyeeService;
using System.Collections.Generic;
using System.Windows;

namespace PingPongManagmantSystem.Desktop.Windows.EmpolyeeWindow
{

    public partial class EmpolyeeBarProduct : Window
    {
        IEmpolyeeBarProductService barProductService = new EmpolyeeBarProductService();
        Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
        AppDbContext appDbContext = new AppDbContext();
        double sumPrice = 0;
        int countNumber = 0;
        string accountBook = "";

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
                if (empolyeProductDataGrid.Items.Count > 0 && combo_CardCash.Text == "Naxt" || combo_CardCash.Text == "Karta")
                {
                    foreach (BarCount bar in empolyeProductDataGrid.Items)
                    {

                        if (bar.Count > 0)
                        {
                            sumPrice += bar.Price * bar.Count;
                            accountBook += $"{bar.Name}  {bar.Price}   {bar.Count}   {bar.Price * bar.Count}\n";
                            keyValuePairs.Add(key: bar.Name, value: bar.Count);
                        }
                    }
                    bool res = false;
                    if (gridBar_lbl.Content.ToString() == "Button")
                    {
                        res = await barProductService.DeleteBarCountAsync(int.Parse(grid_lbl.Content.ToString()), accountBook, sumPrice);
                        this.Close();
                    }
                    else
                    {
                        string word = "NotButton";
                        res = await barProductService.DeleteBarCountAsync(1, word, sumPrice);
                        this.Close();
                        MessageBox.Show($"{accountBook} \nUmumiy: {sumPrice}");
                    }

                    if (res)
                    {
                        var resault = await barProductService.DeleteBarProductAsync(keyValuePairs, combo_CardCash.Text);
                        if (resault)
                        {
                            keyValuePairs.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Xatolik");
                    }

                    sumPrice = 0;
                    countNumber = 0;
                    accountBook = "";
                    keyValuePairs.Clear();
                }
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
                var resault = (BarCount)empolyeProductDataGrid.SelectedItem;

                barProductService.CreateAsync(1, resault);
                RefreshDataBar();
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
                var resault = (BarCount)empolyeProductDataGrid.SelectedItem;
                barProductService.CreateAsync(2, resault);
                RefreshDataBar();
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
                barProductService.DeleteBarCountAsync(1, "NotButton", 2);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
