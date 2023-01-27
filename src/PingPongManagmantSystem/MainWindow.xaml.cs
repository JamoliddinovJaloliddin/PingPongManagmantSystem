using PingPongManagmantSystem.Desktop.Windows;
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

        private async void btn_Login(object sender, MouseButtonEventArgs e)
        {

            try
            {
                AdminPanel adminPanel = new AdminPanel();
                adminPanel.Show();
                this.Close();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
