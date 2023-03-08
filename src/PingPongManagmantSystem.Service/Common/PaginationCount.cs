using PingPongManagmantSystem.Service.ViewModels;

namespace PingPongManagmantSystem.Service.Common
{
    public static class PaginationCount
    {
        public static void PaginationCountDate(double count)
        {
            if (count > 1)
            {
                GlobalVariable.Pagination = Math.Ceiling(count / 2);
            }
            else
            {
                GlobalVariable.Pagination = 1;
            }
        }
    }
}
