using Microsoft.AspNetCore.Mvc;
using Senac.Mvc.Scaffolding.Web.Models;

namespace Senac.Mvc.Scaffolding.Web.Extensions
{
    public class PaginacaoViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(IPagedList pagedModel)
        {
            // ReSharper disable once Mvc.ViewComponentViewNotResolved
            return base.View(pagedModel);
        }
    }
}
