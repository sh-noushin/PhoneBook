using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.TeamMembers.Exceptions
{
    public class TeamMemberAlreadyExistsException : Exception
    {
        public TeamMemberAlreadyExistsException(string name, int id)
            : base($"Team with id {id} already has TeamMember with name {name} .")
        {

        }
        public TeamMemberAlreadyExistsException(string name)
            : base($"TeamMember with name {name} already exists .")
        {

        }
    }
}
