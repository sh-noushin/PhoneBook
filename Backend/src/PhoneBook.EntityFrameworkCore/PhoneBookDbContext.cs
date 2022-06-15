using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain.Contacts;
using PhoneBook.Domain.Teams;
using PhoneBook.Domain.TeamMembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.EntityFrameworkCore
{
    public class PhoneBookDbContext: DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }

        public PhoneBookDbContext(DbContextOptions options)
           : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TeamMember>()
                        .HasOne(x => x.Team)
                        .WithMany()
                        .HasForeignKey(x => x.TeamId).IsRequired();

            builder.Seed();
            builder.Entity<Contact>()
                       .HasOne(x => x.DirectBoss)
                       .WithMany()
                       .HasForeignKey(x => x.DirectBossId).IsRequired();


        }
    }
}
