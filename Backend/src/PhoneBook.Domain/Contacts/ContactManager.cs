using PhoneBook.Domain.Contacts.Exceptions;
using PhoneBook.Domain.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Contacts
{
    public class ContactManager : IContactManager
    {

        private readonly IContactRepository _contactRepository;
        public ContactManager(IContactRepository repo)
        {
            _contactRepository = repo;
        }
        public async Task<Contact> CreateAsync(string name, string lname,Gender gender, string phone, int bossId)
        {
            if (await _contactRepository.FindAsync(x => x.Name == name && x.LName == lname) != null)
            {
                throw new ContactAlreadyExistsException(name, lname);
            }
            var contact = new Contact(name, lname, gender, phone, bossId);
            return contact;
        }

        public async Task<Contact> UpdateAsync(Contact input, string name, string lname,Gender gender, string phone, int bossId)
        {
            if (await _contactRepository.FindAsync(x => x.Name == name && x.LName == lname && x.Id != input.Id) != null)
            {
                throw new ContactAlreadyExistsException(name, lname);
            }

            input.SetNameAndLname(name, lname);
            input.Gender = gender;
            input.PhoneNumber = phone;
            input.DirectBossId = bossId;    
            return input;
        }
    }
}
