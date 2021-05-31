using MemberManagementSystem.FilterResource;
using MemberManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberManagementSystem.Repositories.Interfaces
{
    public interface IMemberRepository
    {
        IEnumerable<Member> AllMembers { get; }

        IEnumerable<Member> GetAllFilteredMembers(MemberFilterParameter memberFilterParameter);
        Member GetMemberById(int memberId);
        void CreateMember(Member member);
       // IEnumerable<Account> AllAccounts { get; }
        IEnumerable<Account> GetAccounts(int memberId);
        Account GetAccount(int memberId,  int accountId);
        void CreateAccount(int memberId,Account account);
        bool SaveChanges(); 

    }
}
