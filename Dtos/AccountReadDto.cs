using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberManagementSystem.Dtos
{
    public class AccountReadDto
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
        public string Status { get; set; }

        //public MemberReadDto member { get; set; }
    }
}
