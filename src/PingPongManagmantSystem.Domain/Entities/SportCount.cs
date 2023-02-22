using PingPongManagmantSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongManagmantSystem.Domain.Entities
{
    public class SportCount : BaseEntity
    {
        public string Name { get; set; } = String.Empty;
        public double Price { get; set; }
        public int Count { get; set; }
    }
}
