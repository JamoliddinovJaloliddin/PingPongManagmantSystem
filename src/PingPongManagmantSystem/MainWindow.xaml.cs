using PingPongManagmantSystem.Desktop.Windows;
using PingPongManagmantSystem.Desktop.Windows.EmpolyeeWindow;
using PingPongManagmantSystem.Service.Interfaces;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface.StatisticSrvices;
using PingPongManagmantSystem.Service.Services;
using PingPongManagmantSystem.Service.Services.AdminServices.StatisticServices;
using System.Windows;
using System.Windows.Input;

namespace PingPongManagmantSystem
{
    public partial class MainWindow : Window
    {
        ITableStatisticService tableStatisticService = new TableStatisticService();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit_Button(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private async void btn_Login(object sender, RoutedEventArgs e)
        {
            try
            {
                IAccountService accountService = new AccountService();
                var resault = await accountService.LoginAsync(txtpassoword.Password.ToString());
                if (resault == 0)
                {
                    CassaPanelDesktop cassaPanelDesktop = new CassaPanelDesktop();
                    cassaPanelDesktop.ShowDialog();
                }
                else if (resault == 1)
                {
                    AdminPanel adminPanel = new AdminPanel();
                    adminPanel.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Kiritilgan login mavjud emas");
                }
            }
            catch
            {
                MessageBox.Show("Xatolik");
            }
        }
    }
}
