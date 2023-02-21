using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;
using PingPongManagmantSystem.Service.Services.EmpolyeeService;
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
                EmpolyeeStop empolyeeStop = new EmpolyeeStop();
                if (combo_trn.Text != null)
                {
                    empolyeeStop.lb_id.Content = combo_trn.Text;
                    this.Close();
                }
            }
            catch
            {

            }

        }
    }
}
