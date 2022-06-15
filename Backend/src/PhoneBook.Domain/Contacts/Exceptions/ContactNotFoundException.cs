using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Contacts.Exceptions
{
    public class ContactNotFoundException : Exception
    {
        public ContactNotFoundException(string name, string lname)
            : base($"Contact with name {name}  {lname} not found.")
        {

        }
        public ContactNotFoundException(int id)
            : base($"Contact with id {id} not found .")
        {

        }
    }
}
