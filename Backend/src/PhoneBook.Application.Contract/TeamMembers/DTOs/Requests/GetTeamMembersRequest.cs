using PhoneBook.Application.Contract.Core.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Contract.TeamMembers.DTOs.Requests
{
    public class GetTeamMembersRequest : PagedAndSorted
    {
        public string FilterText { get; set; } = "";
    }
}
