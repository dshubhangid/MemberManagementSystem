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
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public AccountService(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public IEnumerable<AccountReadDto> GetAllAccountsForMember(int memberId)
        {
            var accounts = _memberRepository.GetAccounts(memberId);
            //.GetAllMembers();
            if (accounts == null || (accounts.Count() == 0))
            {
                return null;
            }
            return _mapper.Map<IEnumerable<AccountReadDto>>(accounts);
        }

        public AccountReadDto GetAccountForMember(int memberId, int id)
        {
            var accountFromRepo = _memberRepository.GetAccount(memberId, id);
            if (accountFromRepo != null)
            {
                return _mapper.Map<AccountReadDto>(accountFromRepo);
            }
            return null;
        }

        public bool GetMemberById(int id)
        {
            var memberFromRepo = _memberRepository.GetMemberById(id);
            if (memberFromRepo != null)
            {
                return true;
            }
            return false;
        }

        public AccountReadDto CreateAccount(int memberId,AccountCreateDto accountDto)
        {
            Account account = _mapper.Map<Account>(accountDto);
            _memberRepository.CreateAccount(memberId, account);

            _memberRepository.SaveChanges();

            var accountReadDto = _mapper.Map<AccountReadDto>(account);
            return accountReadDto;
        }
        JsonPatchDocument CreateJsonPatchDocument(string path,string pathValue)
        {
            JsonPatchDocument patchDocument = new JsonPatchDocument();
            patchDocument.Replace(path, pathValue);
            return patchDocument;
        }
 
        public AccountReadDto ManageAccountPoints(bool condition, int memberId, int accountId, int points)
        {
            var accountFromRepo = _memberRepository.GetAccount(memberId, accountId);

            if (accountFromRepo == null)
            {
                return null;
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
            _memberRepository.SaveChanges();

            var accountReadDto = _mapper.Map<AccountReadDto>(accountFromRepo);
            return accountReadDto;
        }

    }
}
