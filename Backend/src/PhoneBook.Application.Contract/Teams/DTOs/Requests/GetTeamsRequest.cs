using PhoneBook.Application.Contract.Core.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Contract.Teams.DTOs.Requests
{
    public class GetTeamsRequest : PagedAndSorted
    {
        public string FilterText { get; set; } = "";
    }
}
