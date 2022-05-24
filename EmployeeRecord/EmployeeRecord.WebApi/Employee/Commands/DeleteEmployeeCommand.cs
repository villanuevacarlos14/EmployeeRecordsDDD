using EmployeeRecord.Infrastructure;
using EmployeeRecord.WebApi.Common.CustomException;
using MediatR;

namespace EmployeeRecord.WebApi.Employee.Commands;


public record DeleteEmployeeCommand(Guid Id) : IRequest;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
{
    private readonly IEmployeeDbContext _context;
    
    public DeleteEmployeeCommandHandler(IEmployeeDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees.FindAsync(request.Id);
        if(employee == null) throw new NotFoundException(nameof(Employee), $"{request.Id}");
        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}