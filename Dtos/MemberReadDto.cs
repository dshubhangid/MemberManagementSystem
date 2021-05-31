using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberManagementSystem.Dtos
{
    public class MemberReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        //public IEnumerable<AccountReadDto> Accounts { get; set; }
    }
}
