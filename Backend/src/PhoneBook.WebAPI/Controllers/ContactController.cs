using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.Contract.Contacts;
using PhoneBook.Application.Contract.Contacts.DTOs.Requests;
using PhoneBook.Application.Contract.Contacts.DTOs.Responses;
using PhoneBook.Application.Contract.Core.DTOs.Responses;
using PhoneBook.Domain.Contacts;

namespace PhoneBook.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase

    {

        private readonly IContactService _contactService;



        public ContactController(IContactService contactservice)
        {
            _contactService = contactservice;

        }

        [HttpPost]
        public Task CreateAsync(ContactCreateRequest input)
        {
            return _contactService.CreateAsync(input);
        }
        [HttpGet]
        public async Task<PagedResultResponse<ContactResponse>> GetAllAsync([FromQuery] GetContactsRequest input)
        {
            return await _contactService.GetAllAsync(input);

        }

        [HttpGet("details")]

        public async Task<PagedResultResponse<ContactWithDetailsResponse>> GetAllWithDetailsAsync([FromQuery] GetContactsWithDetailsRequest input)
        {
            return await _contactService.GetAllWithDetailsAsync(input);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ContactResponse> GetByIdAsync(int id)
        {
            return await _contactService.GetByIdAsync(id);
        }


        [HttpPut]
        [Route("{id}")]
        public Task UpdateAsync(int id, ContactUpdateRequest input)
        {
            return _contactService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(int id)
        {
           return _contactService.DeleteAsync(id);
        }




    }
}
