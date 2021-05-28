using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MemberManagementSystem.Dtos;
using MemberManagementSystem.Models;
using MemberManagementSystem.Repositories.Interfaces;
using MemberManagementSystem.Services.Interface;

namespace MemberManagementSystem.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public MemberService(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public MemberReadDto GetMemberById(int id)
        {
            var memberFromRepo = _memberRepository.GetMemberById(id);
            if (memberFromRepo != null)
            {
                return _mapper.Map<MemberReadDto>(memberFromRepo);
            }
            return null;
        }

        public IEnumerable<MemberReadDto> GetAllMembers()
        {
            var members = _memberRepository.AllMembers;
            //.GetAllMembers();
            if (members == null || (members.Count() == 0))
            {
                return null;
            }
            return _mapper.Map<IEnumerable<MemberReadDto>>(members);
        }

        public bool CreateMember(MemberCreateDto memberDto)
        {
            Member member = _mapper.Map<Member>(memberDto);
            _memberRepository.CreateMember(member);

            return (_memberRepository.SaveChanges());
            //throw new NotImplementedException();
        }


       

    }
}
