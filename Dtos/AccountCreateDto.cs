using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MemberManagementSystem.Dtos
{
    public class AccountCreateDto
    {
        //public int MemberId { get; set; }
        [Required]
        [MaxLength(70)]
        public string Name { get; set; }

        public int Balance { get; set; }

        [Required]
        public string Status { get; set; }

       // public MemberCreateDto member { get; set; }
    }
}
