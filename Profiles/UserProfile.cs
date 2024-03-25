using AutoMapper;
using EMS.DTOs;
using EMS.Models;

namespace EMS.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
        }
    }
}