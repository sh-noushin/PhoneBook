using PhoneBook.Application.Contacts;
using PhoneBook.Application.Contract.Contacts;
using PhoneBook.Application.Contract.TeamMembers;
using PhoneBook.Application.Contract.Teams;
using PhoneBook.Application.TeamMembers;
using PhoneBook.Application.Teams;
using PhoneBook.Domain.Contacts;
using PhoneBook.Domain.TeamMembers;
using PhoneBook.Domain.Teams;
using PhoneBook.EntityFrameworkCore.Contacts;
using PhoneBook.EntityFrameworkCore.TeamMembers;
using PhoneBook.EntityFrameworkCore.Teams;

namespace PhoneBook.WebAPI.Extentions
{
    public static class IServiceExtentions
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<ITeamManager, TeamManager>();
            services.AddScoped<ITeamRepository, TeamRepository>();

            services.AddScoped<ITeamMemberService, TeamMemberService>();
            services.AddScoped<ITeamMemberManager, TeamMemberManager>();
            services.AddScoped<ITeamMemberRepository, TeamMemberRepository>();

            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IContactManager, ContactManager>();
            services.AddScoped<IContactRepository, ContactRepository>();

            services.AddAutoMapper(typeof(PhoneBook.Application.Contacts.ContactsMappingProfile).Assembly);
            services.AddAutoMapper(typeof(PhoneBook.Application.Teams.TeamsMappingProfile).Assembly);
            services.AddAutoMapper(typeof(PhoneBook.Application.TeamMembers.TeamMembersMappingProfile).Assembly);


            return services;
        }
    }
}
