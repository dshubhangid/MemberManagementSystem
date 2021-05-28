using Microsoft.EntityFrameworkCore;
using MemberManagementSystem.Models;
using MemberManagementSystem.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public Member GetMemberById(int memberId)
        {
            return AllMembers.FirstOrDefault(m => m.Id == memberId);
            //return _memberDbContext.Members.FirstOrDefault(m=> m.Id == memberId);
        }

        public void CreateMember(Member member)
        {
            if (member == null)
            {
                throw new ArgumentNullException(nameof(member));
            }
            _memberDbContext.Members.Add(member);
        }

        public bool SaveChanges()
        {
            return (_memberDbContext.SaveChanges() >= 0);
        }
    }
}
