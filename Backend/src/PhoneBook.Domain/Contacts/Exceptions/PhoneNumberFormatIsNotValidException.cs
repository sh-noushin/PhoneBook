using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Contacts.Exceptions
{
    public class PhoneNumberFormatIsNotValidException : Exception
    {
        public PhoneNumberFormatIsNotValidException()
            : base("\nPhone Number must be like these formats:\n\n" +
                  "+CounryCode AreaCode(2-5 digits) PhoneNumber(3-15 digits) \n\n" +
                  "+49 711 12345-1235 is a valid phone number\n" +
                  "+1(555) 765 1234 is a valid phone number\n" +
                  "*1[555] 765 1234 is NOT a valid phone number\n" +
                  "+1(711) 123 abc is NOT a valid phone number")
    
        {

        }
    }
}
