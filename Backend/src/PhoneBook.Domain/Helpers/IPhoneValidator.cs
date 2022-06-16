using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Helpers
{
    public interface IPhoneValidator
    {
        void ValidatePhoneNumber(string phone);
    }
}
