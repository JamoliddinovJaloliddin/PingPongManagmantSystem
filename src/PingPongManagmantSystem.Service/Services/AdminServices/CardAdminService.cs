using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Common.Utils;
using PingPongManagmantSystem.Service.Interfaces.AdminInteface;

namespace PingPongManagmantSystem.Service.Services.AdminService
{

    public class CardAdminService : ICardAdminService
    {
        AppDbContext appDbContext = new AppDbContext();
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var card = await appDbContext.Cards.FindAsync(id);
                if (card is not null)
                {
                    appDbContext.Cards.Remove(card);
                    var result = await appDbContext.SaveChangesAsync();
                    return result > 0;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IList<Card>> GetAllAsync(string search, PaginationParams @params)
        {
            try
            {
                IList<Card> cardsList = new List<Card>();
                if (search == "")
                {
                    var cardss = from car in appDbContext.Cards.OrderBy(x => x.Id)
                                 select car;

                    var cards = await PagedList<Card>.ToPageListAsync(cardss, @params);

                    if (cards is not null)
                    {

                        foreach (var item in cards)
                        {
                            Card card = new Card();
                            appDbContext.Entry<Card>(card).State = EntityState.Detached;
                            card.Id = item.Id;
                            card.CardNumber = item.CardNumber;
                            card.Payment = item.Payment;
                            card.Price = item.Price;
                            card.TimeLimit = item.TimeLimit;
                            card.Phone = item.Phone;
                            cardsList.Add(card);
                        }
                        return cardsList;
                    }
                }
                else
                {
                    var cardss = from car in appDbContext.Cards.Where(x => x.Price.ToString().Contains(search)
                    || x.TimeLimit.ToString().Contains(search)
                    || x.CardNumber.Contains(search.ToLower())
                    || x.Phone.Contains(search.ToLower())
                    || x.Payment.Contains(search.ToLower())
                    ).OrderBy(x => x.Id)
                                 select car;

                    var cards = await PagedList<Card>.ToPageListAsync(cardss, @params);

                    if (cards is not null)
                    {
                        foreach (var item in cards)
                        {
                            Card card = new Card();
                            appDbContext.Entry<Card>(card).State = EntityState.Detached;
                            card.Id = item.Id;
                            card.CardNumber = item.CardNumber;
                            card.Payment = item.Payment;
                            card.Price = item.Price;
                            card.TimeLimit = item.TimeLimit;
                            card.Phone = item.Phone;
                            cardsList.Add(card);
                        }
                        return cardsList;
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
