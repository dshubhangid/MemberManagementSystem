using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MemberManagementSystem.Models
{
    public class Account
    {
        //    "Name": "Burger King",
        //"Balance": 10,
        //"Status": "ACTIVE"

        [Key]
        public int Id { get; set; }
        public int? MemberId { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
        public string Status { get; set; }
        public Member member { get; set; }
    }
}
