using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain.Teams;
using PhoneBook.Domain.Teams.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.EntityFrameworkCore.Teams
{
    public class TeamRepository:BaseRepository<PhoneBookDbContext, Team,int>, ITeamRepository
    {
        public TeamRepository(PhoneBookDbContext db) :
           base(db)
        {

        }

        public async Task<Team> GetByNameAsync(string name)
        {
            var team = await Db.Teams.FirstOrDefaultAsync(x => x.Name == name);
            if (team == null)
            {
                throw new TeamNotFoundException(name);
            }
            return team;
        }
    }
}
