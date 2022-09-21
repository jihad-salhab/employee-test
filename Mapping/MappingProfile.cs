using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using employee_test.Controllers.Resources;
using employee_test.Models;

namespace employee_test.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Job, JobResource>();
            CreateMap<Employee, EmployeeResource>();
        }

    }
}