using PingPongManagmantSystem.Domain.Entities;

namespace PingPongManagmantSystem.Service.Interfaces.AdminInteface
{
    public interface ITimeService
    {
        Task<IList<Time>> GetAll();
        Task<bool> UpdateAsync(Time time);
    }
}
