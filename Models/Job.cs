using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace employee_test.Models
{
    public class Job
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string? Description { get; set; }
        public ICollection<Employee>? Employees { get; set; }

        public Job()
        {
            Employees = new Collection<Employee>();

        }
    }
}