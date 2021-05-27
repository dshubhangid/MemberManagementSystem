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
            CreateMap<Member, MemberDto>();
            CreateMap<Account, AccountDto>();
            CreateMap<MemberCreateDto, Member>();
            CreateMap<AccountDto, Account>();
            //IEnumerable<AccountDto> accountDtos = Mapper.Map<IEnumerable<Account>, IEnumerable<AccountDto>>(Account);

        }

    }
}
