using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface.ButtonService;
using PingPongManagmantSystem.Service.Services.EmpolyeeService;
using PingPongManagmantSystem.Service.Services.EmpolyeeService.ButtonService;
using PingPongManagmantSystem.Service.ViewModels;
using System.Windows;

namespace PingPongManagmantSystem.Desktop.Windows.EmpolyeeWindow
{
    public partial class EmpolyeeTransferTable : Window
    {
        IEmpolyeeTransferService empolyeeTransfer = new EmpolyeeTransferService();
        IDesktopCassaService cassaService = new DesktopCassaService();



        public EmpolyeeTransferTable()
        {
            InitializeComponent();
            ComboBox_Refresh();
        }

        private async void ComboBox_Refresh()
        {
            var resault = await empolyeeTransfer.GetAllAsync();
            foreach (var item in resault)
            {
                combo_trn.Items.Add(item);
            }
        }

        private async void Transfer_button(object sender, RoutedEventArgs e)
        {
            try
            {
                if (combo_trn.Text != null)
                {
                    GlobalVariable.TransferId = int.Parse(combo_trn.Text.ToString());
                    this.Close();
                }
            }
            catch
            {

            }

        }

        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
