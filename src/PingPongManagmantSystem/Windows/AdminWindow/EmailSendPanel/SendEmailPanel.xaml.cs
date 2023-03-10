using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Interfaces.Common;
using PingPongManagmantSystem.Service.Services.AdminService;
using PingPongManagmantSystem.Service.Services.Common;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace PingPongManagmantSystem.Desktop.Windows.AdminWindow.EmailSendPanel
{
    public partial class SendEmailPanel : Window
    {
        IEmailService emailService = new EmailService();
        IUserService userService = new UserService();
        int code = 0;
        public SendEmailPanel()
        {
            InitializeComponent();
            SendEmail();
        }

        private async void SendEmail()
        {
            emailpassoword.IsEnabled = true;
            txtpassoword.IsEnabled = false;

            var resultPassowrd = await emailService.SendAsync();
            code = resultPassowrd;
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



        private async void btn_NewLogin(object sender, RoutedEventArgs e)
        {
            try
            {
                if (emailpassoword.Text.ToString() != "")
                {
                    if (emailpassoword.Text.ToString() == code.ToString())
                    {
                        emailpassoword.IsEnabled = false;
                        txtpassoword.IsEnabled = true;
                        if (txtpassoword.Password.ToString().Count() > 0)
                        {
                            var result = await userService.UpdateAdminAsync(txtpassoword.Password.ToString());
                            if (result)
                            {
                                this.Close();
                                MessageBox.Show("Login o'zgartirildi");

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Parol to'g'ri kelmadi");
                        emailpassoword.Text = null;
                        emailpassoword.IsEnabled = false;
                        txtpassoword.IsEnabled = false;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void btn_EmailSend(object sender, RoutedEventArgs e)
        {
            try
            {
                emailpassoword.Text = null;
                emailpassoword.IsEnabled = true;
                txtpassoword.IsEnabled = false;
                SendEmail();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
