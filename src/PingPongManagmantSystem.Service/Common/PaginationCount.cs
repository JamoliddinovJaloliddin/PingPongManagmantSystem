using PingPongManagmantSystem.Service.ViewModels;

namespace PingPongManagmantSystem.Service.Common
{
    public static class PaginationCount
    {
        public static void PaginationCountDate(double count, int pageSize)
        {
            if (count > 1)
            {
                GlobalVariable.Pagination = Math.Ceiling(count / pageSize);
            }
            else
            {
                GlobalVariable.Pagination = 1;
            }

        }
    }
}
