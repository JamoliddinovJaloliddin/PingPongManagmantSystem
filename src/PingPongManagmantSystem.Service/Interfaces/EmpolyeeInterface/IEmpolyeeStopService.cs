namespace PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface
{
    public interface IEmpolyeeStopService
    {
        public Task<(bool Resault, string Text)> TotalPrice(byte tableNumbe, string customer);
    }
}
