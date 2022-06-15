using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.TeamMembers.Exceptions
{
    internal class TeamMemberNameIsNullOrWhiteSpaceException : Exception
    {
        public TeamMemberNameIsNullOrWhiteSpaceException()
            : base("TeamMember name could not be empty or whitespace.")
        {

        }
    }
}
