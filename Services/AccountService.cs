using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MemberManagementSystem.Dtos;
using MemberManagementSystem.Models;
using MemberManagementSystem.Repositories.Interfaces;
using MemberManagementSystem.Services.Interface;
using Microsoft.AspNetCore.JsonPatch;


namespace MemberManagementSystem.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository, IMemberRepository memberRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _memberRepository = memberRepository;
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

        public bool GetMemberById(int memberId)
        {
            var member = _memberRepository.GetMemberById(memberId);
            if (member == null)
            {
                return false;
            }
            return true;
        }

        public bool CreateAccount(AccountCreateDto accountDto)
        {
            //Check here first if memberid is present
            var member = _memberRepository.GetMemberById(accountDto.MemberId);
            if (member == null )
            {
                return false;
            }
            Account account = _mapper.Map<Account>(accountDto);
            _accountRepository.CreateAccount(account);

            return (_accountRepository.SaveChanges());
           
        }

        
        JsonPatchDocument CreateJsonPatchDocument(string path,string pathValue)
        {
            JsonPatchDocument patchDocument = new JsonPatchDocument();
            patchDocument.Replace(path, pathValue);
            return patchDocument;
        }
 
        public bool ManageAccountPoints(bool condition, int accountId, int points)
        {
            var accountFromRepo = _accountRepository.GetAccountById(accountId);

            if (accountFromRepo == null)
            {
                return false;
            }
            string sPath = "/Balance";
            int finalPoints;
            if(condition)
            {
                finalPoints = accountFromRepo.Balance + points;
            }
            else
            {
                finalPoints = accountFromRepo.Balance - points;
            }
            
            JsonPatchDocument jsonPatchDocument = CreateJsonPatchDocument(sPath, finalPoints.ToString());

            var accountToPatch = _mapper.Map<AccountUpdateDto>(accountFromRepo);
            jsonPatchDocument.ApplyTo(accountToPatch);

            _mapper.Map(accountToPatch, accountFromRepo);
            _accountRepository.SaveChanges();

            return true;
        }

    }
}
