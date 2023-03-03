using PingPongManagmantSystem.Domain.Entities;

namespace PingPongManagmantSystem.Service.Interfaces.Common
{
    public interface ITrackingDetech
    {
        public void TrackingDeteched(BarCount entity);
        public void TrackingDeteched(BarProduct entity);
        public void TrackingDeteched(Card entity);
        public void TrackingDeteched(Cassa entity);
        public void TrackingDeteched(Customer entity);
        public void TrackingDeteched(DesktopCassa entity);
        public void TrackingDeteched(PingPongTable entity);
        public void TrackingDeteched(SportCount entity);
        public void TrackingDeteched(SportProduct entity);
        public void TrackingDeteched(Statistic entity);
        public void TrackingDeteched(Time entity);
        public void TrackingDeteched(Transfer entity);
        public void TrackingDeteched(User entity);
    }
}
