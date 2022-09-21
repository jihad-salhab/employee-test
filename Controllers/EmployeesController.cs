using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using employee_test.Models;
using employee_test.Presistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace employee_test.Controllers.Resources
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeDbContext Context;
        private readonly IMapper Mapper;
        public EmployeesController(EmployeeDbContext context, IMapper mapper)
        {
            this.Mapper = mapper;
            this.Context = context;

        }
        [HttpGet("/api/employees")]
        public async Task<IEnumerable<EmployeeResource>> GetJobs()
        {
            if (Context.Employees != null)
            {
                var employees = await Context.Employees.ToListAsync();
                return Mapper.Map<List<Employee>, List<EmployeeResource>>(employees);

            }
            else
            {
                return new List<EmployeeResource>();
            }

        }
        [HttpPut("api/employees/update")]
        public EmployeeInput UpdateEmployee([FromBody] EmployeeInput empInput)
        {
            if (empInput.EmployeesId != null && Context.Employees != null)
            {
                foreach (var item in empInput.EmployeesId)
                {

                    var emp = Context.Employees.Where(e => e.Id == item).FirstOrDefault();
                    if (emp != null)
                    {
                        emp.jobId = empInput.JobId;
                    }
                }
            }
            bool isSave = Context.SaveChanges() > 0;
            if (isSave)
            {
                return empInput;
            }
            return new EmployeeInput();


        }

    }
}