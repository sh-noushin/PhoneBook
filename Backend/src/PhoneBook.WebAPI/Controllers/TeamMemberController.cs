using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.Contract.TeamMembers;
using PhoneBook.Application.Contract.TeamMembers.DTOs.Requests;
using PhoneBook.Application.Contract.TeamMembers.DTOs.Responses;

namespace PhoneBook.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamMemberController : ControllerBase

    {

        private readonly ITeamMemberService _teamMemberService;


        public TeamMemberController(ITeamMemberService teammemberservice)
        {
            _teamMemberService = teammemberservice;

        }


        [HttpPost]
        public async Task<string> CreateAsync(TeamMemberCreateRequest input)
        {
            await _teamMemberService.CreateAsync(input);
            return Task.FromResult("Created").ToString();
        }
        [HttpGet]
        public async Task<List<TeamMemberResponse>> GetAllAsync()
        {
            return await _teamMemberService.GetAllAsync();

        }
        [HttpGet]
        [Route("{id}")]
        public async Task<TeamMemberResponse> GetByIdAsync(int id)
        {
            return await _teamMemberService.GetByIdAsync(id);
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<string> UpdateAsync(int id, TeamMemberUpdateRequest input)
        {
            await _teamMemberService.UpdateAsync(id, input);
            return Task.FromResult("Updated").ToString();

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<string> DeleteAsync(int id)
        {
            await _teamMemberService.DeleteAsync(id);
            return Task.FromResult("Deleted").ToString();
        }

    }
}


