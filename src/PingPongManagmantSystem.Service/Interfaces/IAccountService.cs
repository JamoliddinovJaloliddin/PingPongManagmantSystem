namespace PingPongManagmantSystem.Service.Interfaces
{
    public interface IAccountService
    {
        Task<int> LoginAsync(string password);
    }
}
