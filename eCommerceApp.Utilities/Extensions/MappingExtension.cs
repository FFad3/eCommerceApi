using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace eCommerceApp.Utilities.Extensions
{
    public static class MappingExtension
    {
        public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize, CancellationToken cancellationToken)
            where TDestination : class
       => PaginatedList<TDestination>.CreateAsync(queryable.AsNoTracking(), pageNumber, pageSize, cancellationToken);

        public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, IConfigurationProvider configuration, CancellationToken cancellationToken)
            where TDestination : class
            => queryable.ProjectTo<TDestination>(configuration).AsNoTracking().ToListAsync(cancellationToken);
    }

    public class PaginatedList<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int ItemsCount { get; set; }
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;

        public PaginatedList(IEnumerable<T> items, int itemsCount, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(itemsCount / (double)pageSize);
            ItemsCount = itemsCount;
            Items = items;
        }

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var count = await source.CountAsync(cancellationToken);
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
            return new PaginatedList<T>(items, count, pageNumber, pageSize);
        }
    }
}