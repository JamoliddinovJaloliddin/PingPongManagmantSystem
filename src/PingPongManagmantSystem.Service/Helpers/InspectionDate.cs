namespace PingPongManagmantSystem.Service.Helpers
{
    public static class InspectionDate
    {
        public static async Task<bool> Inspection(string from)
        {
            try
            {
                string word = from[0].ToString();
                word += from[1].ToString();
                int moon = int.Parse(word);

                if (from[2].ToString() == "/" && moon > 0 && moon < 13)
                {
                    var resultFrom = from.Count(x => Char.IsDigit(x));
                    if (resultFrom == 6)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
