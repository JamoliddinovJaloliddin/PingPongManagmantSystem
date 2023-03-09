namespace PingPongManagmantSystem.Service.ViewModels.StatisticViews
{
    public class TableStatisticView
    {
        public string NumberCount { get; set; }
        public string DateTime { get; set; } = String.Empty;
        public double BarSum { get; set; }
        public double SportSum { get; set; }
        public double TableSum { get; set; }
        public double Card { get; set; }
        public double Cash { get; set; }
        public double CardTime { get; set; }
        public double ViCardToSell { get; set; }
        public double TotalSum { get; set; }
    }
}
