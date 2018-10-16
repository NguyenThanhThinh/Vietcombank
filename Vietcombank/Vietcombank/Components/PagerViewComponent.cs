using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vietcombank.Extensions;

namespace Vietcombank.Components
{

    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
        {
            return Task.FromResult((IViewComponentResult)View("Default", result));
        }
    }
}
