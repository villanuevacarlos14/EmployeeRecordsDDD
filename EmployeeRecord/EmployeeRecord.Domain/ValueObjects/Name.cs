namespace EmployeeRecord.Domain.ValueObjects;

public record Name(string FirstName, string LastName)
{
    public string? MiddleName { get; init; }
}

