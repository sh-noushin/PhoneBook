using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Contacts.Exceptions
{
    public class ContactNameIsNullOrWhiteSpaceException : Exception
    {
        public ContactNameIsNullOrWhiteSpaceException()
            : base("Contact name or lname could not be empty or whitespace.")
        {

        }
    }
}
