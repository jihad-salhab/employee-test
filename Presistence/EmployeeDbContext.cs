using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employee_test.Models;
using Microsoft.EntityFrameworkCore;

namespace employee_test.Presistence
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {

        }
        public DbSet<Job>? Jobs { get; set; }
        public DbSet<Employee>? Employees { get; set; }

    }
}