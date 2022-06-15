using PhoneBook.Domain.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Contacts.Views
{
    public class ContactWithDetailsView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lname { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public TeamView Team { get; set; }
        public DirectBossView DirectBoss { get; set; }
    }
}
