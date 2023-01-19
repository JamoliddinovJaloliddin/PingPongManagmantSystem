using PingPongManagmantSystem.Domain.Common;

namespace PingPongManagmantSystem.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = String.Empty;
        public string PassportInfo { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public bool IsAdmin { get; set; }
    }
}
