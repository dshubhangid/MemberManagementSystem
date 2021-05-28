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
        IEnumerable<MemberReadDto> GetAllMembers();
        MemberReadDto GetMemberById(int id);
        bool CreateMember(MemberCreateDto member);

        
    }
}
