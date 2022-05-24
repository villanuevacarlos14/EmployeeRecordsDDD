using System.Text.Json.Serialization;
using EmployeeRecord.Domain.Common;
using EmployeeRecord.Domain.ValueObjects;

namespace EmployeeRecord.Domain.Entities;

public class Employee: BaseEntity
{
    //required by efcore
    private Employee()
    {
        
    }

    [JsonConstructor]
    public Employee(Name name)
    {
        Name = name;
    }
    
    public Employee(string firstName, string middleName, string lastName)
    {
        Name = new(firstName,lastName) { MiddleName = middleName  };
    }

    public Name Name { get; private set; }

    public void UpdateName(Name name)
    {
        this.Name = name;
    }
}