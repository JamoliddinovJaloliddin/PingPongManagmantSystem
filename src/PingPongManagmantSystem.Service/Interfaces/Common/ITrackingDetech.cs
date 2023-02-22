using PingPongManagmantSystem.Domain.Common;

namespace PingPongManagmantSystem.Service.Interfaces.Common
{
    public interface ITrackingDetech<T> where T : BaseEntity
    {
        public void TrackingDeteched(T entity);
    }
}
