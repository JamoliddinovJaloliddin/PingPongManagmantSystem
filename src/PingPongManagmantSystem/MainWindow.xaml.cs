using PingPongManagmantSystem.Desktop.Windows;
using PingPongManagmantSystem.Desktop.Windows.AdminWindow.EmailSendPanel;
using PingPongManagmantSystem.Desktop.Windows.EmpolyeeWindow;
using PingPongManagmantSystem.Service.Interfaces.AccountServices;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface.StatisticSrvices;
using PingPongManagmantSystem.Service.Interfaces.Common;
using PingPongManagmantSystem.Service.Services;
using PingPongManagmantSystem.Service.Services.AccountServices;
using PingPongManagmantSystem.Service.Services.AdminServices.StatisticServices;
using PingPongManagmantSystem.Service.Services.Common;
using System.Windows;
using System.Windows.Input;

namespace PingPongManagmantSystem
{
    public partial class MainWindow : Window
    {
        
        IAccountService accountService = new AccountService();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit_Button(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private async void btn_Login(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtpassoword.Password.ToString() != "")
                {
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
            }
            catch
            {
                MessageBox.Show("Xatolik");
            }
        }

        private async void btn_EmailSend(object sender, RoutedEventArgs e)
        {
            try
            { 
                SendEmailPanel sendEmailPanel = new SendEmailPanel();
                this.Close();
                sendEmailPanel.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
