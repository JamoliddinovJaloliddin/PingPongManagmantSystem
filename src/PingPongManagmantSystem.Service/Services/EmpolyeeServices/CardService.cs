using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Helpers;
using PingPongManagmantSystem.Service.Interfaces.AdminIntefaces.StatisticSrvices;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;
using PingPongManagmantSystem.Service.Services.AdminServices.StatisticServices;
using PingPongManagmantSystem.Service.ViewModels;

namespace PingPongManagmantSystem.Service.Services.EmpolyeeService
{

    public class CardService : ICardService
    {
        AppDbContext appDbContext = new AppDbContext();
        IEmpolyeeStatsiticService empolyeeStatsiticService = new EmpolyeeStatisticService();
        public async Task<bool> CreateAsync(Card card)
        {
            try
            {
                var date = DayHelper.GetCurrentServerDay();
                var res = await appDbContext.Cards.FirstOrDefaultAsync(x => x.CardNumber == card.CardNumber);
                if (res is not null)
                {
                    return false;
                }
                card.DateTime = date;
                appDbContext.Cards.Add(card);
                var resault = await appDbContext.SaveChangesAsync();

                var ress = await empolyeeStatsiticService.CreateCardAsync(card.Price, card.Payment);

                return resault > 0;
            }
            catch
            {
                return false;
            }
        }


        public async Task<Card> GetByIdAsync(string customer)
        {
            try
            {

                var resault = (Card)await appDbContext.Cards.FirstOrDefaultAsync(x => x.CardNumber == GlobalVariable.CardCheck);

                if (resault != null)
                {
                    appDbContext.Entry(resault).State = EntityState.Detached;
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
