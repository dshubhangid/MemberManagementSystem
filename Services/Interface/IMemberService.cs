using MemberManagementSystem.Dtos;
using MemberManagementSystem.FilterResource;
using MemberManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberManagementSystem.Services.Interface
{
    public interface IMemberService
    {
        IEnumerable<MemberReadDto> GetAllMembers();

        IEnumerable<Member> GetAllFilteredMembers(MemberFilterParameter memberFilterParameter);
        MemberReadDto GetMemberById(int id);
        bool CreateMember(MemberCreateDto member);

        
    }
}
