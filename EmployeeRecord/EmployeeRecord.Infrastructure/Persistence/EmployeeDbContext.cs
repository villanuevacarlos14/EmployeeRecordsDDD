using EmployeeRecord.Domain.Entities;
using EmployeeRecord.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRecord.Infrastructure;

internal class EmployeeDbContext : DbContext, IEmployeeDbContext
{
    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options){}
    
    public DbSet<Employee> Employees { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
       builder.ApplyConfiguration(new EmployeeConfiguration());
    }
}

public interface IEmployeeDbContext
{
    DbSet<Employee> Employees { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}