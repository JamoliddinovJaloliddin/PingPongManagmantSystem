using PingPongManagmantSystem.Service.Common;
using PingPongManagmantSystem.Service.Helpers;
using PingPongManagmantSystem.Service.Interfaces.AdminIntefaces;
using PingPongManagmantSystem.Service.Services.AdminServices;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace PingPongManagmantSystem.Desktop.Windows.AdminWindow.AddPanel
{
    public partial class CloudPanel : Window
    {
        ICloudService cloudService = new CloudService();
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

        private async void ToSend_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                if (from_txt.Text.ToString() != "" && from_txt.Text.Count() == 7)
                {
                    string from = from_txt.Text.ToString();

                    var resultText = await InspectionDate.Inspection(from);


                    if (resultText)
                    {
                        if (type_lbl.Content.ToString() == "Bar")
                        {
                            var resultWord = await cloudService.GetAllBarAsync(from);
                            if (resultWord != "")
                            {
                                this.Close();
                                var result = await SendGoogle.SendFileGoogle("Bar");
                                if (result)
                                {
                                    MessageBox.Show("Cloudga saqlandi");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Kiritilgan sana bo'yicha ma'lumot yo'q");
                            }
                        }
                        else if (type_lbl.Content.ToString() == "Empolyee")
                        {
                            var resultWord = await cloudService.GetAllEmpolyeeAsync(from);
                            if (resultWord != "")
                            {
                                this.Close();
                                var result = await SendGoogle.SendFileGoogle("Ishchi");
                                if (result)
                                {
                                    MessageBox.Show("Cloudga saqlandi");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Kiritilgan sana bo'yicha ma'lumot yo'q");
                            }
                        }
                        else if (type_lbl.Content.ToString() == "Sport")
                        {
                            var resultWord = await cloudService.GetAllSportAsync(from);
                            if (resultWord != "")
                            {
                                this.Close();
                                var result = await SendGoogle.SendFileGoogle("Sport");
                                if (result)
                                {
                                    MessageBox.Show("Cloudga saqlandi");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Kiritilgan sana bo'yicha ma'lumot yo'q");
                            }
                        }
                        else if (type_lbl.Content.ToString() == "Table")
                        {
                            var resultWord = await cloudService.GetAllTableAsync(from);
                            if (resultWord != "")
                            {
                                this.Close();
                                var result = await SendGoogle.SendFileGoogle("Zal");

                                if (result)
                                {
                                    MessageBox.Show("Cloudga saqlandi");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Kiritilgan sana bo'yicha ma'lumot yo'q");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sana to'g'ri formatda kiritilmadi");
                    }
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
