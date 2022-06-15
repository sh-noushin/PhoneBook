using PhoneBook.Application.Contract.TeamMembers.DTOs.Responses;
using PhoneBook.Application.Contract.Teams.DTOs.Responses;
using PhoneBook.Domain.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Contract.Contacts.DTOs.Responses
{
    public class ContactResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LName { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public int DirectBossId { get; set; }

    }
}
