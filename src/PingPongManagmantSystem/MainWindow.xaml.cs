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
            if (int.Parse(txtpassword.Password.ToString()) > 0)
            {
                MessageBox.Show("Create");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
