using PhoneBook.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Teams
{
    public interface ITeamRepository : IBaseRepository<Team, int>
    {
        Task<Team> GetByNameAsync(string name);
    }
}
