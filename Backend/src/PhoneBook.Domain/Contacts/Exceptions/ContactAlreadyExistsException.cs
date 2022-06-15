using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Contacts.Exceptions
{
    public class ContactAlreadyExistsException : Exception
    {
        public ContactAlreadyExistsException(string name, string lname)
            : base($"Contact with name {name}  {lname} already exists")
        {

        }
    }
}
