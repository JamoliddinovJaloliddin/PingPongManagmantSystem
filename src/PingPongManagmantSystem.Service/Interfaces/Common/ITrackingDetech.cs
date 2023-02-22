using PingPongManagmantSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongManagmantSystem.Service.Interfaces.Common
{
    public interface ITrackingDetech<T> where T : BaseEntity
    {
        public void TrackingDeteched(T entity);
    }
}
