using PhoneBook.Domain.Contacts.Filters;
using PhoneBook.Domain.Contacts.Views;
using PhoneBook.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Contacts
{
    public interface IContactRepository : IBaseRepository<Contact, int>
    {
        public Task<List<Contact>> GetAllAsync(string filterText, string sorting, int skipCount = 0, int maxResultCount = 10);
        public Task<List<ContactWithDetailsView>> GetAllWithDetailsAsync(string filterText, string sorting, int skipCount = 0, int maxResultCount = 10);
        public Task<List<ContactWithDetailsView>> GetAllWithDetailsAsync(ContactWithDetailsFilter filter, string sorting, int skipCount = 0, int maxResultCount = 10);

        public Task<long> GetCountAsync(string filterText);
        public Task<long> GetCountAsync(ContactWithDetailsFilter filter);
        Task<Contact> GetByNameAsync(string name, string lname);
    }
}
