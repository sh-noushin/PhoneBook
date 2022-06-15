using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.TeamMembers.Exceptions
{
    internal class TeamMemberCannotBeMovedToAnotherTeamException : Exception
    {
        public TeamMemberCannotBeMovedToAnotherTeamException(int id, string name)
            : base($"Team  with id {id} already has TeamMember with name {name} .")
        {

        }
    }
}
