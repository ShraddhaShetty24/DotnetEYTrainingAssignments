using System;
using System.Collections.Generic;

namespace CrudWebApi_feb13.Models
{
    public partial class TEmployee
    {
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public int? EmployeeSalary { get; set; }
        public int? EmployeeAge { get; set; }
    }
}
