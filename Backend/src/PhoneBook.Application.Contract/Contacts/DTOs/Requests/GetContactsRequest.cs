using PhoneBook.Application.Contract.Core.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Contract.Contacts.DTOs.Requests
{
    public class GetContactsRequest : PagedAndSorted
    {
        public string FilterText { get; set; } = "";
    }
}
