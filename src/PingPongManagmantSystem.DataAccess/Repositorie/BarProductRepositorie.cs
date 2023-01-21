using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Interfaces;
using PingPongManagmantSystem.Domain.Constans.DbConstans;
using PingPongManagmantSystem.Domain.Entities;

namespace PingPongManagmantSystem.DataAccess.Repositorie
{
    public class BarProductRepositorie : IBarProductInterface
    {
        protected AppDbContext _dbContext;
        protected DbSet<BarProduct> _dbSet;

        public BarProductRepositorie(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
            this._dbSet = dbContext.Set<BarProduct>();
        }
        public virtual async Task<bool> CreateAsync(BarProduct entity)
        {
            try
            {
                var resault = _dbSet.Add(entity);
                if (resault is null)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }



        //public virtual void Create(T entity)
        //{
        //    try
        //    {
        //        _dbSet.Add(entity);

        //    }
        //    catch
        //    {

        //    }

        //}

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BarProduct>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BarProduct> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(BarProduct entity)
        {
            throw new NotImplementedException();
        }
    }
}
