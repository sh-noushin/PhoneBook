using PhoneBook.Domain.Core;
using PhoneBook.Domain.Teams.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Teams
{
    public class Team : BaseEntity<int>
    {
        public string Name { get;  set; }
        public Team()
        {

        }
        

        public Team(string name)
        {
            SetName(name);
        }

        public void SetName(string name)
        {
            
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new TeamNameIsNullOrWhiteSpaceException();
            }

            Name = name;
        }
    }
}

