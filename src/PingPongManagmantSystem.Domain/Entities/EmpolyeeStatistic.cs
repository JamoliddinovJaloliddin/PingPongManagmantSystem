using PingPongManagmantSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongManagmantSystem.Domain.Entities
{
    public class EmpolyeeStatistic : BaseEntity
    {
        public int NumberOfSale { get; set; }
        public double Cash { get; set; }
        public double Card { get; set; }
        public double TotalPrice { get; set; }
        public string DateTime { get; set; } = String.Empty;
    }
}
