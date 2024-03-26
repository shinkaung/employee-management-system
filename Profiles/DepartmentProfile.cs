using AutoMapper;
using EMS.DTOs;
using EMS.Models;

namespace EMS.Profiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentListDTO>();
            CreateMap<Department, DepartmentDetailedDTO>();
            CreateMap<DepartmentUpdateDTO, Department>();
        }
    }
}