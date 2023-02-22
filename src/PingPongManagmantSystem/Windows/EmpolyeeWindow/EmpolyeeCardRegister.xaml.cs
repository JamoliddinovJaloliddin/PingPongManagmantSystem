using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;
using PingPongManagmantSystem.Service.Services.EmpolyeeService;
using System.Windows;

namespace PingPongManagmantSystem.Desktop.Windows.EmpolyeeWindow
{
    public partial class EmpolyeeCardRegister : Window
    {
        ICardService cardService = new CardService();

        public EmpolyeeCardRegister()
        {
            InitializeComponent();
        }

        private async void Add_Button(object sender, RoutedEventArgs e)
        {
            if (password_card.Text != "" && limit_card.Text != "" && price_card.Text != "" &&
                combo_card.Text != "" && phone_card.Text != "")
            {
                Card card = new Card();
                card.CardNumber = password_card.Text.ToString();
                card.TimeLimit = double.Parse(limit_card.Text.ToString());
                card.Price = double.Parse(price_card.Text.ToString());
                card.Payment = combo_card.Text;
                card.Phone = phone_card.Text;

                var resault = await cardService.CreateAsync(card);
                if (resault)
                {
                    password_card.Text = null;
                    limit_card.Text = null;
                    price_card.Text = null;
                    combo_card.Text = null;
                    phone_card.Text = null;
                }
            }
            else
            {
                MessageBox.Show("To'ldirilmagan qator");
            }
        }

        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
