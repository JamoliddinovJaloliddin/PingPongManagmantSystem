using Dynamitey.DynamicObjects;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Services;
using System.Collections.Generic;
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
            Time res = new Time();
            var rest = await timeService.GetAll();
            foreach (var item in rest)
            { 
                res.TimeCheapUpTo = item.TimeCheapUpTo;
                res.TimeCheapFrom = item.TimeCheapFrom;
                res.TimeExpensiveFrom = item.TimeExpensiveFrom;
                res.TimeExpensiveUpTo = item.TimeExpensiveUpTo;

            }
            dan1.Text = res.TimeCheapFrom;
            dan2.Text = res.TimeExpensiveFrom;
            gacha1.Text = res.TimeCheapUpTo;
            gacha2.Text = res.TimeExpensiveUpTo;
        }

        private async void Update_Button(object sender, RoutedEventArgs e)
        {
            Time time = new Time();
            time.Id = 1;
            time.TimeCheapFrom = dan1.Text;
            time.TimeExpensiveFrom = gacha1.Text;
            time.TimeCheapUpTo = dan2.Text;
            time.TimeExpensiveUpTo = gacha2.Text;

            await timeService.UpdateAsync(time);
        }
    }
}
