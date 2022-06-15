using AutoMapper;
using PhoneBook.Application.Contract.TeamMembers;
using PhoneBook.Application.Contract.TeamMembers.DTOs.Requests;
using PhoneBook.Application.Contract.TeamMembers.DTOs.Responses;
using PhoneBook.Domain.TeamMembers;
using PhoneBook.Domain.TeamMembers.Exceptions;
using PhoneBook.Domain.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.TeamMembers
{
    public class TeamMemberService : ITeamMemberService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly ITeamMemberRepository _teamMemberRepository;
        private readonly ITeamMemberManager _teamMemberManager;
        private readonly IMapper _mapper;

        public TeamMemberService(ITeamRepository teamrepository, ITeamMemberRepository teamMemberRepository, ITeamMemberManager teamMemberManager, IMapper mapper)
        {
            _teamRepository = teamrepository;
            _teamMemberRepository = teamMemberRepository;
            _teamMemberManager = teamMemberManager;
            _mapper = mapper;

        }

        public TeamMemberService()
        {

        }
        public async Task CreateAsync(TeamMemberCreateRequest input)
        {
            var teamMember = await _teamMemberManager.CreateAsync(input.TeamId,input.FullName);
            if (teamMember != null)
            {
                await _teamMemberRepository.CreateAsync(teamMember);
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _teamMemberRepository.DeleteAsync(id);
        }

        public async Task<List<TeamMemberResponse>> GetAllAsync()
        {
            var items = await _teamMemberRepository.GetListAsync();
            return _mapper.Map<List<TeamMember>, List<TeamMemberResponse>>(items);
        }

        public async Task<TeamMemberResponse> GetByIdAsync(int id)
        {
            return _mapper.Map<TeamMember, TeamMemberResponse>(await _teamMemberRepository.GetAsync(id));
        }

        public async Task UpdateAsync(int id, TeamMemberUpdateRequest input)
        {
            var teamMember = await _teamMemberRepository.GetAsync(id);
            if (teamMember != null)
            {
                var updatedTeamMember = await _teamMemberManager.UpdateAsync(teamMember, input.FullName);
                await _teamMemberRepository.UpdateAsync(updatedTeamMember);
            }
            else
            {
                throw new TeamMemberNotFoundException(id);
            }
        }
    }
}
