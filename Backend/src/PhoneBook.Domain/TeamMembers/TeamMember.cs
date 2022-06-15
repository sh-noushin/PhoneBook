using PhoneBook.Domain.Core;
using PhoneBook.Domain.TeamMembers.Exceptions;
using PhoneBook.Domain.Teams;
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.TeamMembers
{
    public class TeamMember : BaseEntity<int>
    {
        public string FullName { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }


        public TeamMember()
        {

        }
        public TeamMember(int teamId, string name)
        {
            SetName(name);
            SetTeam(teamId);

        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new TeamMemberNameIsNullOrWhiteSpaceException();
            }
            FullName = name;
        }

        public void SetTeam(int teamId)
        {
            TeamId = teamId;
        }
    }
}
