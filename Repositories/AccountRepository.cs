using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemberManagementSystem.Models;
using MemberManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MemberManagementSystem.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MemberManagementDbContext _appDbContext;
        public AccountRepository(MemberManagementDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Account> AllAccounts
        {
            get
            {
                return _appDbContext.Accounts.Include(m =>m.member);
            }
        }

        public void CreateAccount(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }
            _appDbContext.Accounts.Add(account);
        }

        public Account GetAccountById(int accountId)
        {
            return AllAccounts.FirstOrDefault(a => a.Id == accountId);
        }

        public bool SaveChanges()
        {
            return (_appDbContext.SaveChanges() >= 0);
        }
    }
}
