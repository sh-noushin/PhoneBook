﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhoneBook.EntityFrameworkCore;

#nullable disable

namespace PhoneBook.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(PhoneBookDbContext))]
    partial class PhoneBookDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PhoneBook.Domain.Contacts.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DirectBossId")
                        .HasColumnType("int");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DirectBossId");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DirectBossId = 1,
                            Gender = 0,
                            LName = " Rezayi",
                            Name = "Ali",
                            PhoneNumber = "+1 (413) 656656"
                        },
                        new
                        {
                            Id = 2,
                            DirectBossId = 1,
                            Gender = 0,
                            LName = " Ahmadi",
                            Name = "Reza",
                            PhoneNumber = "+49 453 78786776"
                        },
                        new
                        {
                            Id = 3,
                            DirectBossId = 2,
                            Gender = 1,
                            LName = " Mirof",
                            Name = "Mike",
                            PhoneNumber = "+98 (756) 97787878"
                        },
                        new
                        {
                            Id = 4,
                            DirectBossId = 3,
                            Gender = 0,
                            LName = " Sadeghi",
                            Name = "Erfan",
                            PhoneNumber = "+97 554 7668668"
                        },
                        new
                        {
                            Id = 5,
                            DirectBossId = 4,
                            Gender = 1,
                            LName = " Jouns",
                            Name = "Erica",
                            PhoneNumber = "+12 (767) 9797799"
                        },
                        new
                        {
                            Id = 6,
                            DirectBossId = 5,
                            Gender = 0,
                            LName = " Kavian",
                            Name = "Andres",
                            PhoneNumber = "+78 988 7667676"
                        },
                        new
                        {
                            Id = 7,
                            DirectBossId = 7,
                            Gender = 1,
                            LName = " Sarapova",
                            Name = "Julia",
                            PhoneNumber = "+12 (654) 98878778"
                        });
                });

            modelBuilder.Entity("PhoneBook.Domain.TeamMembers.TeamMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamMembers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "Jozef Mayer",
                            TeamId = 1
                        },
                        new
                        {
                            Id = 2,
                            FullName = "Bernard F",
                            TeamId = 1
                        },
                        new
                        {
                            Id = 3,
                            FullName = "Fatih Akay",
                            TeamId = 2
                        },
                        new
                        {
                            Id = 4,
                            FullName = "Mehmet Ozan",
                            TeamId = 3
                        },
                        new
                        {
                            Id = 5,
                            FullName = "Shirin Rezaee",
                            TeamId = 2
                        },
                        new
                        {
                            Id = 6,
                            FullName = "Albert Dario",
                            TeamId = 4
                        },
                        new
                        {
                            Id = 7,
                            FullName = "Stephen Jack",
                            TeamId = 3
                        });
                });

            modelBuilder.Entity("PhoneBook.Domain.Teams.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Frontend"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Analizing"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Testing"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Backend"
                        });
                });

            modelBuilder.Entity("PhoneBook.Domain.Contacts.Contact", b =>
                {
                    b.HasOne("PhoneBook.Domain.TeamMembers.TeamMember", "DirectBoss")
                        .WithMany()
                        .HasForeignKey("DirectBossId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DirectBoss");
                });

            modelBuilder.Entity("PhoneBook.Domain.TeamMembers.TeamMember", b =>
                {
                    b.HasOne("PhoneBook.Domain.Teams.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });
#pragma warning restore 612, 618
        }
    }
}
