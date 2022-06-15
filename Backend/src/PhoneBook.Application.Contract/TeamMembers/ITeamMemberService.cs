using PhoneBook.Application.Contract.Core.DTOs.Responses;
using PhoneBook.Application.Contract.TeamMembers.DTOs.Requests;
using PhoneBook.Application.Contract.TeamMembers.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Contract.TeamMembers
{
    public interface ITeamMemberService
    {
        Task CreateAsync(TeamMemberCreateRequest input);
        Task UpdateAsync(int id, TeamMemberUpdateRequest input);
        Task DeleteAsync(int id);
        Task<List<TeamMemberResponse>> GetAllAsync();
        Task<TeamMemberResponse> GetByIdAsync(int id);
    }
}
