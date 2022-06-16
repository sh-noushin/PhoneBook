using PhoneBook.Application.Contract.Contacts;
using PhoneBook.Domain.Contacts.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhoneBook.Application.Contacts
{
    public class PhoneValidationService : IPhoneValidationService
    {
        public  bool IsValidPhone(string phone)
        {

            var r = new Regex(@"^\+?\d{1,3}[\s]\(?\d{2,5}\)?[\s]\d{3,15}$");
            r.Match(phone);
            var match = r.IsMatch(phone);
            if (!match) throw new PhoneNumberFormatIsNotValidException();
            return (match);






        }
    }
}
