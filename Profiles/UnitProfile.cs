using AutoMapper;
using EMS.DTOs;
using EMS.Models;

namespace EMS.Profiles
{
    public class UnitProfile : Profile
    {
        public UnitProfile()
        {
            CreateMap<Unit, UnitListDTO>();
            CreateMap<Unit, UnitDetailedDTO>();
            CreateMap<Unit, UnitMinimalDTO>();
        }
    }
}