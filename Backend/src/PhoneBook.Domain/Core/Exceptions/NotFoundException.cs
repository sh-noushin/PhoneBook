using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Core.Exceptions
{
    public class NotFoundException: Exception
    {
        public NotFoundException():base("Entity not found"){
        }
    }
}
