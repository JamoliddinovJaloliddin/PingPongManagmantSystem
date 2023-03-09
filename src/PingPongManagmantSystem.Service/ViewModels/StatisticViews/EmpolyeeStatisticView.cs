namespace PingPongManagmantSystem.Service.ViewModels.StatisticViews
{
    public class EmpolyeeStatisticView
    {
        public string NumberCount { get; set; }
        public string UserName { get; set; } = String.Empty;
        public string DateTime { get; set; } = String.Empty;
        public double BarSum { get; set; }
        public double VipCardSum { get; set; }
        public double ViCardToSell { get; set; }
        public double SportSum { get; set; }
        public double TableSum { get; set; }
    }
}
