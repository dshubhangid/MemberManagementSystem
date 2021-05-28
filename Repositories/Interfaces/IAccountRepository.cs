using MemberManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberManagementSystem.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> AllAccounts { get; }
        Account GetAccountById(int accountId);
        void CreateAccount(Account account);
        bool SaveChanges();
    }
}
