using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;
using PingPongManagmantSystem.Service.Services;
using System;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Controls;

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
            var res = await desktopCassaService.CreateAsync(cassa);
        }

        private async void Pause_Button(object sender, RoutedEventArgs e)
        {
            DesktopCassa cassa = new DesktopCassa();

            if (pause_btn1.IsMouseOver)
            {
                cassa.StolNumber = 1;
                cassa.Pause = true;
                cassa.Stop = false;
                cassa.Busy = true;
            }
            else if (pause_btn2.IsMouseOver)
            {
                cassa.StolNumber = 2;
                cassa.Pause = true;
                cassa.Stop = false;
                cassa.Busy = true;
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
