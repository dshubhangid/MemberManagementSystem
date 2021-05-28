﻿using MemberManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberManagementSystem.Repositories.Interfaces
{
    public interface IMemberRepository
    {
        IEnumerable<Member> AllMembers { get; }
        Member GetMemberById(int memberId);
        void CreateMember(Member member);
        bool SaveChanges(); 
    }
}
