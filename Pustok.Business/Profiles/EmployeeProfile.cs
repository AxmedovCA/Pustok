using AutoMapper;
using Pustok.Business.Dtos.EmployeeDtos;
using Pustok.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.Business.Profiles
{
    internal class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeCreateDto>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateDto>().ReverseMap();
            CreateMap<Employee, EmployeeGetDto>().ReverseMap();
        }
    }
}
