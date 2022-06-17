using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Contacts.Exceptions
{
    public class PhoneNumberIsEmptyException : Exception
    {
        public PhoneNumberIsEmptyException()
            : base("Phone Number could not be empty or whitespace.")
        {
        }
    }
}
