namespace PingPongManagmantSystem.Service.Interfaces.Common
{
    public interface IEmailService
    {
        public Task<int> SendAsync();
    }
}
