using EmployeeRecord.Infrastructure;
using EmployeeRecord.Infrastructure.QueryBuilder;
using EmployeeRecord.WebApi.Common.Extensions;
using EmployeeRecord.WebApi.Common.Models;
using MediatR;

namespace EmployeeRecord.WebApi.Employee;

public record GetEmployeesQuery: IRequest<PaginatedList<Domain.Entities.Employee>>
{
    public string Name { get; init; } = string.Empty;
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetEmployeesQueryHandler: IRequestHandler<GetEmployeesQuery, PaginatedList<Domain.Entities.Employee>>
{
    private readonly IEmployeeDbContext _context;
    public GetEmployeesQueryHandler(IEmployeeDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedList<Domain.Entities.Employee>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var data = await _context.Employees.FindEmployeeByName(request.Name)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
        return data;
    }
} 