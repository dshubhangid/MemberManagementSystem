using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MemberManagementSystem.Dtos
{
    public class MemberCreateDto
    {
        [Required]
        [MaxLength(70)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        public IEnumerable<AccountDto> Accounts { get; set; }

    }
}
