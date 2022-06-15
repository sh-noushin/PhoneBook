using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.TeamMembers
{
    public interface  ITeamMemberManager
    {
        Task<TeamMember> CreateAsync(int  teamId, string name);
        Task<TeamMember> UpdateAsync(TeamMember input, string name);
        Task<TeamMember> ChangeTeamAsync(int newTeamId, TeamMember input);
    }
}
