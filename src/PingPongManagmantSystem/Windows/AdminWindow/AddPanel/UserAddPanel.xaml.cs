using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Services.AdminService;
using System.Windows;

#pragma warning disable

namespace PingPongManagmantSystem.Desktop.Windows.AdminWindow.AddPanel
{
    public partial class UserAddPanel : Window
    {
        IUserService userService = new UserService();

        public UserAddPanel()
        {
            InitializeComponent();

        }
        private async void Add_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                if (name.Text != "" && passportinfo.Text != "" && password.Text != "")
                {
                    User user = new User();
                    user.Name = name.Text.ToString();
                    user.PassportInfo = passportinfo.Text.ToString();
                    user.PasswordHasher = password.Text.ToString();
                    user.IsAdmin = 0;

                    var resault = await userService.CreateAsync(user);
                    if (resault)
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Parolni o'zgartiring");
                    }
                }
                else
                {
                    MessageBox.Show("Ma'lumotlar to'liq kiritilmadi");
                }
            }
            catch
            {
                MessageBox.Show("Ma'lumot noto'g'ri kiritildi");
            }
        }
        private async void Update_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                if (name.Text != "" && passportinfo.Text != "" && password.Text != "")
                {
                    User user = new User();

                    user.Id = int.Parse(id.Content.ToString());
                    user.Name = name.Text;
                    user.PassportInfo = passportinfo.Text;
                    //user.Password = password.Text;
                    user.IsAdmin = 0;
                    var res = await userService.UpdateAsync(user);
                    if (res)
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Parolni o'zgartiring");
                    }
                }
                else
                {
                    MessageBox.Show("Ma'lumotlar to'liq kiritilmadi");
                }
            }
            catch
            {
                MessageBox.Show("Ma'lumot noto'g'ri kiritildi");
            }
        }
        private async void Exit_Button(object sender, System.Windows.Input.MouseButtonEventArgs e)
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
    }
}
