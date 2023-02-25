using PingPongManagmantSystem.Desktop.Windows;
using PingPongManagmantSystem.Desktop.Windows.EmpolyeeWindow;
using System.Windows;
using System.Windows.Input;

namespace PingPongManagmantSystem
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit_Button(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btn_Login(object sender, RoutedEventArgs e)
        {
            try
            {
                CassaPanelDesktop adminPanel1 = new CassaPanelDesktop();
                AdminPanel adminPanel2 = new AdminPanel();
                if (txtpassoword.Password.ToString() == "1")
                {
                    adminPanel1.Show();
                    this.Close();
                }
                else
                {
                    adminPanel2.Show();
                    this.Close();
                }
                //IAccountService accountService = new AccountService();
                //var resault = await accountService.LoginAsync(txtpassword.Password.ToString());
                //if (resault == false)
                //{
                //    MessageBox.Show("Parol noto'g'ri kiritildi");
                //}
                //else
                //{
                //    var user = await accountService.WindowtAsync(txtpassword.Password.ToString());
                //    if (user.IsAdmin == 0)
                //    {
                //        CassaPanelDesktop cassaPanelDesktop = new CassaPanelDesktop();
                //        cassaPanelDesktop.Show();
                //        this.Close();
                //    }
                //    else if (user.IsAdmin == 1)
                //    {
                //        AdminPanel adminPanel = new AdminPanel();
                //        adminPanel.Show();
                //        this.Close();
                //    }
                //}
            }
            catch
            {
                MessageBox.Show("Xatolik");
            }
        }
    }
}
