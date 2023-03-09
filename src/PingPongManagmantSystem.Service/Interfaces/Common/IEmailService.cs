using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongManagmantSystem.Service.Interfaces.Common
{
    public interface IEmailService
    {
        public Task<int> SendAsync();
    }
}
