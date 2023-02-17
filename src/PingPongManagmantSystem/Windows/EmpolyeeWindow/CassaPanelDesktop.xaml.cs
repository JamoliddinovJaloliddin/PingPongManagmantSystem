using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Common;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;
using PingPongManagmantSystem.Service.Services.EmpolyeeService;
using System.Windows;

namespace PingPongManagmantSystem.Desktop.Windows.EmpolyeeWindow
{
    public partial class CassaPanelDesktop : Window
    {
        private readonly IDesktopCassaService desktopCassaService = new DesktopCassaService();
        private readonly CountTheTime countTheTime;

        public CassaPanelDesktop()
        {
            InitializeComponent();
            Button_Inspection();
        }

        public async void RefreshData()
        {

        }

        public async void Button_Inspection()
        {
            try
            {
                var res = await desktopCassaService.GetAllAsync();
                foreach (var item in res)
                {

                }
            }
            catch
            {

            }

        }

        private void Bar_Click(object sender, RoutedEventArgs e)
        {
            EmpolyeeBarProduct product = new EmpolyeeBarProduct();
            product.Show();
        }

        private void Sport_Click(object sender, RoutedEventArgs e)
        {
            EmpolyeeSportProduct product = new EmpolyeeSportProduct();
            product.Show();
        }

        private void Card_Click(object sender, RoutedEventArgs e)
        {
            EmpolyeeCardRegister empolyeeCardRegister = new EmpolyeeCardRegister();
            empolyeeCardRegister.Show();
        }

        private async void Play_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                DesktopCassa cassa = new DesktopCassa();
                if (ply_btn1.IsMouseOver && pause_btn1.IsEnabled != true)
                {
                    ply_btn1.IsEnabled = false;
                    pause_btn1.IsEnabled = true;
                    stop_btn1.IsEnabled = true;
                    transfer_btn1.IsEnabled = true;
                    bar_btn1.IsEnabled = true;
                    calc_btn1.IsEnabled = true;
                    label_1.Content = "";
                    cassa.StolNumber = 1;
                    cassa.Pause = true;
                    cassa.Stop = true;
                    cassa.UserId = 0;
                    cassa.Play = false;
                    cassa.Transfer = true;
                    cassa.Calc = true;
                    cassa.Label = "";
                    cassa.BarSum = 0;
                    cassa.AccountBook = "";
                }
                else if (ply_btn2.IsMouseOver && pause_btn2.IsEnabled != true)
                {
                    ply_btn2.IsEnabled = false;
                    pause_btn2.IsEnabled = true;
                    stop_btn2.IsEnabled = true;
                    transfer_btn2.IsEnabled = true;
                    bar_btn2.IsEnabled = true;
                    calc_btn2.IsEnabled = true;
                    label_2.Content = "";
                    cassa.StolNumber = 2;
                    cassa.Pause = false;
                    cassa.Stop = false;
                    cassa.UserId = 0;
                    cassa.Play = false;
                    cassa.Transfer = true;
                    cassa.Calc = true;
                    cassa.Label = "";
                    cassa.BarSum = 0;
                    cassa.AccountBook = "";

                }
                else if (ply_btn3.IsMouseOver && pause_btn3.IsEnabled != true)
                {
                    ply_btn3.IsEnabled = false;
                    pause_btn3.IsEnabled = true;
                    stop_btn3.IsEnabled = true;
                    transfer_btn3.IsEnabled = true;
                    bar_btn3.IsEnabled = true;
                    calc_btn3.IsEnabled = true;
                    label_3.Content = "";
                    cassa.StolNumber = 3;
                    cassa.Pause = false;
                    cassa.Stop = false;
                    cassa.UserId = 0;
                    cassa.Play = false;
                    cassa.Transfer = true;
                    cassa.Calc = true;
                    cassa.Label = "";
                    cassa.BarSum = 0;
                    cassa.AccountBook = "";
                }
                else if (ply_btn4.IsMouseOver && pause_btn4.IsEnabled != true)
                {
                    ply_btn4.IsEnabled = false;
                    pause_btn4.IsEnabled = true;
                    stop_btn4.IsEnabled = true;
                    transfer_btn4.IsEnabled = true;
                    bar_btn4.IsEnabled = true;
                    calc_btn4.IsEnabled = true;
                    label_4.Content = "";
                    cassa.StolNumber = 4;
                    cassa.Pause = false;
                    cassa.Stop = false;
                    cassa.UserId = 0;
                    cassa.Play = false;
                    cassa.Transfer = true;
                    cassa.Calc = true;
                    cassa.Label = "";
                    cassa.BarSum = 0;
                    cassa.AccountBook = "";
                }
                else if (ply_btn5.IsMouseOver && pause_btn5.IsEnabled != true)
                {
                    ply_btn5.IsEnabled = false;
                    pause_btn5.IsEnabled = true;
                    stop_btn5.IsEnabled = true;
                    transfer_btn5.IsEnabled = true;
                    bar_btn5.IsEnabled = true;
                    calc_btn5.IsEnabled = true;
                    label_5.Content = "";
                    cassa.StolNumber = 5;
                    cassa.Pause = false;
                    cassa.Stop = false;
                    cassa.UserId = 0;
                    cassa.Play = false;
                    cassa.Transfer = true;
                    cassa.Calc = true;
                    cassa.Label = "";
                    cassa.BarSum = 0;
                    cassa.AccountBook = "";
                }
                else if (ply_btn6.IsMouseOver && pause_btn6.IsEnabled != true)
                {
                    ply_btn6.IsEnabled = false;
                    pause_btn6.IsEnabled = true;
                    stop_btn6.IsEnabled = true;
                    transfer_btn6.IsEnabled = true;
                    bar_btn6.IsEnabled = true;
                    calc_btn6.IsEnabled = true;
                    label_6.Content = "";
                    cassa.StolNumber = 6;
                    cassa.Pause = false;
                    cassa.Stop = false;
                    cassa.UserId = 0;
                    cassa.Play = false;
                    cassa.Transfer = true;
                    cassa.Calc = true;
                    cassa.Label = "";
                    cassa.BarSum = 0;
                    cassa.AccountBook = "";
                }
                else if (ply_btn7.IsMouseOver && pause_btn7.IsEnabled != true)
                {
                    ply_btn7.IsEnabled = false;
                    pause_btn7.IsEnabled = true;
                    stop_btn7.IsEnabled = true;
                    transfer_btn7.IsEnabled = true;
                    bar_btn7.IsEnabled = true;
                    calc_btn7.IsEnabled = true;
                    label_7.Content = "";
                    cassa.StolNumber = 7;
                    cassa.Pause = false;
                    cassa.Stop = false;
                    cassa.UserId = 0;
                    cassa.Play = false;
                    cassa.Transfer = true;
                    cassa.Calc = true;
                    cassa.Label = "";
                    cassa.BarSum = 0;
                    cassa.AccountBook = "";
                }
                else if (ply_btn8.IsMouseOver && pause_btn8.IsEnabled != true)
                {
                    ply_btn8.IsEnabled = false;
                    pause_btn8.IsEnabled = true;
                    stop_btn8.IsEnabled = true;
                    transfer_btn8.IsEnabled = true;
                    bar_btn8.IsEnabled = true;
                    calc_btn8.IsEnabled = true;
                    label_8.Content = "";
                    cassa.StolNumber = 8;
                    cassa.Pause = false;
                    cassa.Stop = false;
                    cassa.UserId = 0;
                    cassa.Play = false;
                    cassa.Transfer = true;
                    cassa.Calc = true;
                    cassa.Label = "";
                    cassa.BarSum = 0;
                    cassa.AccountBook = "";
                }

