using PingPongManagmantSystem.Desktop.Windows.AdminWindow.AddPanel;
using System.Windows;

namespace PingPongManagmantSystem.Desktop.Windows
{
    /// <summary>
    /// Interaction logic for CustomerPanel.xaml
    /// </summary>
    public partial class CustomerPanel : Window
    {
        public CustomerPanel()
        {
            InitializeComponent();
        }

        private void Customer_AddButton(object sender, RoutedEventArgs e)
        {
            CustomerAddPanel customerAddPanel = new CustomerAddPanel();
            customerAddPanel.Show();
            this.Close();
        }
    }
}
