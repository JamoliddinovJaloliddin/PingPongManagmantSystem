namespace PingPongManagmantSystem.Service.Interfaces.AdminIntefaces
{
    public interface ICloudService
    {
        Task<string> GetAllBarAsync(string from);
        Task<string> GetAllEmpolyeeAsync(string from);
        Task<string> GetAllSportAsync(string from);
        Task<string> GetAllTableAsync(string from);
    }
}
