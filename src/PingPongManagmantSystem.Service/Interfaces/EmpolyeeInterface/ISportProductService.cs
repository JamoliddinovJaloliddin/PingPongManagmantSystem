using PingPongManagmantSystem.Domain.Entities;

namespace PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface
{
    public interface ISportProductService
    {
        public Task<IList<SportProduct>> GetAllAsync();
        public Task<bool> BuyAsync();
    }
}
