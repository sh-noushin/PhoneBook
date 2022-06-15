using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.Contract.Teams;
using PhoneBook.Application.Contract.Teams.DTOs.Requests;
using PhoneBook.Application.Contract.Teams.DTOs.Responses;

namespace PhoneBook.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase

    {

        private readonly ITeamService _teamService;


        public TeamController(ITeamService teamservice)
        {
            _teamService = teamservice;

        }


        [HttpPost]
        public async Task<string> CreateAsync([FromBody] TeamCreateRequest input)
        {
            await _teamService.CreateAsync(input);
            return Task.FromResult("Created").ToString();
        }
        [HttpGet]
        public async Task<List<TeamResponse>> GetAllAsync()
        {
            return await _teamService.GetAllAsync();

        }
        [HttpGet]
        [Route("{id}")]
        public async Task<TeamResponse> GetByIdAsync(int id)
        {
            return await _teamService.GetByIdAsync(id);
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<string> UpdateAsync(int id, TeamUpdateRequest input)
        {
            await _teamService.UpdateAsync(id, input);
            return Task.FromResult("Updated").ToString();

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<string> DeleteAsync(int id)
        {
            await _teamService.DeleteAsync(id);
            return Task.FromResult("Deleted").ToString();
        }

    }
}
