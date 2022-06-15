using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain.TeamMembers;
using PhoneBook.Domain.TeamMembers.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.EntityFrameworkCore.TeamMembers
{
    public class TeamMemberRepository: BaseRepository<PhoneBookDbContext,TeamMember, int> , ITeamMemberRepository
    {
        public TeamMemberRepository(PhoneBookDbContext db) :
           base(db)
        {

        }

        public async Task<TeamMember> GetByNameAsync(string name)
        {
            var teamMember = await Db.TeamMembers.FirstOrDefaultAsync(x => x.FullName == name);
            if (teamMember == null)
            {
                throw new TeamMemberNotFoundException(name);
            }
            return teamMember;
        }
    }
}
