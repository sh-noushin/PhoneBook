using AutoMapper;
using PhoneBook.Application.Contract.Teams.DTOs.Responses;
using PhoneBook.Domain.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Teams
{
    public class TeamsMappingProfile : Profile
    {
        public TeamsMappingProfile()
        {
            CreateMap<Team, TeamResponse>();
        }
    }
}
