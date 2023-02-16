using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;
using PingPongManagmantSystem.Service.Services.EmpolyeeService;
using System.Windows;

namespace PingPongManagmantSystem.Desktop.Windows.EmpolyeeWindow
{
    /// <summary>
    /// Interaction logic for CassaPanelDesktop.xaml
    /// </summary>
    public partial class CassaPanelDesktop : Window
    {
        IDesktopCassaService desktopCassaService = new DesktopCassaService();
        public CassaPanelDesktop()
        {
            InitializeComponent();
        }

        public async void RefreshData()
        {

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
            DesktopCassa cassa = new DesktopCassa();
            if (ply_btn1.IsMouseOver)
            {
                ply_btn1.IsEnabled = false;
                cassa.StolNumber = 1;
                cassa.Pause = false;
                cassa.Stop = false;
                cassa.Busy = true;
                cassa.BarSum = 0;
            }
            else if (ply_btn2.IsMouseOver)
            {
                ply_btn2.IsEnabled = false;
                cassa.StolNumber = 2;
                cassa.Pause = false;
                cassa.Stop = false;
                cassa.Busy = true;
                cassa.BarSum = 0;
            }
            else if (ply_btn3.IsMouseOver)
            {
                ply_btn3.IsEnabled = false;
                cassa.StolNumber = 3;
                cassa.Pause = false;
                cassa.Stop = false;
                cassa.Busy = true;
                cassa.BarSum = 0;
            }
            else if (ply_btn4.IsMouseOver)
            {
                ply_btn4.IsEnabled = false;
                cassa.StolNumber = 4;
                cassa.Pause = false;
                cassa.Stop = false;
                cassa.Busy = true;
                cassa.BarSum = 0;
            }
            else if (ply_btn5.IsMouseOver)
            {
                ply_btn5.IsEnabled = false;
                cassa.StolNumber = 5;
                cassa.Pause = false;
                cassa.Stop = false;
                cassa.Busy = true;
                cassa.BarSum = 0;
            }
            else if (ply_btn6.IsMouseOver)
            {
                ply_btn6.IsEnabled = false;
                cassa.StolNumber = 6;
                cassa.Pause = false;
                cassa.Stop = false;
                cassa.Busy = true;
                cassa.BarSum = 0;
            }
            else if (ply_btn7.IsMouseOver)
            {
                ply_btn7.IsEnabled = false;
                cassa.StolNumber = 7;
                cassa.Pause = false;
                cassa.Stop = false;
                cassa.Busy = true;
                cassa.BarSum = 0;
            }
            else if (ply_btn8.IsMouseOver)
            {
                ply_btn8.IsEnabled = false;
                cassa.StolNumber = 8;
                cassa.Pause = false;
                cassa.Stop = false;
                cassa.Busy = true;
                cassa.BarSum = 0;
            }

            var res = await desktopCassaService.CreateAsync(cassa);
        }

        private async void Pause_Button(object sender, RoutedEventArgs e)
        {
            DesktopCassa cassa = new DesktopCassa();

            if (pause_btn1.IsMouseOver)
            {
                cassa.StolNumber = 1;
                cassa.Pause = false;
                cassa.Stop = false;
                cassa.Busy = true;
                ply_btn1.IsEnabled = true;
                pause_btn1.IsEnabled = false;
            }
            else if (pause_btn2.IsMouseOver)
            {
                cassa.StolNumber = 2;
                cassa.Pause = true;
                cassa.Stop = false;
                cassa.Busy = true;
                ply_btn2.IsEnabled = true;
                pause_btn2.IsEnabled = false;
            }
            else if (pause_btn3.IsMouseOver)
            {
                cassa.StolNumber = 3;
                cassa.Pause = true;
                cassa.Stop = false;
                cassa.Busy = true;
                ply_btn3.IsEnabled = true;
                pause_btn3.IsEnabled = false;
            }
            else if (pause_btn3.IsMouseOver)
            {
                cassa.StolNumber = 3;
                cassa.Pause = true;
                cassa.Stop = false;
                cassa.Busy = true;
                ply_btn3.IsEnabled = true;
                pause_btn3.IsEnabled = false;
            }
            else if (pause_btn4.IsMouseOver)
            {
                cassa.StolNumber = 4;
                cassa.Pause = true;
                cassa.Stop = false;
                cassa.Busy = true;
                ply_btn4.IsEnabled = true;
                pause_btn4.IsEnabled = false;
            }
            else if (pause_btn5.IsMouseOver)
            {
                cassa.StolNumber = 5;
                cassa.Pause = true;
                cassa.Stop = false;
                cassa.Busy = true;
                ply_btn5.IsEnabled = true;
                pause_btn5.IsEnabled = false;
            }
            else if (pause_btn6.IsMouseOver)
            {
                cassa.StolNumber = 6;
                cassa.Pause = true;
                cassa.Stop = false;
                cassa.Busy = true;
                ply_btn6.IsEnabled = true;
                pause_btn6.IsEnabled = false;
            }
            else if (pause_btn7.IsMouseOver)
            {
                cassa.StolNumber = 7;
                cassa.Pause = true;
                cassa.Stop = false;
                cassa.Busy = true;
                ply_btn7.IsEnabled = true;
                pause_btn7.IsEnabled = false;
            }
            else if (pause_btn8.IsMouseOver)
            {
                cassa.StolNumber = 8;
                cassa.Pause = true;
                cassa.Stop = false;
                cassa.Busy = true;
                ply_btn8.IsEnabled = true;
                pause_btn8.IsEnabled = false;
            }

            var res = await desktopCassaService.UpdateAsync(cassa);
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
