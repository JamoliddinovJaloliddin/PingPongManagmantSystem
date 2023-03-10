using PingPongManagmantSystem.Domain.Entities;

namespace PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface.ButtonService
{
    public interface IEmpolyeeStopService
    {
        public Task<(bool Resault, string Text, DesktopCassa cassa, double totalSum)> TotalPrice(int tableNumbe, string customer, string typeOfPey);
        Task<bool> TransferCreateAsync(int id, DesktopCassa cassa, double totalPrice);
    }
}
