namespace PingPongManagmantSystem.Service.Interfaces.AccountServices
{
    public interface IAccountService
    {
        Task<int> LoginAsync(string password);
    }
}
