using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Services.AdminService;
using System.Windows;

namespace PingPongManagmantSystem.Desktop.Windows.AddPanel
{
    public partial class PingPongTableAddPanel : Window
    {
        IPingPongTableService pingPongTableService = new PingPongTableService();
        public PingPongTableAddPanel()
        {
            InitializeComponent();
        }

        private async void Add_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                if (status.Text != "" && priceCheap.Text != "" && priceExpires.Text != "")
                {
                    PingPongTable pingPongTable = new PingPongTable();
                    pingPongTable.Number = int.Parse(status.Text);
                    pingPongTable.PriceCheap = double.Parse(priceCheap.Text);
                    pingPongTable.PriceExpensive = double.Parse(priceExpires.Text);
                    await pingPongTableService.CreateAsync(pingPongTable);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ma'lumotlar to'liq kiritilmadi");
                }
            }
            catch
            {
                MessageBox.Show("Ma'lumot noto'g'ri kiritildi");
            }
        }

        private async void Update_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                if (status.Text != "" && priceCheap.Text != "" && priceExpires.Text != "")
                {
                    PingPongTable pingPongTable = new PingPongTable();
                    pingPongTable.Id = int.Parse(id.Content.ToString());
                    pingPongTable.Number = int.Parse(status.Text);
                    pingPongTable.PriceCheap = double.Parse(priceCheap.Text);
                    pingPongTable.PriceExpensive = double.Parse(priceExpires.Text);
                    await pingPongTableService.UpdateAsync(pingPongTable);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ma'lumotlar to'liq kiritilmadi");
                }
            }
            catch
            {
                MessageBox.Show("Ma'lumot noto'g'ri kiritildi");
            }
        }

        private void Exit_Button(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
