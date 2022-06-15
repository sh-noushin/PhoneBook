using PhoneBook.Domain.Contacts.Exceptions;
using PhoneBook.Domain.Core;
using PhoneBook.Domain.Shared.Enums;
using PhoneBook.Domain.TeamMembers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Contacts
{
    public class Contact : BaseEntity<int>
    {
        public string Name { get; set; }
        public string LName { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public int DirectBossId { get; set; }
        public TeamMember DirectBoss  { get; set; }

        public Contact()
        {

        }

        public Contact(string name, string lname, Gender gender, string phone, int bossId)
        {
            SetNameAndLname(name, lname);
            Gender = gender;
            PhoneNumber = phone;
            DirectBossId = bossId;

        }

        public void SetNameAndLname(string name, string lname)
        {

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(lname))
            {
                throw new ContactNameIsNullOrWhiteSpaceException();
            }

            Name = name;
            LName = lname;  
        }

    }
}
