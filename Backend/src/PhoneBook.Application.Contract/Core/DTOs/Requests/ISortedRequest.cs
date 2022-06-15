using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Contract.Core.DTOs.Requests
{
    public interface ISortedRequest
    {
        string Sorting { get; set; }
    }
}
