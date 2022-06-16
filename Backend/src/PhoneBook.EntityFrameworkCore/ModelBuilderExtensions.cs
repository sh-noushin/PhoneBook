using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain.Contacts;
using PhoneBook.Domain.Shared.Enums;
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

            modelBuilder.Entity<Contact>().HasData(
               new Contact { Id = 1, DirectBossId = 1, Name = "Ali" , LName = " Rezayi" , Gender =(Gender)0 , PhoneNumber ="+1 (413) 656656"},
               new Contact { Id = 2, DirectBossId = 1, Name = "Reza", LName = " Ahmadi", Gender = (Gender)0 , PhoneNumber = "+49 453 78786776" },
               new Contact { Id = 3, DirectBossId = 2, Name = "Mike" , LName = " Mirof", Gender = (Gender)1 , PhoneNumber = "+98 (756) 97787878" },
               new Contact { Id = 4, DirectBossId = 3, Name = "Erfan", LName = " Sadeghi", Gender = (Gender)0 ,PhoneNumber = "+97 554 7668668" },
               new Contact { Id = 5, DirectBossId = 4, Name = "Erica" , LName = " Jouns", Gender = (Gender)1 , PhoneNumber = "+12 (767) 9797799" },
               new Contact { Id = 6, DirectBossId = 5, Name = "Andres", LName = " Kavian", Gender = (Gender)0 , PhoneNumber = "+78 988 7667676" },
               new Contact { Id = 7, DirectBossId = 7, Name = "Julia" , LName = " Sarapova", Gender = (Gender)1 , PhoneNumber = "+12 (654) 98878778" }
           );
        }
    }
}
