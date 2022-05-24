using EmployeeRecord.Domain.ValueObjects;
using EmployeeRecord.Infrastructure;
using EmployeeRecord.WebApi.Common.CustomException;
using MediatR;

namespace EmployeeRecord.WebApi.Employee.Commands;

public record UpdateEmployeeCommand(Domain.Entities.Employee Employee) : IRequest;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
{
    private readonly IEmployeeDbContext _context;
    
    public UpdateEmployeeCommandHandler(IEmployeeDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees.FindAsync(request.Employee.Id);
        if(employee == null) throw new NotFoundException(nameof(Employee), request.Employee);

        employee.UpdateName(request.Employee.Name);

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}