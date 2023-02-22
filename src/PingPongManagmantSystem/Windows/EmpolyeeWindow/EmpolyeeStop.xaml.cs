using PingPongManagmantSystem.Service.Common.Enums;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;
using PingPongManagmantSystem.Service.Services.AdminService;
using PingPongManagmantSystem.Service.Services.EmpolyeeService;
using PingPongManagmantSystem.Service.ViewModels;
using System.Threading.Tasks;
using System.Windows;

namespace PingPongManagmantSystem.Desktop.Windows.EmpolyeeWindow
{
    public partial class EmpolyeeStop : Window
    {
        ICustomerService customerService = new CustomerService();
        IEmpolyeeStopService empolyeeStop = new EmpolyeeStopService();
        IDesktopCassaService desktopCassaService = new DesktopCassaService();
        CassaPanelDesktop cassaPanelDesktop = new CassaPanelDesktop();


        public EmpolyeeStop()
        {
            InitializeComponent();
            _ = RefreshData_ComboBox();
        }

        public async Task<int> RefreshData_ComboBox()
        {
            try
            {
                var customer = await customerService.GetAllAsync();
                foreach (var item in customer)
                {
                    cb_client.Items.Add(item.Status);
                }
                cb_typePrice.Items.Add(Payment.Naxt);
                cb_typePrice.Items.Add(Payment.VipKarta);
                cb_typePrice.Items.Add(Payment.Karta);
                return 1;
            }
            catch
            {
                return 1;
            }
        }

        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void Account_button(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lbl_stop.Content.ToString() == "Stop")
                {
                    var customer = cb_client.Text.ToString();
                    if (customer == Payment.VipKarta.ToString())
                    {
                        customer = txt_vipCart.Text.ToString();
                        var resault = await empolyeeStop.TotalPrice(tableNumbe: byte.Parse(lb_id.Content.ToString()), customer: customer);
                        var res = desktopCassaService.DeleteAsync(int.Parse(lb_id.Content.ToString()));
                        MessageBox.Show(resault.Text);
                    }
                    else
                    {
                        var resault = await empolyeeStop.TotalPrice(int.Parse(lb_id.Content.ToString()), customer: customer);
                        var res = desktopCassaService.DeleteAsync(int.Parse(lb_id.Content.ToString()));
                        MessageBox.Show(resault.Text);
                    }
                }
                else if (lbl_stop.Content.ToString() == "Transfer")
                {
                    EmpolyeeTransferTable transferTable = new EmpolyeeTransferTable();
                    var customer = cb_client.Text.ToString();
                    if (customer == Payment.VipKarta.ToString())
                    {
                        customer = txt_vipCart.Text.ToString();
                        var resault = await empolyeeStop.TotalPrice(tableNumbe: byte.Parse(lb_id.Content.ToString()), customer: customer);
                        transferTable.ShowDialog();
                        this.Close();
                        var res = empolyeeStop.TransferCreateAsync(int.Parse(lb_id.Content.ToString()), resault.cassa);
                    }
                    else
                    {
                        var resault = await empolyeeStop.TotalPrice(int.Parse(lb_id.Content.ToString()), customer: customer);
                        this.Close();
                        transferTable.ShowDialog();
                        var res = empolyeeStop.TransferCreateAsync(GlobalVariable.TransferId, resault.cassa);


                    }
                }
                this.Close();
            }
            catch
            {

            }
        }

        private void Update_button(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch
            {

            }

        }

        private void btn_txt(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                if (cb_typePrice.Text == "VipKarta")
                {
                    txt_vipCart.IsEnabled = true;
                }
                else
                {
                    txt_vipCart.Text = "";
                    txt_vipCart.IsEnabled = false;
                }
            }
            catch
            {

            }
        }
    }
}
