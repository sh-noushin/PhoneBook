using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.TeamMembers.Exceptions
{
    public class TeamMemberNotFoundException : Exception
    {
        public TeamMemberNotFoundException(string name)
            : base($"TeamMember with name {name} not found.")
        {

        }
        public TeamMemberNotFoundException(int id)
            : base($"TeamMember with id {id} not found.")
        {

        }
    }
}

