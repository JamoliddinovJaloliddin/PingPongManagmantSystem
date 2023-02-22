using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Common;
using PingPongManagmantSystem.Service.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongManagmantSystem.Service.Services.Common
{
    public class TrackingDetech<T> : ITrackingDetech<T> where T : BaseEntity
    {
        AppDbContext _appDbContext = new AppDbContext();
        public  void TrackingDeteched(T entity)
        {
      
            _appDbContext.Entry<T>(entity!).State = EntityState.Detached;
        }
    }
}
