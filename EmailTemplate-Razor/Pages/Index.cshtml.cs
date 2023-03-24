using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHtmlEmails.Common.Services.Interfaces;

namespace EmailTemplate_Razor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IRegisterAccountService _registerAccountService;

        public IndexModel(IRegisterAccountService registerAccountService)
        {
            _registerAccountService = registerAccountService;
        }

        public async Task OnGetAsync()
        {
            await _registerAccountService.Register("marielle.abernathy31@ethereal.email", Url.Page("./Index"));
        }
    }
}