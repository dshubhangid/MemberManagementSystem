using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MemberManagementSystem.Dtos;
using MemberManagementSystem.Services.Interface;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MemberManagementSystem.Controllers
{
    [Route("api/members/{memberId}/accounts")]
    [ApiController]
    public class AccountsController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        public AccountsController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService ??
                throw new ArgumentNullException(nameof(accountService));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));

        }

        [HttpGet]
        public ActionResult<IEnumerable<AccountReadDto>> GetAllAccountsForMember(int memberId)
        {
            var accounts = _accountService.GetAllAccountsForMember(memberId);
            if (accounts == null || (accounts.Count() == 0))
            {
                return BadRequest();
            }
            return Ok(accounts);
        }

        [HttpGet("{accountId}", Name = "GetAccountForMember")]
        public ActionResult<AccountReadDto> GetAccountForMember(int memberId, int accountId)
        {
            if (!_accountService.GetMemberById(memberId))
            {
                return NotFound();
            }
            AccountReadDto accountDto = _accountService.GetAccountForMember(memberId, accountId);
            if (accountDto != null)
            {
                return Ok(accountDto);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateAccountForMember(int memberId, AccountCreateDto accountCreateDto)
        {

            if (accountCreateDto == null)
                return BadRequest();

            //Check if Member exist
            if (!_accountService.GetMemberById(memberId))
            {
                return NotFound();
            }
            var accountReadDto = _accountService.CreateAccount(memberId, accountCreateDto);
            if (accountReadDto == null)
            {
                return BadRequest();
            }
            return CreatedAtRoute("GetAccountForMember",
              new { memberId = memberId, accountId = accountReadDto.Id },
              accountReadDto);
        }

        [HttpPatch]
        [Route("collectpoints/{accountId}/{points}")]
        public ActionResult CollectAccountPoints(int memberId, int accountId, int points)
        {
            if (!_accountService.GetMemberById(memberId))
            {
                return NotFound();
            }
            AccountReadDto accountDto = _accountService.GetAccountForMember(memberId, accountId);
            if (accountDto == null)
            {
                return NotFound();
            }
            var accountReadDto = _accountService.ManageAccountPoints(true, memberId, accountId, points);
            if (accountReadDto == null)
            {
                return Ok();
            }
            return CreatedAtRoute("GetAccountForMember",
              new { memberId = memberId, accountId = accountReadDto.Id },
              accountReadDto);
        }

        private string GetErrorMessage(AccountReadDto accountDto, int points)
        {
            
            if(accountDto.Status == "INACTIVE")
            {
                return "Account status is INACTIVE";
            }
            else if (accountDto.Balance <= 0 )
            {
                return "Points cannot be redeemed for empty account";
            }
            else if (accountDto.Balance < points)
            {
                return ($"Points cannot be redeemed because of insufficient balance {accountDto.Balance}");
            }
            return null;
        }

        [HttpPatch]
        [Route("redeempoints/{accountId}/{points}")]
        public ActionResult RedeemAccountPoints(int memberId, int accountId, int points)
        {
            AccountReadDto accountDto = _accountService.GetAccountForMember(memberId, accountId);
            if (accountDto == null)
            {
                return NotFound();
            }
            string errorMsg = GetErrorMessage(accountDto, points);
            if (errorMsg != null)
            {
                return BadRequest(errorMsg);
            }

            var accountReadDto = _accountService.ManageAccountPoints(false, memberId, accountId, points);
            if (accountReadDto == null)
            {
                return Ok();
            }
            return CreatedAtRoute("GetAccountForMember",
              new { memberId = memberId, accountId = accountReadDto.Id },
              accountReadDto);
        }

    }
}
