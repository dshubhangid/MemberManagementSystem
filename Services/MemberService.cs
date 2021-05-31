using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MemberManagementSystem.Dtos;
using MemberManagementSystem.FilterResource;
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

        public IEnumerable<Member> GetAllFilteredMembers(MemberFilterParameter memberFilterParameter)
        {
            return (_memberRepository.GetAllFilteredMembers(memberFilterParameter));
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

        public MemberReadDto CreateMember(MemberCreateDto memberDto)
        {
            Member member = _mapper.Map<Member>(memberDto);
            _memberRepository.CreateMember(member);
            _memberRepository.SaveChanges();
           
            var memberReadDto = _mapper.Map<MemberReadDto>(member);
            return memberReadDto;
        }

       
    }
}
