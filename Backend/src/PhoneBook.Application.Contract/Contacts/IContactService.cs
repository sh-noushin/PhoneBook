using PhoneBook.Application.Contract.Contacts.DTOs.Requests;
using PhoneBook.Application.Contract.Contacts.DTOs.Responses;
using PhoneBook.Application.Contract.Core.DTOs.Responses;


namespace PhoneBook.Application.Contract.Contacts
{
    public interface IContactService
    {
        Task CreateAsync(ContactCreateRequest input);
        Task UpdateAsync(int id, ContactUpdateRequest input);
        Task DeleteAsync(int id);
        Task<PagedResultResponse<ContactResponse>> GetAllAsync(GetContactsRequest filter);
        Task<PagedResultResponse<ContactWithDetailsResponse>> GetAllWithDetailsAsync(GetContactsWithDetailsRequest filter);
        Task<ContactResponse> GetByIdAsync(int id);
    }
}
