using PingPongManagmantSystem.Domain.Entities;

namespace PingPongManagmantSystem.Service.ViewModels.StatisticViews
{
    public class TableStatisticView
    {
        public string DateTime { get; set; } = String.Empty;
        public int UserId { get; set; }
        public User User { get; set; } = default!;
        public double BarSum { get; set; }
        public double NumberOfSaleBar { get; set; }
        public double SportSum { get; set; }
        public double NumberOfSaleSport { get; set; }
        public double TableSum { get; set; }
        public string PaymentType { get; set; } = String.Empty;
        public double CardTime { get; set; }
        public double TotalSum { get; set; }
    }
}
