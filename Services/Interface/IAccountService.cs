using MemberManagementSystem.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberManagementSystem.Services.Interface
{
    public interface IAccountService
    {
        IEnumerable<AccountReadDto> GetAllAccountsForMember(int memberId);
        AccountReadDto GetAccountForMember(int memberId, int id);
        bool GetMemberById(int id);
        AccountReadDto CreateAccount(int memberId, AccountCreateDto accountDto);
        AccountReadDto ManageAccountPoints(bool condition, int memberId ,int accountId, int points);
    }
}
