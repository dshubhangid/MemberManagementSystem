using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MemberManagementSystem.Dtos;
using MemberManagementSystem.Services.Interface;
using AutoMapper;

namespace MemberManagementSystem.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/member")]
    [ApiController]
    public class MembersController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly IMapper _mapper;
        public MembersController(IMemberService memberService, IMapper mapper)
        {
            _memberService = memberService;
            _mapper = mapper;
        }
         public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMember(MemberCreateDto memberCreateDto)
        {
            if (memberCreateDto == null)
                return BadRequest();
            if (_memberService.CreateMembersWithAccounts(memberCreateDto))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
