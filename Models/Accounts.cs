using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MemberManagementSystem.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public int? MemberId { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
        public string Status { get; set; }
        [ForeignKey("MemberId")]
        public Member member { get; set; }
    }
}
