using AutoMapper;
using PhoneBook.Application.Contract.Contacts;
using PhoneBook.Application.Contract.Contacts.DTOs.Requests;
using PhoneBook.Application.Contract.Contacts.DTOs.Responses;
using PhoneBook.Application.Contract.Core.DTOs.Responses;
using PhoneBook.Domain.Contacts;
using PhoneBook.Domain.Contacts.Exceptions;
using PhoneBook.Domain.Contacts.Filters;
using PhoneBook.Domain.Contacts.Views;


namespace PhoneBook.Application.Contacts
{
    public class ContactService : IContactService
    {

        private readonly IContactRepository _contactRepository;
        private readonly IContactManager _contactManager;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository contactepository, IContactManager contactManager, IMapper mapper)
        {
            _contactRepository = contactepository;
            _contactManager = contactManager;
            _mapper = mapper;

        }

        public ContactService()
        {

        }
        public async Task CreateAsync(ContactCreateRequest input)
        {
            var contact = await _contactManager.CreateAsync(input.Name, input.LName, input.Gender, input.PhoneNumber, input.DirectBossId);
            if (contact != null)
            {
                await _contactRepository.CreateAsync(contact);
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _contactRepository.DeleteAsync(id);
        }

        public async Task<PagedResultResponse<ContactResponse>> GetAllAsync(GetContactsRequest filter)
        {
            long totalCount = await _contactRepository.GetCountAsync(filter.FilterText);

            var items = await _contactRepository.GetAllAsync(
                filter.FilterText,
                filter.Sorting,
                filter.SkipCount,
                filter.MaxResultCount);
            return new PagedResultResponse<ContactResponse>()
            {
                TotalCount = totalCount,
                Items = _mapper.Map<List<Contact>, List<ContactResponse>>(items)
            };
        }

        public async Task<PagedResultResponse<ContactWithDetailsResponse>> GetAllWithDetailsAsync(GetContactsWithDetailsRequest input)
        {
            var filter = new ContactWithDetailsFilter
            {
                AnyFilter= input.AnyFilter,
                Name = input.Name,
                LName = input.LName,
                PhoneNumber = input.PhoneNumber,
                Gender = input.Gender,
                TeamName = input.TeamName,
                DirectBossFullName = input.DirectBossFullName

            };
            long totalCount = await _contactRepository.GetCountAsync(filter);
            var items = await _contactRepository.GetAllWithDetailsAsync(filter, input.Sorting, input.SkipCount, input.MaxResultCount);

            return new PagedResultResponse<ContactWithDetailsResponse>()
            {
                TotalCount = totalCount,
                Items = _mapper.Map<List<ContactWithDetailsView>, List<ContactWithDetailsResponse>>(items)
            };
        }

        public async Task<ContactResponse> GetByIdAsync(int id)
        {
            return _mapper.Map<Contact, ContactResponse>(await _contactRepository.GetAsync(id));
        }

        public async Task UpdateAsync(int id, ContactUpdateRequest input)
        {
            var contact = await _contactRepository.GetAsync(id);
            if (contact != null)
            {
                var updatedContact = await _contactManager.UpdateAsync(contact, input.Name, input.LName, input.Gender,
                    input.PhoneNumber, input.DirectBossId);

                await _contactRepository.UpdateAsync(updatedContact);
            }
            else
            {
                throw new ContactNotFoundException(id);
            }
        }
    }
}
