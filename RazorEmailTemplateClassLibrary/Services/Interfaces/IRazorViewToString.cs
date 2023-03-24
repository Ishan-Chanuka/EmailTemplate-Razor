using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorEmailTemplateClassLibrary.Services.Interfaces
{
    public interface IRazorViewToString
    {
        Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);
    }
}
