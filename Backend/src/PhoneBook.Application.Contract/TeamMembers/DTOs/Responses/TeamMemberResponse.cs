using PhoneBook.Application.Contract.Teams.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Contract.TeamMembers.DTOs.Responses
{
    public class TeamMemberResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; }
       public TeamResponse Team { get; set; }
    }
}
