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
                //CassaPanelDesktop adminPanel1 = new CassaPanelDesktop();
                //AdminPanel adminPanel2 = new AdminPanel();
                //if (txtpassoword.Password.ToString() == "1")
                //{
                //    adminPanel1.Show();
                //    this.Close();
                //}
                //else
                //{
                //    adminPanel2.Show();
                //    this.Close();
                //}
                IAccountService accountService = new AccountService();
                var resault = await accountService.LoginAsync(txtpassoword.Password.ToString());
                if (resault == false)
                {
                    AdminPanel adminPanel = new AdminPanel();
                    this.Close();
                    adminPanel.ShowDialog();

                    //MessageBox.Show("Parol noto'g'ri kiritildi");
                }
                else
                {
                    var user = await accountService.WindowtAsync(txtpassoword.Password.ToString());
                    if (user.IsAdmin == 0)
                    {
                        CassaPanelDesktop cassaPanelDesktop = new CassaPanelDesktop();
                        var result = await tableStatisticService.CreateAsync();
                        MessageBox.Show(resault.ToString());
                        this.Close();
                        cassaPanelDesktop.ShowDialog();
                    }
                    else
                    {
                        AdminPanel adminPanel = new AdminPanel();
                        this.Close();
                        adminPanel.ShowDialog();

                    }
                }
            }
            catch
            {
                MessageBox.Show("Xatolik");
            }
        }
    }
}
