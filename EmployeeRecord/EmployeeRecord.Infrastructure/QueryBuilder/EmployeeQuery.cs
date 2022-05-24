using EmployeeRecord.Domain.Entities;

namespace EmployeeRecord.Infrastructure.QueryBuilder;

public static class EmployeeQuery
{
    public static IQueryable<Employee> FindEmployeeByName(this IQueryable<Employee> query, string name)
    {
        if (string.IsNullOrEmpty(name)) return query;
        
        return query
            .Where(x => x.Name.FirstName.ToLower().Contains(name.ToLower())
                        || x.Name.LastName.ToLower().Contains(name.ToLower())
                        || x.Name.MiddleName!.ToLower().Contains(name.ToLower()));
    }
}