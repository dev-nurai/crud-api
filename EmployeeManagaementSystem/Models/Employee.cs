using System;
using System.Collections.Generic;

namespace EmployeeManagaementSystem.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? DateOfJoining { get; set; }

    public decimal? Salary { get; set; }
}
