using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Services.AdminService;
using System.Windows;

namespace PingPongManagmantSystem.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for Timepanel.xaml
    /// </summary>
    public partial class Timepanel : Window
    {
        ITimeService timeService = new TimeService();
        public Timepanel()
        {
            InitializeComponent();
            RefreshDataTime();
        }

        public async void RefreshDataTime()
        {
            
            var res = await timeService.GetAll();

            dan1.Text = res.TimeCheapFrom.ToString();
            dan2.Text = res.TimeExpensiveFrom.ToString();
            gacha1.Text = res.TimeCheapUpTo.ToString();
            gacha2.Text = res.TimeExpensiveUpTo.ToString();
        }

        private async void Update_Button(object sender, RoutedEventArgs e)
        {
            Time time = new Time();
            time.Id = 1;
            time.TimeCheapFrom = double.Parse(dan1.Text);
            time.TimeExpensiveFrom = double.Parse(gacha1.Text);
            time.TimeCheapUpTo = double.Parse(dan2.Text);
            time.TimeExpensiveUpTo = double.Parse(gacha2.Text);

            await timeService.UpdateAsync(time);
        }
    }
}
