using MemberManagementSystem.Dtos;
using MemberManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberManagementSystem.Services.Interface
{
    public interface IMemberService
    {
        bool CreateMembersWithAccounts(MemberCreateDto member);

        void CreateMember(MemberCreateDto member);

        void CreateAccountForMember(Account account, int memberId);
    }
}
