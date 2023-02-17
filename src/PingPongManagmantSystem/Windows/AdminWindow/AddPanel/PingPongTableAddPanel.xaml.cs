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
            if (status.Text != null && priceCheap.Text != null && priceExpires.Text != null)
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
                MessageBox.Show("To'ldirilmagan qator");
            }
        }

        private async void Update_Button(object sender, RoutedEventArgs e)
        {
            if (status.Text != null && priceCheap.Text != null && priceExpires.Text != null)
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
                MessageBox.Show("Error");
            }
        }
    }
}
