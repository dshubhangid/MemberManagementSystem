using AutoMapper;
using MemberManagementSystem.Dtos;
using MemberManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberManagementSystem.Profiles
{
    public class MembersProfile : Profile
    {
        public MembersProfile()
        {
            CreateMap<Member, MemberReadDto>();
            CreateMap<MemberCreateDto, Member>();
        }
    }
}
