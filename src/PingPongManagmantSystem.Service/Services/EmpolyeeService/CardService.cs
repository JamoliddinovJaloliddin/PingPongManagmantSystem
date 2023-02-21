using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;

namespace PingPongManagmantSystem.Service.Services.EmpolyeeService
{

    public class CardService : ICardService
    {
        AppDbContext appDbContext = new AppDbContext();

        public Task<bool> CreateAsync(Card card)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Card>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Card> GetByIdAsync(string customer)
        {
            try
            {
                var resault = (Card)appDbContext.Cards.Where(x => x.CardNumber == customer).AsNoTracking();
                if (resault != null)
                {
                    return resault;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public Task<bool> UpdateAsync(Card card)
        {
            throw new NotImplementedException();
        }
    }
}
