using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain.TeamMembers;
using PhoneBook.Domain.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.EntityFrameworkCore
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Team>().HasData(
                new Team
                {
                    Id = 1,
                    Name = "Frontend"

                },
                new Team
                {
                    Id = 2,
                    Name = "Analizing"

                },
                new Team
                {
                    Id = 3,
                    Name = "Testing"

                },
                new Team
                {
                    Id = 4,
                    Name = "Backend"

                }
            );
            modelBuilder.Entity<TeamMember>().HasData(
                new TeamMember { Id = 1, TeamId = 1, FullName = "Jozef Mayer" },
                new TeamMember { Id = 2, TeamId = 1, FullName = "Bernard F" },
                new TeamMember { Id = 3, TeamId = 2, FullName = "Fatih Akay" },
                new TeamMember { Id = 4, TeamId = 3, FullName = "Mehmet Ozan" },
                new TeamMember { Id = 5, TeamId = 2, FullName = "Shirin Rezaee" },
                new TeamMember { Id = 6, TeamId = 4, FullName = "Albert Dario" },
                new TeamMember { Id = 7, TeamId = 3, FullName = "Stephen Jack" }
            );
        }
    }
}
