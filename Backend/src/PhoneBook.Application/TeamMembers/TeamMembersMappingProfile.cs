using AutoMapper;
using PhoneBook.Application.Contract.TeamMembers.DTOs.Responses;
using PhoneBook.Domain.TeamMembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.TeamMembers
{
    public class TeamMembersMappingProfile : Profile
    {
        public TeamMembersMappingProfile()
        {
            CreateMap<TeamMember, TeamMemberResponse>();
        }
    }
}
