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

        private void btn_Login(object sender, MouseButtonEventArgs e)
        {
            if (int.Parse(txtpassword.Password.ToString()) == 1)
            {
                AdminPanel adminPanel = new AdminPanel();
                adminPanel.Show();
                this.Close();
            }
            else if (int.Parse(txtpassword.Password.ToString()) == 2)
            {
                CassaPanelDesktop cassaPanelDesktop = new CassaPanelDesktop();
                cassaPanelDesktop.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Noto'g'ti parol kiritildi");
                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
