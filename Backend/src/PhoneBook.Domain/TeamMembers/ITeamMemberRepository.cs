using PhoneBook.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.TeamMembers
{
    public interface ITeamMemberRepository : IBaseRepository<TeamMember, int>
    {
        Task<TeamMember> GetByNameAsync(string title);
    }
}
