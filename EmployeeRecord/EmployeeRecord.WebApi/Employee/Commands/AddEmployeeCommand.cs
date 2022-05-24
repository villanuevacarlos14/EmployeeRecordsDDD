using EmployeeRecord.Domain.ValueObjects;
using EmployeeRecord.Infrastructure;
using MediatR;

namespace EmployeeRecord.WebApi.Employee.Commands;

public record AddEmployeeCommand(Name Name) : IRequest;

public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand>
{
    private readonly IEmployeeDbContext _context;

    public AddEmployeeCommandHandler(IEmployeeDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
    {
        await _context.Employees.AddAsync(new Domain.Entities.Employee(request.Name), cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}