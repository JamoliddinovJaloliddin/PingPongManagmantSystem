using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Services.AdminService;
using System.Windows;

namespace PingPongManagmantSystem.Desktop.Windows.AdminWindow.AddPanel
{
    /// <summary>
    /// Interaction logic for UserAddPanel.xaml
    /// </summary>
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
                User user = new User();
                user.Name = name.Text.ToString();
                user.PassportInfo = passportinfo.Text.ToString();
                user.Password = password.Text.ToString();
                user.IsAdmin = 0;

                var resault = await userService.CreateAsync(user);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error catch");
            }
        }

        private async void Update_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                if (name.Text != null && passportinfo.Text != null && password.Text != null)
                {
                    User user = new User();

                    user.Id = int.Parse(id.Content.ToString());
                    user.Name = name.Text;
                    user.PassportInfo = passportinfo.Text;
                    user.Password = password.Text;
                    user.IsAdmin = 0;
                    var res = await userService.UpdateAsync(user);
                    if (res)
                    {
                        this.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Ma'lumotlarni to'ldiring");
                }
            }
            catch
            {

            }
        }


    }
}
