using PingPongManagmantSystem.Domain.Entities;

namespace PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface.ButtonService
{
    public interface IEmpolyeeStopService
    {
        public Task<(bool Resault, string Text, DesktopCassa cassa)> TotalPrice(int tableNumbe, string customer, string typeOfPey);
        Task<bool> TransferCreateAsync(int id, DesktopCassa cassa);
    }
}
