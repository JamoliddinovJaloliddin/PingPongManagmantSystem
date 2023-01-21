using System.Windows;

namespace PingPongManagmantSystem.Desktop.Windows.EmpolyeeWindow
{
    /// <summary>
    /// Interaction logic for CassaPanelDesktop.xaml
    /// </summary>
    public partial class CassaPanelDesktop : Window
    {
        public CassaPanelDesktop()
        {
            InitializeComponent();
        }

        private void Bar_Click(object sender, RoutedEventArgs e)
        {
            EmpolyeeBarProduct product = new EmpolyeeBarProduct();
            product.Show();
        }

        private void Sport_Click(object sender, RoutedEventArgs e)
        {
            EmpolyeeSportProduct product = new EmpolyeeSportProduct();
            product.Show();
        }

        private void Card_Click(object sender, RoutedEventArgs e)
        {
            EmpolyeeCardRegister empolyeeCardRegister = new EmpolyeeCardRegister();
            empolyeeCardRegister.Show();
        }

        private void Play_Button(object sender, RoutedEventArgs e)
        {

        }

        private void Pause_Button(object sender, RoutedEventArgs e)
        {

        }

        private void Stop_Button(object sender, RoutedEventArgs e)
        {
            EmpolyeeStop empolyeeStop = new EmpolyeeStop();
            empolyeeStop.Show();
        }

        private void Transfer_Button(object sender, RoutedEventArgs e)
        {
            EmpolyeeTransferTable empolyeeTransferTable = new EmpolyeeTransferTable();
            empolyeeTransferTable.Show();
        }

        private void Bar_Button(object sender, RoutedEventArgs e)
        {
            EmpolyeeBarProduct product = new EmpolyeeBarProduct();
            product.Show();
        }

        private void Calculator_Butoon(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("");
        }

        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
