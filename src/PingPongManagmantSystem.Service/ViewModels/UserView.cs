using PingPongManagmantSystem.Domain.Entities;

namespace PingPongManagmantSystem.Service.ViewModels
{
    public class UserView
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Passport { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;

        public static implicit operator User(UserView userView)
        {
            return new User()
            {
                Id = userView.Id,
                Name = userView.Name,
                PassportInfo = userView.Passport,
                //Password = userView.Password
            };
        }
    }
}
