using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MemberManagementSystem.Dtos;
using MemberManagementSystem.Repositories.Interfaces;
using MemberManagementSystem.Services.Interface;

namespace MemberManagementSystem.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public AccountReadDto GetAccountById(int id)
        {
            var accountFromRepo = _accountRepository.GetAccountById(id);
            if (accountFromRepo != null)
            {
                return _mapper.Map<AccountReadDto>(accountFromRepo);
            }
            return null;
        }

        public IEnumerable<AccountReadDto> GetAllAccounts()
        {
            var accounts = _accountRepository.AllAccounts;
            //.GetAllMembers();
            if (accounts == null || (accounts.Count() == 0))
            {
                return null;
            }
            return _mapper.Map<IEnumerable<AccountReadDto>>(accounts);
        }


    }
}
