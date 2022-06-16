using PhoneBook.Application.Contacts;
using PhoneBook.Application.Contract.Contacts;
using PhoneBook.Application.Contract.Contacts.DTOs.Requests;
using PhoneBook.Domain.Shared.Enums;
using System.Threading.Tasks;
using Xunit;

namespace PhoneBook.EntityFrameWorkCore.Test
{
    public class ContactServiceTest : IClassFixture<ContactService>
    {
        private readonly ContactService _contactService;
        public ContactServiceTest(ContactService contactService)
        {
            _contactService = contactService;
        }
        [Fact]
        public async Task CreateContactTest()
        {

            var contact = new ContactCreateRequest();
            contact.Name = "Sara";
            contact.LName = "Alizade";
            contact.PhoneNumber = "+49 512 55454543";
            contact.Gender = Gender.Woman;
            contact.DirectBossId = 0;
            await _contactService.CreateAsync(contact);
        }
    }
}
