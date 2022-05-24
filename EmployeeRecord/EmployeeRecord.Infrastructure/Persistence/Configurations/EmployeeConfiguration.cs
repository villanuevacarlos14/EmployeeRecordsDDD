using EmployeeRecord.Domain.Entities;
using EmployeeRecord.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeRecord.Infrastructure.Configurations;

public class EmployeeConfiguration: IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.Name, nameBuilder =>
        {
            nameBuilder.Property(x => x.FirstName).HasColumnName(nameof(Name.FirstName)).IsRequired();
            nameBuilder.Property(x => x.MiddleName).HasColumnName(nameof(Name.MiddleName)).IsRequired();
            nameBuilder.Property(x => x.LastName).HasColumnName(nameof(Name.LastName)).IsRequired();
        });
        builder.Navigation(x => x.Name).IsRequired();
    }
}