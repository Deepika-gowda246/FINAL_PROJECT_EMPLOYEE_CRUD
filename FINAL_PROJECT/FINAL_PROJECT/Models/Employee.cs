using System;
using System.Collections.Generic;

namespace FINAL_PROJECT.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public string? Band { get; set; }

    public string? Role { get; set; }

    public string? Designation { get; set; }

    public string? Responsibilities { get; set; }

    public string? ImageUrl { get; set; }
}
