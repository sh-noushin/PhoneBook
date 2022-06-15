using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Contract.TeamMembers.DTOs.Requests
{
    public class TeamMemberUpdateRequest
    {
        public string FullName { get; set; }
        public int TeamId { get; set; }
    }
}
