using PhoneBook.Domain.TeamMembers.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.TeamMembers
{
    public class TeamMemberManager : ITeamMemberManager
    {
        private readonly ITeamMemberRepository _teamMemberRepository;

        public TeamMemberManager(ITeamMemberRepository repo)
        {
            _teamMemberRepository = repo;
        }
        public async Task<TeamMember> ChangeTeamAsync(int newTeamId, TeamMember input)
        {
            if (await _teamMemberRepository.FindAsync(x => x.TeamId == newTeamId && x.FullName == input.FullName) != null)
            {
                throw new TeamMemberCannotBeMovedToAnotherTeamException(newTeamId, input.FullName);
            }

            input.SetTeam(newTeamId);
            return input;
        }

        public async Task<TeamMember> CreateAsync(int teamId, string name)
        {
            if (await _teamMemberRepository.FindAsync(x => x.FullName == name) != null)
            {
                throw new TeamMemberAlreadyExistsException(name);
            }
            var teamMember = new TeamMember(teamId, name);
            return teamMember;
        }

        public async Task<TeamMember> UpdateAsync(TeamMember input, string name)
        {
            if (await _teamMemberRepository.FindAsync(x => x.FullName == name
                && x.Id != input.Id &&
                x.TeamId == input.TeamId)
                != null)
            {
                throw new TeamMemberAlreadyExistsException(name, input.TeamId);
            }

            input.SetName(name);
            return input;
        }
    }
}
