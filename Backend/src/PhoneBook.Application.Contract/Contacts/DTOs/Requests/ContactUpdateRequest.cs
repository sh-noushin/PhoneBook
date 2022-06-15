using PhoneBook.Domain.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Contract.Contacts.DTOs.Requests
{
    public class ContactUpdateRequest
    {
        public string Name { get; set; }
        public string LName { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public int DirectBossId { get; set; }
    }
}
