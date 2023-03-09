using System.Windows;
using System.Windows.Input;

namespace PingPongManagmantSystem.Desktop.Windows.AdminWindow.AddPanel
{
    public partial class CloudPanel : Window
    {
        public CloudPanel()
        {
            InitializeComponent();
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

        private void ToSend_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                if (from_txt.Text.ToString() != "" && upTo_txt.Text.ToString() != "")
                {

                }
                else
                {
                    MessageBox.Show("Ma'lumot to'liq kiritilmadi");
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}
