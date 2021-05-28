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

            CreateMap<Account, AccountReadDto>();
            
            CreateMap<AccountCreateDto, Account>();
                //.ForMember(dest => dest.Status, opt => opt.Condition(src =>(src.Status == "Active")));
           
            //IEnumerable<AccountDto> accountDtos = Mapper.Map<IEnumerable<Account>, IEnumerable<AccountDto>>(Account);

        }

    }
}
