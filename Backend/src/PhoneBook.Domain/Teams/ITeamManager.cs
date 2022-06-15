using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Teams
{
    public interface ITeamManager
    {
        Task<Team> CreateAsync(string name);
        Task<Team> UpdateAsync(Team input, string name);
    }
}
