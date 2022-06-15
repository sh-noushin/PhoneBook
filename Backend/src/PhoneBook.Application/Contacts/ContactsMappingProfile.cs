using AutoMapper;
using PhoneBook.Application.Contract.Contacts.DTOs.Responses;
using PhoneBook.Domain.Contacts;
using PhoneBook.Domain.Contacts.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Contacts
{
    public class ContactsMappingProfile : Profile
    {
        public ContactsMappingProfile()
        {
            // Contact 
            CreateMap<Contact, ContactResponse>();

            // ContactWithDetailsView
            CreateMap<TeamView, TeamResponseForDetail>();
            CreateMap<DirectBossView, TeamMemberResponseForDetail>();
            CreateMap<ContactWithDetailsView, ContactWithDetailsResponse>();
        }
    }
}
