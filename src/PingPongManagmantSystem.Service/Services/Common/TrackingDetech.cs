using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.Common;

namespace PingPongManagmantSystem.Service.Services.Common
{
    public class TrackingDetech : ITrackingDetech
    {
        AppDbContext _appDbContext = new AppDbContext();

        public void TrackingDeteched(BarCount entity)
        {
            _appDbContext.Entry<BarCount>(entity!).State = EntityState.Detached;
            string ef = _appDbContext.Entry(entity).State.ToString();
        }

        public void TrackingDeteched(BarProduct entity)
        {
            _appDbContext.Entry(entity!).State = EntityState.Detached;
        }

        public void TrackingDeteched(Card entity)
        {
            _appDbContext.Entry(entity!).State = EntityState.Detached;
        }

        public void TrackingDeteched(Cassa entity)
        {
            _appDbContext.Entry<Cassa>(entity!).State = EntityState.Detached;
        }

        public void TrackingDeteched(Customer entity)
        {
            _appDbContext.Entry<Customer>(entity!).State = EntityState.Detached;
        }

        public void TrackingDeteched(DesktopCassa entity)
        {
            _appDbContext.Entry<DesktopCassa>(entity!).State = EntityState.Detached;
        }

        public void TrackingDeteched(PingPongTable entity)
        {
            _appDbContext.Entry<PingPongTable>(entity!).State = EntityState.Detached;
        }

        public void TrackingDeteched(SportCount entity)
        {
            _appDbContext.Entry<SportCount>(entity!).State = EntityState.Detached;
        }

        public void TrackingDeteched(SportProduct entity)
        {
            _appDbContext.Entry<SportProduct>(entity!).State = EntityState.Detached;
        }

        public void TrackingDeteched(Time entity)
        {
            _appDbContext.Entry<Time>(entity!).State = EntityState.Detached;
        }

        public void TrackingDeteched(Transfer entity)
        {
            _appDbContext.Entry<Transfer>(entity!).State = EntityState.Detached;
        }

        public void TrackingDeteched(User entity)
        {
            _appDbContext.Entry<User>(entity!).State = EntityState.Detached;
        }

        public void TrackingDeteched(BarStatistic entity)
        {
            _appDbContext.Entry<BarStatistic>(entity!).State = EntityState.Detached;
        }

        public void TrackingDeteched(SportStatistic entity)
        {
            _appDbContext.Entry<SportStatistic>(entity!).State = EntityState.Detached;
        }

        public void TrackingDeteched(TableStatistic entity)
        {
            _appDbContext.Entry<TableStatistic>(entity!).State = EntityState.Detached;
        }
    }
}
