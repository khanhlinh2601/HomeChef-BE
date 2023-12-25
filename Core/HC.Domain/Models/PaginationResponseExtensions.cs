
namespace HC.Domain.Common.Models;

public static class PaginationResponseExtensions
{
    public static PaginationResponse<T> ToPaginationResponse<T>(this IQueryable<T> queryable, PaginationFilter filter)
    {
        var count = queryable.Count();
        var data = queryable
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToList();

        return new PaginationResponse<T>(data, count, filter.PageNumber, filter.PageSize);
    }
}