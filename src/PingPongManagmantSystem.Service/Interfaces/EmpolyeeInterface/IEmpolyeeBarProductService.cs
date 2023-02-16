using PingPongManagmantSystem.Service.ViewModels;

namespace PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface
{
    public interface IEmpolyeeBarProductService
    {
        Task<IList<BarView>> GetAllAsync();
    }
}
