using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Teams.Exceptions
{
    public class TeamNameIsNullOrWhiteSpaceException : Exception
    {
        public TeamNameIsNullOrWhiteSpaceException()
            : base("Team name could not be empty or whitespace.")
        {

        }
    }
}
