using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Contacts.Exceptions
{
    public class ContactDirectBossIdIsNotValidException : Exception
    {
        public ContactDirectBossIdIsNotValidException(int bossId)
            : base($"DirectBossId  {bossId} is not valid.")
        {

        }
    }
}
