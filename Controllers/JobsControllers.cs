using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using employee_test.Controllers.Resources;
using employee_test.Models;
using employee_test.Presistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace employee_test.Controllers
{
    [Route("api/jobs/")]
    public class JobsControllers : Controller
    {
        private readonly EmployeeDbContext Context;
        private readonly IMapper Mapper;
        public JobsControllers(EmployeeDbContext context, IMapper mapper)
        {
            this.Mapper = mapper;
            this.Context = context;

        }
        // [HttpGet("/api/jobs")]
        public async Task<IEnumerable<JobResource>> GetJobs()
        {
            if (Context.Jobs != null)
            {
                var jobs = await Context.Jobs.Include(Job => Job.Employees).ToListAsync();
                return Mapper.Map<List<Job>, List<JobResource>>(jobs);

            }
            else
            {
                return new List<JobResource>();
            }

        }
        [HttpPost("add")]
        public Job Add([FromBody] Job job)
        {
            if (Context.Jobs != null)
            {
                Context.Jobs.Add(job);

            }
            bool isSave = Context.SaveChanges() > 0;
            if (isSave)
            {
                return job;
            }
            return new Job();
        }
    }
}