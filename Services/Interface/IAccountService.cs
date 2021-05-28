using MemberManagementSystem.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberManagementSystem.Services.Interface
{
    public interface IAccountService
    {
        IEnumerable<AccountReadDto> GetAllAccounts();
        AccountReadDto GetAccountById(int id);

        //bool CreateAccount(AccountCreateDto account);
    }
}
