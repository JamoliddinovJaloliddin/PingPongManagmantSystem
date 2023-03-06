using PingPongManagmantSystem.Service.Common.Utils;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Services.AdminService;
using PingPongManagmantSystem.Service.ViewModels;
using System.Collections.Generic;
using System.Windows;

namespace PingPongManagmantSystem.Desktop.Windows.AdminWindow.AddPanel
{
    /// <summary>
    /// Interaction logic for UserPanel.xaml
    /// </summary>
    public partial class UserPanel : Window
    {
        IUserService userService = new UserService();
        int pageSize = 15;
        public UserPanel()
        {
            InitializeComponent();
            Click();
        }

        public async void Click()
        {

            List<UserView> user = (List<UserView>)await userService.GetAllAsync("", new PaginationParams(1, pageSize));
            userDataGrid.ItemsSource = user;
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {
            UserAddPanel userAddPanel = new UserAddPanel();
            //userAddPanel.addBut.IsEnabled = false;
            //if (userAddPanel.updBut.IsEnabled == false)
            //{
            //    userAddPanel.updBut.IsEnabled = true;
            //}
            userAddPanel.Show();
            var item = (UserView)userDataGrid.SelectedItem;
            var res = userService.UpdateAsync(item);
            Click();
        }

        private void Delete_Button(object sender, RoutedEventArgs e)
        {
            var item = (UserView)userDataGrid.SelectedItem;
            int res = item.Id;
            var resault = userService.DeleteAsync(res);
            Click();
        }
    }
}
