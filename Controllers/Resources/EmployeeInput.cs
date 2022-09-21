using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace employee_test.Controllers.Resources
{
    public class EmployeeInput
    {
        public List<int>? EmployeesId { get; set; }
        public int JobId { get; set; }
    }
}