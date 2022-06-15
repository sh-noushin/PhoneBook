using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Teams.Exceptions
{
    public class TeamAlreadyExistsException : Exception
    {
        public TeamAlreadyExistsException(string name)
            : base($"Team with name {name} already exists")
        {

        }
    }
}
