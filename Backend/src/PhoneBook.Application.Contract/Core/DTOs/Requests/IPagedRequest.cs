using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Contract.Core.DTOs.Requests
{
    public interface IPagedRequest
    {
        int SkipCount { get; set; }
        int MaxResultCount { get; set; }
    }
}
