using PingPongManagmantSystem.Service.Common;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;
using PingPongManagmantSystem.Service.Services.EmpolyeeService;
using PingPongManagmantSystem.Service.ViewModels;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace PingPongManagmantSystem.Desktop.Windows.EmpolyeeWindow
{
    public partial class CassaPanelDesktop : Window
    {
        private readonly IDesktopCassaService desktopCassaService = new DesktopCassaService();
        private readonly CountTheTime countTheTime;
        private bool IsMaximized = false;
        public CassaPanelDesktop()
        {
            InitializeComponent();
            Button_Inspection();
        }

        public async void Button_Inspection()
        {
            try
            {
                var res = await desktopCassaService.GetAllAsync();
                foreach (var item in res)
                {

                    switch (item.StolNumber)
                    {
                        case 1:
                            ply_btn1.IsEnabled = item.Play;
                            pause_btn1.IsEnabled = item.Pause;
                            stop_btn1.IsEnabled = item.Stop;
                            transfer_btn1.IsEnabled = item.Transfer;
                            bar_btn1.IsEnabled = item.Bar;
                            calc_btn1.IsEnabled = item.Calc;
                            if (item.Label == true)
                            {
                                label_1.Visibility = Visibility.Visible;
                                border1.Background = new SolidColorBrush(Colors.White);
                            }
                            else
                            {
                                border1.Background = new SolidColorBrush(Colors.LightBlue);
                            }
                            break;
                        case 2:
                            ply_btn2.IsEnabled = item.Play;
                            pause_btn2.IsEnabled = item.Pause;
                            stop_btn2.IsEnabled = item.Stop;
                            transfer_btn2.IsEnabled = item.Transfer;
                            bar_btn2.IsEnabled = item.Bar;
                            calc_btn2.IsEnabled = item.Calc;
                            if (item.Label == true)
                            {
                                label_2.Visibility = Visibility.Visible;
                                border2.Background = new SolidColorBrush(Colors.White);

                            }
                            else
                            {
                                border2.Background = new SolidColorBrush(Colors.LightBlue);
                            }
                            break;
                        case 3:
                            ply_btn3.IsEnabled = item.Play;
                            pause_btn3.IsEnabled = item.Pause;
                            stop_btn3.IsEnabled = item.Stop;
                            transfer_btn3.IsEnabled = item.Transfer;
                            bar_btn3.IsEnabled = item.Bar;
                            calc_btn3.IsEnabled = item.Calc;
                            if (item.Label == true)
                            {
                                label_3.Visibility = Visibility.Visible;
                                border3.Background = new SolidColorBrush(Colors.White);
                            }
                            else
                            {
                                border3.Background = new SolidColorBrush(Colors.LightBlue);
                            }
                            break;
                        case 4:
                            ply_btn4.IsEnabled = item.Play;
                            pause_btn4.IsEnabled = item.Pause;
                            stop_btn4.IsEnabled = item.Stop;
                            transfer_btn4.IsEnabled = item.Transfer;
                            bar_btn4.IsEnabled = item.Bar;
                            calc_btn4.IsEnabled = item.Calc;
                            if (item.Label == true)
                            {
                                label_4.Visibility = Visibility.Visible;
                                border4.Background = new SolidColorBrush(Colors.White);
                            }
                            else
                            {
                                border4.Background = new SolidColorBrush(Colors.LightBlue);
                            }
                            break;
                        case 5:
                            ply_btn5.IsEnabled = item.Play;
                            pause_btn5.IsEnabled = item.Pause;
                            stop_btn5.IsEnabled = item.Stop;
                            transfer_btn5.IsEnabled = item.Transfer;
                            bar_btn5.IsEnabled = item.Bar;
                            calc_btn5.IsEnabled = item.Calc;
                            if (item.Label == true)
                            {
                                label_5.Visibility = Visibility.Visible;
                                border5.Background = new SolidColorBrush(Colors.White);
                            }
                            else
                            {
                                border5.Background = new SolidColorBrush(Colors.LightBlue);
                            }
                            break;
                        case 6:
                            ply_btn6.IsEnabled = item.Play;
                            pause_btn6.IsEnabled = item.Pause;
                            stop_btn6.IsEnabled = item.Stop;
                            transfer_btn6.IsEnabled = item.Transfer;
                            bar_btn6.IsEnabled = item.Bar;
                            calc_btn6.IsEnabled = item.Calc;
                            if (item.Label == true)
                            {
                                label_6.Visibility = Visibility.Visible;
                                border6.Background = new SolidColorBrush(Colors.White);
                            }
                            else
                            {
                                border6.Background = new SolidColorBrush(Colors.LightBlue);
                            }
                            break;
                        case 7:
                            ply_btn7.IsEnabled = item.Play;
                            pause_btn7.IsEnabled = item.Pause;
                            stop_btn7.IsEnabled = item.Stop;
                            transfer_btn7.IsEnabled = item.Transfer;
                            bar_btn7.IsEnabled = item.Bar;
                            calc_btn7.IsEnabled = item.Calc;
                            if (item.Label == true)
                            {
                                label_7.Visibility = Visibility.Visible;
                                border7.Background = new SolidColorBrush(Colors.White);
                            }
                            else
                            {
                                border7.Background = new SolidColorBrush(Colors.LightBlue);
                            }
                            break;
                        case 8:
                            ply_btn8.IsEnabled = item.Play;
                            pause_btn8.IsEnabled = item.Pause;
                            stop_btn8.IsEnabled = item.Stop;
                            transfer_btn8.IsEnabled = item.Transfer;
                            bar_btn8.IsEnabled = item.Bar;
                            calc_btn8.IsEnabled = item.Calc;
                            if (item.Label == true)
                            {
                                label_8.Visibility = Visibility.Visible;
                                border8.Background = new SolidColorBrush(Colors.White);
                            }
                            else
                            {
                                border8.Background = new SolidColorBrush(Colors.LightBlue);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch
            {

            }

        }

        private void Bar_Click(object sender, RoutedEventArgs e)
        {
            EmpolyeeBarProduct product = new EmpolyeeBarProduct();
            product.ShowDialog();
            Button_Inspection();
        }

        private void Sport_Click(object sender, RoutedEventArgs e)
        {
            EmpolyeeSportProduct product = new EmpolyeeSportProduct();
            product.ShowDialog();
            Button_Inspection();

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
                int StolNumber = 0;
                if (ply_btn1.IsMouseOver)
                {
                    StolNumber = 1;
                }
                else if (ply_btn2.IsMouseOver)
                {
                    StolNumber = 2;
                }
                else if (ply_btn3.IsMouseOver)
                {
                    StolNumber = 3;
                }
                else if (ply_btn4.IsMouseOver)
                {
                    StolNumber = 4;
                }
                else if (ply_btn5.IsMouseOver)
                {
                    StolNumber = 5;
                }
                else if (ply_btn6.IsMouseOver)
                {
                    StolNumber = 6;
                }
                else if (ply_btn7.IsMouseOver)
                {
                    StolNumber = 7;
                }
                else if (ply_btn8.IsMouseOver)
                {
                    StolNumber = 8;
                }
                var res = await desktopCassaService.CreateAsync(StolNumber);
                Button_Inspection();
            }
            catch
            {
                return;
            }
        }

        private void Stop_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                EmpolyeeStop empolyeeStop = new EmpolyeeStop();
                empolyeeStop.lbl_stop.Content = "Stop";
                if (stop_btn1.IsMouseOver)
                {
                    empolyeeStop.lb_id.Content = 1;
                }
                else if (stop_btn2.IsMouseOver)
                {
                    empolyeeStop.lb_id.Content = 2;
                }
                else if (stop_btn3.IsMouseOver)
                {
                    empolyeeStop.lb_id.Content = 3;
                }
                else if (stop_btn4.IsMouseOver)
                {
                    empolyeeStop.lb_id.Content = 4;
                }
                else if (stop_btn5.IsMouseOver)
                {
                    empolyeeStop.lb_id.Content = 5;
                }
                else if (stop_btn6.IsMouseOver)
                {
                    empolyeeStop.lb_id.Content = 6;
                }
                else if (stop_btn7.IsMouseOver)
                {
                    empolyeeStop.lb_id.Content = 7;
                }
                else if (stop_btn8.IsMouseOver)
                {
                    empolyeeStop.lb_id.Content = 8;
                }
                empolyeeStop.ShowDialog();
                Button_Inspection();
            }
            catch
            {

            }
        }

        private void Transfer_Button(object sender, RoutedEventArgs e)
        {
            int number = 0;
            EmpolyeeStop empolyeeStop = new EmpolyeeStop();
            empolyeeStop.lbl_stop.Content = "Transfer";
            if (transfer_btn1.IsMouseOver)
            {
                empolyeeStop.lb_id.Content = 1;
                GlobalVariable.StopId = 1;
            }
            else if (transfer_btn2.IsMouseOver)
            {
                empolyeeStop.lb_id.Content = 2;
                GlobalVariable.StopId = 2;
            }
            else if (transfer_btn3.IsMouseOver)
            {
                empolyeeStop.lb_id.Content = 3;
                GlobalVariable.StopId = 3;
            }
            else if (transfer_btn4.IsMouseOver)
            {
                empolyeeStop.lb_id.Content = 4;
                GlobalVariable.StopId = 4;
            }
            else if (transfer_btn5.IsMouseOver)
            {
                empolyeeStop.lb_id.Content = 5;
                GlobalVariable.StopId = 5;
            }
            else if (transfer_btn6.IsMouseOver)
            {
                empolyeeStop.lb_id.Content = 6;
                GlobalVariable.StopId = 6;
            }
            else if (transfer_btn7.IsMouseOver)
            {
                empolyeeStop.lb_id.Content = 7;
                GlobalVariable.StopId = 7;
            }
            else if (transfer_btn8.IsMouseOver)
            {
                empolyeeStop.lb_id.Content = 8;
                GlobalVariable.StopId = 8;
            }
            empolyeeStop.ShowDialog();
            Button_Inspection();
        }

        private void Bar_Button(object sender, RoutedEventArgs e)
        {
            EmpolyeeBarProduct product = new EmpolyeeBarProduct();



            if (bar_btn1.IsMouseOver)
            {
                product.grid_lbl.Content = 1;
                product.gridBar_lbl.Content = "Button";
            }
            else if (bar_btn2.IsMouseOver)
            {
                product.grid_lbl.Content = 2;
                product.gridBar_lbl.Content = "Button";
            }
            else if (bar_btn3.IsMouseOver)
            {
                product.grid_lbl.Content = 3;
                product.gridBar_lbl.Content = "Button";
            }
            else if (bar_btn4.IsMouseOver)
            {
                product.grid_lbl.Content = 4;
                product.gridBar_lbl.Content = "Button";
            }
            else if (bar_btn5.IsMouseOver)
            {
                product.grid_lbl.Content = 5;
                product.gridBar_lbl.Content = "Button";
            }
            else if (bar_btn6.IsMouseOver)
            {
                product.grid_lbl.Content = 6;
                product.gridBar_lbl.Content = "Button";
            }
            else if (bar_btn7.IsMouseOver)
            {
                product.grid_lbl.Content = 7;
                product.gridBar_lbl.Content = "Button";
            }
            else if (bar_btn8.IsMouseOver)
            {
                product.grid_lbl.Content = 8;
                product.gridBar_lbl.Content = "Button";
            }
            product.ShowDialog();
            Button_Inspection();
        }

        private async void Calculator_Butoon(object sender, RoutedEventArgs e)
        {
            int number = 0;
            if (calc_btn1.IsMouseOver)
            {
                number = 1;
            }
            else if (calc_btn2.IsMouseOver)
            {
                number = 2;
            }
            else if (calc_btn3.IsMouseOver)
            {
                number = 3;
            }
            else if (calc_btn4.IsMouseOver)
            {
                number = 4;
            }
            else if (calc_btn5.IsMouseOver)
            {
                number = 5;
            }
            else if (calc_btn6.IsMouseOver)
            {
                number = 6;
            }
            else if (calc_btn7.IsMouseOver)
            {
                number = 7;
            }
            else if (calc_btn8.IsMouseOver)
            {
                number = 8;
            }
            var resault = await desktopCassaService.GetAllAccountBookAsync(number);
            MessageBox.Show(resault);
        }

        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private async void Pause_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                byte number1 = 0;
                if (pause_btn1.IsMouseOver)
                {
                    number1 = 1;
                }
                if (pause_btn2.IsMouseOver)
                {
                    number1 = 2;
                }
                else if (pause_btn3.IsMouseOver)
                {
                    number1 = 3;
                }
                else if (pause_btn4.IsMouseOver)
                {
                    number1 = 4;
                }
                else if (pause_btn5.IsMouseOver)
                {
                    number1 = 5;
                }
                else if (pause_btn6.IsMouseOver)
                {
                    number1 = 6;
                }
                else if (pause_btn7.IsMouseOver)
                {
                    number1 = 7;
                }
                else if (pause_btn8.IsMouseOver)
                {
                    number1 = 8;
                }
                var res = await desktopCassaService.UpdateAsync(number1);
                Button_Inspection();
            }
            catch
            {
                return;
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ClickCount == 2)
                {
                    if (IsMaximized)
                    {
                        this.WindowState = WindowState.Normal;
                        this.Width = 1080;
                        this.Height = 720;
                        IsMaximized = false;
                    }
                    else
                    {
                        this.WindowState = WindowState.Maximized;
                        IsMaximized = true;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GlobalVariable.UserId = 0;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
