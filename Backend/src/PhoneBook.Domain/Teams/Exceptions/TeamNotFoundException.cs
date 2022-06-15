using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Teams.Exceptions
{
    public class TeamNotFoundException : Exception
    {
        public TeamNotFoundException(string name)
            : base($"Team with name {name} not found.")
        {

        }
        public TeamNotFoundException(int  id)
            : base($"Team with id {id} not found .")
        {

        }
    }
}
