using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using zjs.Application.DTOs;
using zjs.Module.Entitys;

namespace zjs.Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            //       .ForMember(d => d.xxx, o => o.MapFrom(s => s.xxx));
        }
    }
}
