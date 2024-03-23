namespace TableSplittingSample.Models;
public class Employee
{
    public Guid EmployeeId { get; set; }
    public string Name { get; set; } = null!;

    public EmployeeInfo Info { get; set; } = null!;
}

public class EmployeeInfo
{
    public string Position { get; set; } = null!;
    public string Department { get; set; } = null!;
    public string? Address { get; set; }
    public decimal? AnnualSalary { get; set; }
}
