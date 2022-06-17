using PhoneBook.Domain.Contacts.Exceptions;
using PhoneBook.Domain.Helpers;
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
        private readonly IPhoneValidator _phoneValidator;
        public ContactManager(IContactRepository repo, ITeamMemberRepository teamRepo, IPhoneValidator phoneValidator)
        {
            _contactRepository = repo;
            _teamMemberRepository = teamRepo;
            _phoneValidator = phoneValidator;
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
            if(string.IsNullOrEmpty(phone))
            {
                throw new PhoneNumberIsEmptyException();
            }
            _phoneValidator.ValidatePhoneNumber(phone);
            var contact = new Contact(name, lname, gender, phone, bossId);
            return contact;
        }

        public async Task<Contact> UpdateAsync(Contact input, string name, string lname,Gender gender, string phone, int bossId)
        {
            if (await _contactRepository.FindAsync(x => x.Name == name && x.LName == lname && x.Id != input.Id) != null)
            {
                throw new ContactAlreadyExistsException(name, lname);
            }
            if (string.IsNullOrEmpty(phone))
            {
                throw new PhoneNumberIsEmptyException();
            }
            _phoneValidator.ValidatePhoneNumber(phone);
            input.SetNameAndLname(name, lname);
            input.Gender = gender;
            input.PhoneNumber = phone;
            input.DirectBossId = bossId;    
            return input;
        }
    }
}
