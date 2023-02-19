using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Common.Enums;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;
using PingPongManagmantSystem.Service.Services.AdminService;
using PingPongManagmantSystem.Service.Services.EmpolyeeService;
using System.Windows;

namespace PingPongManagmantSystem.Desktop.Windows.EmpolyeeWindow
{
    public partial class EmpolyeeStop : Window
    {
        ICustomerService customerService = new CustomerService();
        IEmpolyeeStopService empolyeeStop = new EmpolyeeStopService();
        CassaPanelDesktop cassaPanelDesktop = new CassaPanelDesktop();

        public EmpolyeeStop()
        {
            InitializeComponent();
            RefreshData_ComboBox();
        }

        public async void RefreshData_ComboBox()
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
            }
            catch
            {

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
             
                var customer = cb_client.Text.ToString();
                if (customer == Payment.VipKarta.ToString())
                {
                    customer = txt_vipCart.Text.ToString();
                    var resault = await empolyeeStop.TotalPrice(tableNumbe: byte.Parse(lb_id.Content.ToString()), customer: customer);
                    if (resault.Resault)
                    {
                        switch (byte.Parse(lb_id.Content.ToString()))
                        {
                            case 1:
                                DesktopCassaService cassaService = new DesktopCassaService();
                                DesktopCassa desktopCassa = new DesktopCassa();
                               
                                desktopCassa.Play = true;
                                desktopCassa.StolNumber = 1;
                                var res =  await  cassaService.UpdateAsync(desktopCassa);
                                cassaPanelDesktop.ply_btn1.IsEnabled = true;
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                            case 4:
                                break;
                            case 5:
                                break;
                            case 6:
                                break;
                            case 7:
                                break;
                            case 8:
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    var resault = await empolyeeStop.TotalPrice(tableNumbe: byte.Parse(lb_id.Content.ToString()), customer: customer);
                    if (resault.Resault)
                    {
                        switch (byte.Parse(lb_id.Content.ToString()))
                        {
                            case 1:
                                DesktopCassaService cassaService = new DesktopCassaService();
                                DesktopCassa desktopCassa = new DesktopCassa();

                                desktopCassa.StolNumber = 1;
                                var res = await cassaService.UpdateAsync(desktopCassa);
                                cassaPanelDesktop.Button_Inspection();
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                            case 4:
                                break;
                            case 5:
                                break;
                            case 6:
                                break;
                            case 7:
                                break;
                            case 8:
                                break;
                            default:
                                break;
                        }
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
            }
            catch
            {

            }
        }
    }
}
