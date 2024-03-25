using AutoMapper;
using EMS.DTOs;
using EMS.Models;

namespace EMS.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeListDTO>();
            CreateMap<Employee, EmployeeDetailedDTO>();
            CreateMap<Employee, EmployeeMinimalDTO>();
            CreateMap<EmployeeUpdateDTO, Employee>();
        }
    }
}