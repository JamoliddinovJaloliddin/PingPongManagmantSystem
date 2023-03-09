using PingPongManagmantSystem.Domain.Common;

namespace PingPongManagmantSystem.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string PassportInfo { get; set; } = String.Empty;
        public string PasswordHasher { get; set; } = String.Empty;
        public string Salt { get; set; } = String.Empty;
        public int IsAdmin { get; set; }
    }
}
