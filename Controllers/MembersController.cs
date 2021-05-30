using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MemberManagementSystem.Dtos;
using MemberManagementSystem.Services.Interface;
using AutoMapper;
using MemberManagementSystem.FilterResource;

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

        [HttpGet]
        public ActionResult<IEnumerable<MemberReadDto>> GetAllMembers()
        {
            var members = _memberService.GetAllMembers();
            if (members == null || (members.Count() == 0))
            {
                return BadRequest();
            }
            return Ok(members);
        }

        [HttpGet("{id}", Name = "GetMemberById")]
        public ActionResult<MemberReadDto> GetMemberById(int id)
        {

            MemberReadDto memberDto = _memberService.GetMemberById(id);
            if (memberDto != null)
            {
                return Ok(memberDto);
            }
            return NotFound();
        }

        [HttpPost]
        [Route("uploadmembers")]
        public IActionResult CreateMultipleMembers(IEnumerable<MemberCreateDto> memberCreateDtoList)
        {
            if (memberCreateDtoList == null)
                return BadRequest();

            foreach(MemberCreateDto memberCreateDto in memberCreateDtoList)
            {
                if(memberCreateDto != null)
                {
                    if(!_memberService.CreateMember(memberCreateDto))
                    {
                        return BadRequest(); 
                    }
                }
            }
            //Console.WriteLine("HEre is helloworld :" + memberCreateDtoList);
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateMember(MemberCreateDto memberCreateDto)
        {
            if (memberCreateDto == null)
                return BadRequest();
            if (_memberService.CreateMember(memberCreateDto))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet()]
        [Route("exportmembers")]

        public ActionResult<IEnumerable<MemberReadDto>> GetAllFilteredMembers(
          [FromQuery] MemberFilterParameter memberFilterParameter)
        {
            var memberListFromRepo =_memberService.GetAllFilteredMembers(memberFilterParameter);
            return Ok(_mapper.Map<IEnumerable<MemberReadDto>>(memberListFromRepo));

        }

    }
}