                var res = await desktopCassaService.UpdateAsync(cassa);
            }
            catch
            {
                return;
            }
        }

        private async void Pause_Button(object sender, RoutedEventArgs e, int numbe)
        {

            try
            {
                byte number = 0;
                DesktopCassa cassa = new DesktopCassa();


                if (pause_btn1.IsMouseOver && ply_btn1.IsEnabled == false)
                {
                    number = 1;
                    ply_btn1.IsEnabled = true;
                    pause_btn1.IsEnabled = false;
                }
                else if (pause_btn2.IsMouseOver && ply_btn2.IsEnabled == false)
                {
                    number = 2;
                    ply_btn2.IsEnabled = true;
                    pause_btn2.IsEnabled = false;
                }
                else if (pause_btn3.IsMouseOver && ply_btn3.IsEnabled == false)
                {
                    number = 3;
                    cassa.StolNumber = 3;
                    cassa.Pause = true;
                    cassa.Stop = false;

                    ply_btn3.IsEnabled = true;
                    pause_btn3.IsEnabled = false;
                }
                else if (pause_btn4.IsMouseOver && ply_btn4.IsEnabled != true)
                {
                    number = 4;
                    cassa.StolNumber = 4;
                    cassa.Pause = true;
                    cassa.Stop = false;

                    ply_btn4.IsEnabled = true;
                    pause_btn4.IsEnabled = false;
                }
                else if (pause_btn5.IsMouseOver && ply_btn5.IsEnabled != true)
                {
                    number = 5;
                    cassa.StolNumber = 5;
                    cassa.Pause = true;
                    cassa.Stop = false;

                    ply_btn5.IsEnabled = true;
                    pause_btn5.IsEnabled = false;
                }
                else if (pause_btn6.IsMouseOver && ply_btn5.IsEnabled != true)
                {
                    number = 6;
                    cassa.StolNumber = 6;
                    cassa.Pause = true;
                    cassa.Stop = false;

                    ply_btn6.IsEnabled = true;
                    pause_btn6.IsEnabled = false;
                }
                else if (pause_btn7.IsMouseOver && ply_btn7.IsEnabled != true)
                {
                    number = 7;
                    cassa.StolNumber = 7;
                    cassa.Pause = true;
                    cassa.Stop = false;

                    ply_btn7.IsEnabled = true;
                    pause_btn7.IsEnabled = false;
                }
                else if (pause_btn8.IsMouseOver && ply_btn8.IsEnabled != true)
                {
                    number = 8;
                    cassa.StolNumber = 8;
                    cassa.Pause = true;
                    cassa.Stop = false;

                    ply_btn8.IsEnabled = true;
                    pause_btn8.IsEnabled = false;
                }

                double timePrice = countTheTime.CountTheTimee(number);
                var res = await desktopCassaService.UpdateAsync(cassa);
            }
            catch
            {
                return;
            }
        }

        private void Stop_Button(object sender, RoutedEventArgs e)
        {
            EmpolyeeStop empolyeeStop = new EmpolyeeStop();
            empolyeeStop.Show();
        }

        private void Transfer_Button(object sender, RoutedEventArgs e)
        {
            EmpolyeeTransferTable empolyeeTransferTable = new EmpolyeeTransferTable();
            empolyeeTransferTable.Show();
        }

        private void Bar_Button(object sender, RoutedEventArgs e)
        {
            EmpolyeeBarProduct product = new EmpolyeeBarProduct();
            product.Show();
        }

        private void Calculator_Butoon(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("");
        }

        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }


    }
}
