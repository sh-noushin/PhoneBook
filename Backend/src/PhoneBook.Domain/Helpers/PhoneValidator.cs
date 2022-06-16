using PhoneBook.Domain.Contacts.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Helpers
{
    public class PhoneValidator : IPhoneValidator
    {
        public void ValidatePhoneNumber(string phone)
        {

            //var r = new Regex(@"^\+\d{1,3}[\s](\d{2,5}|\(\d{2,5}\))[\s]\d{3,15}$");
            var r = new Regex(@"^\+\d{1,3}[\s](\d{2,5}|\(\d{2,5}\))[\s]((\d{3,15})|(\d{3}[\s-]?\d{12})|(\d{4}[\s-]?\d{11})|(\d{5}[\s-]?\d{10})|(\d{6}[\s-]?\d{9})|(\d{7}[\s-]?\d{8})|(\d{8}[\s-]?\d{7})|(\d{9}[\s-]?\d{6})|(\d{10}[\s-]?\d{5})|(\d{11}[\s-]?\d{4})|(\d{12}[\s-]?\d{3})|(\d{13}[\s-]?\d{2})|(\d{14}[\s-]?\d{1}))$");
            //var r2 = new Regex(@"^\+\d{1,3}[\s](\d{2,5}|\(\d{2,5}\))[\s]\d{3}[\s-]?\d{12}$");
            var r3 = new Regex(@"^(\+\d{1,3}[\s]\(\d{2,5}\)[\s]((\d{3,15})|(\d{3}[\s-]?\d{12})|(\d{4}[\s-]?\d{11})|(\d{5}[\s-]?\d{10})|(\d{6}[\s-]?\d{9})|(\d{7}[\s-]?\d{8})|(\d{8}[\s-]?\d{7})|(\d{9}[\s-]?\d{6})|(\d{10}[\s-]?\d{5})|(\d{11}[\s-]?\d{4})|(\d{12}[\s-]?\d{3})|(\d{13}[\s-]?\d{2})|(\d{14}[\s-]?\d{1})))|(\+\d{1,3}[\s]\d{2,5}[\s]((\d{3,15})|(\d{3}[\s-]?\d{12})|(\d{4}[\s-]?\d{11})|(\d{5}[\s-]?\d{10})|(\d{6}[\s-]?\d{9})|(\d{7}[\s-]?\d{8})|(\d{8}[\s-]?\d{7})|(\d{9}[\s-]?\d{6})|(\d{10}[\s-]?\d{5})|(\d{11}[\s-]?\d{4})|(\d{12}[\s-]?\d{3})|(\d{13}[\s-]?\d{2})|(\d{14}[\s-]?\d{1})))$");
            r3.Match(phone);
            var match = r3.IsMatch(phone);
            if (!match)
            {
                throw new PhoneNumberFormatIsNotValidException();
            }
        }
    }
}
