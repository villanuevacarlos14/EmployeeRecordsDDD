using EmployeeRecord.WebApi.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRecord.WebApi.Common.Extensions;

public static class MappingExtensions
{
    public static Task<PaginatedList<T>> PaginatedListAsync<T>(this IQueryable<T> queryable, int pageNumber, int pageSize) where T : class
        => PaginatedList<T>.CreateAsync(queryable.AsNoTracking(), pageNumber, pageSize);
}
