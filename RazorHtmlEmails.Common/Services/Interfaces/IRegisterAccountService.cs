using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorHtmlEmails.Common.Services.Interfaces
{
    public interface IRegisterAccountService
    {
        Task Register(string email, string baseUrl);
    }
}
