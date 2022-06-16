using PhoneBook.Domain.Contacts.Exceptions;
using PhoneBook.Domain.Shared.Enums;
using PhoneBook.Domain.TeamMembers;
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
        private readonly ITeamMemberRepository _teamMemberRepository;
        public ContactManager(IContactRepository repo, ITeamMemberRepository teamRepo)
        {
            _contactRepository = repo;
            _teamMemberRepository = teamRepo;   
        }
        public async Task<Contact> CreateAsync(string name, string lname,Gender gender, string phone, int bossId)
        {
            if(await _teamMemberRepository.FindAsync(x => x.Id == bossId) == null)
            {
                throw new ContactDirectBossIdIsNotValidException(bossId);
            }
            if (await _contactRepository.FindAsync(x => x.Name == name && x.LName == lname) != null)
            {
                throw new ContactAlreadyExistsException(name, lname);
            }
            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(lname))
            {
                throw new ContactNameIsNullOrWhiteSpaceException();
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
