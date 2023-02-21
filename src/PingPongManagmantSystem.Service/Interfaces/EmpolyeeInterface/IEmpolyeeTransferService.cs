using PingPongManagmantSystem.Domain.Entities;

namespace PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface
{
    public interface IEmpolyeeTransferService
    {
        public Task<IList<int>> GetAllAsync();
        
    }
}
