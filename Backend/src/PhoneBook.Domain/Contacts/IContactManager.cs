using PhoneBook.Domain.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Contacts
{
    public interface IContactManager
    {
        Task<Contact> CreateAsync(string name, string lname, Gender gender, string phone, int bossId);
        Task<Contact> UpdateAsync(Contact input, string name, string lname,Gender gender, string phone, int bossId);
    }
}
