using Microsoft.EntityFrameworkCore;

namespace PingPongManagmantSystem.Service.Common.Utils
{
    public class PagedList<T> : List<T>
    {
        public PaginationMetaData MetaData { get; set; } = default!;

        public PagedList(List<T> items, PaginationParams @params, int totalItems)
        {
            this.MetaData = new PaginationMetaData(@params.PageNumber, @params.PageSize, totalItems);
            AddRange(items);
        }

        public static async Task<PagedList<T>> ToPageListAsync(IQueryable<T> source, PaginationParams @params)
        {
            PaginationCount.PaginationCountDate(source.Count(), @params.PageSize);
            int totalItems = source.Count();
            var resault = await source.Skip((@params.PageNumber - 1) * @params.PageSize)
                .Take(@params.PageSize).ToListAsync();
            return new PagedList<T>(resault, @params, totalItems);
        }
    }
}
