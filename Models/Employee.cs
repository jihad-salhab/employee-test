using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace employee_test.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string? FullName { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        public Job? Job { get; set; }
        public int jobId { get; set; }
    }
}