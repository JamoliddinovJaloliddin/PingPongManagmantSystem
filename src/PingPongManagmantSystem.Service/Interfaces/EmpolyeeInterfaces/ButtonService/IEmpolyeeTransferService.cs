namespace PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface.ButtonService
{
    public interface IEmpolyeeTransferService
    {
        public Task<IList<int>> GetAllAsync();

        public Task<bool> CheckTransfer();

    }
}
