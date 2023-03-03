﻿using Microsoft.EntityFrameworkCore;
using PingPongManagmantSystem.DataAccess.Constans;
using PingPongManagmantSystem.Domain.Entities;
using PingPongManagmantSystem.Service.Interfaces.EmpolyeeInterface;

namespace PingPongManagmantSystem.Service.Services.EmpolyeeService
{

    public class CardService : ICardService
    {
        AppDbContext appDbContext = new AppDbContext();

        public async Task<bool> CreateAsync(Card card)
        {
            try
            {
                var res = await appDbContext.Cards.FirstOrDefaultAsync(x => x.CardNumber == card.CardNumber);
                if (res is not null && res.CardNumber == card.CardNumber)
                {
                    return false;
                }
                appDbContext.Cards.Add(card);
                var resault = await appDbContext.SaveChangesAsync();
                return resault > 0;
            }
            catch
            {
                return false;
            }
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
                var resault = await appDbContext.Cards.Where(x => x.CardNumber == customer).AsNoTracking().ToListAsync();
                if (resault != null)
                {
                    return (Card)resault;
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