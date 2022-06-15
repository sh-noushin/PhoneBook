using PhoneBook.Application.Contract.Core.DTOs.Responses;
using PhoneBook.Application.Contract.Teams.DTOs.Requests;
using PhoneBook.Application.Contract.Teams.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Contract.Teams
{
    public interface ITeamService
    {
        Task CreateAsync(TeamCreateRequest input);
        Task UpdateAsync(int id, TeamUpdateRequest input);
        Task DeleteAsync(int id);
        Task<List<TeamResponse>> GetAllAsync();
        Task<TeamResponse> GetByIdAsync(int id);
    }
}
