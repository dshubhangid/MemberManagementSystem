using Microsoft.EntityFrameworkCore;
using MemberManagementSystem.Models;
using MemberManagementSystem.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemberManagementSystem.FilterResource;

namespace MemberManagementSystem.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly MemberManagementDbContext _memberDbContext;

        public MemberRepository(MemberManagementDbContext memberDbContext)
        {
            _memberDbContext = memberDbContext;
        }

        public IEnumerable<Member> AllMembers
        {
            get
            {
                return _memberDbContext.Members.Include(a => a.Accounts);
            }
        }

        public IEnumerable<Member> GetAllFilteredMembers(MemberFilterParameter memberFilterParameter)
        {
            var query = _memberDbContext.Members as IQueryable<Member>;

            query =
                from member in query
                from account in member.Accounts
                where account.Balance > memberFilterParameter.Points && account.Status == memberFilterParameter.Status
                select member;

            return query.ToList()
                .GroupBy(m => new { m.Name, m.Address })
                              .Select(m => m.FirstOrDefault()); ;

        }

        public Member GetMemberById(int memberId)
        {
            return AllMembers.FirstOrDefault(m => m.Id == memberId);
        }

        public void CreateMember(Member member)
        {
            if (member == null)
            {
                throw new ArgumentNullException(nameof(member));
            }
            _memberDbContext.Members.Add(member);
        }

        //public IEnumerable<Account> AllAccounts
        //{
        //    get
        //    {
        //        return _memberDbContext.Accounts.Include(m => m.member);
        //    }
        //}

        public void CreateAccount(int memberId, Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            account.MemberId = memberId;
            _memberDbContext.Accounts.Add(account);
        }

        public IEnumerable<Account> GetAccounts(int memberId)
        {
            return _memberDbContext.Accounts.Where(a => a.MemberId == memberId).ToList();
        }

        public Account GetAccount(int memberId, int accountId)
        {
            return _memberDbContext.Accounts.Where(a => a.MemberId == memberId && a.Id == accountId).FirstOrDefault();
        }

        public bool SaveChanges()
        {
            return (_memberDbContext.SaveChanges() >= 0);
        }


    }
}
