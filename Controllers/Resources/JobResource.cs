using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace employee_test.Controllers.Resources
{
    public class JobResource
    {
        public int Id { get; set; }

        public string? Description { get; set; }
        public ICollection<EmployeeResource>? Employees { get; set; }

        public JobResource()
        {
            Employees = new Collection<EmployeeResource>();

        }

    }
}