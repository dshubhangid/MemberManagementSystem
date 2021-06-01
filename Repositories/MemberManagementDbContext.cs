using MemberManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberManagementSystem.Repositories
{
    public class MemberManagementDbContext : DbContext 
    {
        public MemberManagementDbContext(DbContextOptions<MemberManagementDbContext> opt) : base(opt)
        {

        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
