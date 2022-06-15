using PhoneBook.Domain.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Contacts.Filters
{
    public class ContactWithDetailsFilter
    {
        public string? AnyFilter { get; set; } = "";
        public string Name { get; set; } = "";
        public string LName { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public Gender? Gender { get; set; } 
        public string TeamName { get; set; } = "";
        public string DirectBossFullName { get; set; } = "";

    }
}
