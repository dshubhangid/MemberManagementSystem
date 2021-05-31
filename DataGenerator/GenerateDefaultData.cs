using MemberManagementSystem.Models;
using MemberManagementSystem.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemberManagementSystem.DataGenerator
{
    public class GenerateDefaultData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MemberManagementDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<MemberManagementDbContext>>()))
            {
                // Look for any Member
                if (context.Members.Any())
                {
                    return;   // Data was already seeded
                }
                else
                {
                    context.Members.AddRange(
                            new Member
                            {
                                Id = 1,
                                Name = "Ajinkya Ranade",
                                Address = "RavivarPeth 4",
                            },
                            new Member
                            {
                                Id = 2,
                                Name = "Anand chavan",
                                Address = "Shaniwarwada 150",
                            },
                            new Member
                            {
                                Id = 3,
                                Name = "Rahul Joshi",
                                Address = "ShukrawarPeth 67",
                            },
                            new Member
                            {
                                Id = 4,
                                Name = "Onkar Patil",
                                Address = "BudhwarPeth 10",
                            },
                            new Member
                            {
                                Id = 5,
                                Name = "Vishal Kapse",
                                Address = "GuruwarPeth 4",
                            }
                        );
                }

                if (context.Accounts.Any())
                {
                    return;   // Data was already seeded
                }
                else
                {
                    context.Accounts.AddRange(
                        new Account { Id = 1, MemberId = 1, Name ="Vada Pav", Balance = 50, Status = "ACTIVE" },
                        new Account { Id = 2, MemberId = 1, Name = "AmrutTulya", Balance = 200, Status = "ACTIVE" },
                        new Account { Id = 3, MemberId = 2, Name = "KFC", Balance = 100, Status = "ACTIVE" },
                        new Account { Id = 4, MemberId = 3, Name = "JetAirways", Balance = 90, Status = "INACTIVE" },
                        new Account { Id = 5, MemberId = 3, Name = "Vada Pav", Balance = 10, Status = "ACTIVE" },
                        new Account { Id = 6, MemberId = 4, Name = "AmrutTulya", Balance = 40, Status = "ACTIVE" },
                        new Account { Id = 7, MemberId = 4, Name = "AirIndia", Balance = 95, Status = "ACTIVE" },
                        new Account { Id = 8, MemberId = 4, Name = "JetAirways", Balance = 65, Status = "INACTIVE" },
                        new Account { Id = 9, MemberId = 5, Name = "AirIndia", Balance = 45, Status = "ACTIVE" }

                    );
                }
                context.SaveChanges();
            }
        }
    }
}
