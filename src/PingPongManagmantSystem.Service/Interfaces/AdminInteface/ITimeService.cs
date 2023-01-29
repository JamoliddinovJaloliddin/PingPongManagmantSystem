using PingPongManagmantSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongManagmantSystem.Service.Interfaces.AdminInteface
{
    public interface ITimeService
    {
        Task<IList<Time>> GetAll();
        Task<bool> UpdateAsync(Time time);
    }
}
