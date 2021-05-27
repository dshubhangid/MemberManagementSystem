using MemberManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberManagementSystem.Repositories.Interfaces
{
    public interface IMemberRepository
    {
        void CreateMembersWithAccounts(Member member);

        void CreateMember(Member member);

        void CreateAccountForMember(Account account, int memberId);
    }
}
