using PhoneBook.Domain.Teams.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Teams
{
    public class TeamManager : ITeamManager
    {
        private readonly ITeamRepository _teamRepository;
        public TeamManager(ITeamRepository repo)
        {
            _teamRepository = repo;
        }

        public async Task<Team> CreateAsync(string name)
        {
            var temp = await _teamRepository.FindAsync(x => x.Name == name);
            if (temp != null)
            {
                throw new TeamAlreadyExistsException(name);
            }
            var team = new Team(name);
            return team;
        }

        public async Task<Team> UpdateAsync(Team input, string name)
        {
            if (await _teamRepository.FindAsync(x => x.Name == name && x.Id != input.Id) != null)
            {
                throw new TeamAlreadyExistsException(name);
            }

            input.SetName(name);
            return input;
        }
    }
}
