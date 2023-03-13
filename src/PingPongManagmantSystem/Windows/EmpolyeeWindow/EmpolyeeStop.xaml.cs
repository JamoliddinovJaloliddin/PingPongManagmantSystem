using PingPongManagmantSystem.Service.Common.Enums;
using PingPongManagmantSystem.Service.Common.Utils;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface.ButtonService;
using PingPongManagmantSystem.Service.Services.AdminService;
using PingPongManagmantSystem.Service.Services.EmpolyeeService;
using PingPongManagmantSystem.Service.Services.EmpolyeeService.ButtonService;
using PingPongManagmantSystem.Service.ViewModels;
using System.Windows;

#pragma warning disable

namespace PingPongManagmantSystem.Desktop.Windows.EmpolyeeWindow
{
    public partial class EmpolyeeStop : Window
    {
        ICustomerService customerService = new CustomerService();
        IEmpolyeeStopService empolyeeStop = new EmpolyeeStopService();
        IDesktopCassaService desktopCassaService = new DesktopCassaService();
        int pageSize = 15;

        public EmpolyeeStop()
        {
            InitializeComponent();
            RefreshData_ComboBox();
        }

        public async void RefreshData_ComboBox()
        {
            try
            {
                string search = "";
                var customer = await customerService.GetAllAsync(search, new PaginationParams((int)GlobalVariable.Page, pageSize));
                foreach (var item in customer)
                {
                    cb_client.Items.Add(item.Status);
                }
                cb_typePrice.Items.Add(Payment.Naxt);
                cb_typePrice.Items.Add(Payment.VipKarta);
                cb_typePrice.Items.Add(Payment.Karta);

            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private async void Exit_Button(object sender, RoutedEventArgs e)
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
                        var resault = await empolyeeStop.TotalPrice(tableNumbe: byte.Parse(lb_id.Content.ToString()), customer: customer, typeOfPey: cb_typePrice.Text.ToString());
                        var res = desktopCassaService.DeleteAsync(int.Parse(lb_id.Content.ToString()), resault.totalSum);
                        this.Close();
                        MessageBox.Show(resault.Text);
                    }
                    else
                    {
                        var resault = await empolyeeStop.TotalPrice(int.Parse(lb_id.Content.ToString()), customer: customer, typeOfPey: cb_typePrice.Text.ToString());
                        var res = desktopCassaService.DeleteAsync(int.Parse(lb_id.Content.ToString()), resault.totalSum);
                        this.Close();
                        MessageBox.Show(resault.Text);
                    }
                }
                else if (lbl_stop.Content.ToString() == "Transfer")
                {
                    this.Close();
                    EmpolyeeTransferTable transferTable = new EmpolyeeTransferTable();
                    var customer = cb_client.Text.ToString();
                    if (customer == Payment.VipKarta.ToString())
                    {
                        customer = txt_vipCart.Text.ToString();
                        var resault = await empolyeeStop.TotalPrice(tableNumbe: byte.Parse(lb_id.Content.ToString()), customer: customer, typeOfPey: cb_typePrice.Text.ToString());
                        transferTable.ShowDialog();
                        this.Close();
                        var res = empolyeeStop.TransferCreateAsync(int.Parse(lb_id.Content.ToString()), resault.cassa, resault.totalSum);
                    }
                    else
                    {
                        var resault = await empolyeeStop.TotalPrice(int.Parse(lb_id.Content.ToString()), customer: customer, typeOfPey: cb_typePrice.Text.ToString());
                        transferTable.ShowDialog();
                        var res = empolyeeStop.TransferCreateAsync(GlobalVariable.TransferId, resault.cassa, resault.totalSum);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private async void btn_txt(object sender, DependencyPropertyChangedEventArgs e)
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
                MessageBox.Show("Errpr");
            }
        }
    }
}
