using PhoneBook.Domain.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Contract.Contacts.DTOs.Responses
{
    public class ContactWithDetailsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LName { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public TeamResponseForDetail Team { get; set; }
        public TeamMemberResponseForDetail DirectBoss { get; set; }
    }

    public class TeamResponseForDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
    public class TeamMemberResponseForDetail
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }

    

}
