using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeRecord.Infrastructure;

public static class InfrastructureBootstrapper
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //for ef
        services.AddDbContext<EmployeeDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        
        //for application layer/api
        services.AddScoped<IEmployeeDbContext,EmployeeDbContext>();
        return services;
    }
}