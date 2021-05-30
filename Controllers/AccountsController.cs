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
    [Route("api/account")]
    [ApiController]
    public class AccountsController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        public AccountsController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AccountReadDto>> GetAllAccounts()
        {
            var members = _accountService.GetAllAccounts();
            if (members == null || (members.Count() == 0))
            {
                return BadRequest();
            }
            return Ok(members);
        }

        [HttpGet("{id}", Name = "GetAccountById")]
        public ActionResult<AccountReadDto> GetAccountById(int id)
        {

            AccountReadDto accountDto = _accountService.GetAccountById(id);
            if (accountDto != null)
            {
                return Ok(accountDto);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateAccount(AccountCreateDto accountCreateDto)
        {
            //Check if Member exist

            if (accountCreateDto == null)
                return BadRequest();

            if (_accountService.CreateAccount(accountCreateDto))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPatch]
        [Route("collectpoints/{id}/{points}")]
        public ActionResult CollectAccountPoints(int id, int points)
        {
            AccountReadDto accountDto = _accountService.GetAccountById(id);
            if (accountDto == null)
            {
                return NotFound();
            }
            if (_accountService.ManageAccountPoints(true,id, points))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPatch]
        [Route("redeempoints/{id}/{points}")]
        public ActionResult RedeemAccountPoints(int id, int points)
        {
            AccountReadDto accountDto = _accountService.GetAccountById(id);
            if (accountDto == null)
            {
                return NotFound();
            }
            if (accountDto.Status == "INACTIVE"|| accountDto.Balance < points)
            {
                return BadRequest();
            }

            if (_accountService.ManageAccountPoints(false,id,points))
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}
