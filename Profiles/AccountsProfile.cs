using AutoMapper;
using MemberManagementSystem.Dtos;
using MemberManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberManagementSystem.Profiles
{
    public class AccountsProfile: Profile
    {
        public AccountsProfile()
        {
            CreateMap<Account, AccountReadDto>();

            CreateMap<AccountCreateDto, Account>();

            CreateMap<Account, AccountUpdateDto>();

            CreateMap<AccountUpdateDto, Account>();
        }
    }
}
