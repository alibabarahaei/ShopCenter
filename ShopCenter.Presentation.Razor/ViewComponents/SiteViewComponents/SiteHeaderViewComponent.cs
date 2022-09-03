using Microsoft.AspNetCore.Mvc;

namespace ShopCenter.Presentation.Razor.ViewComponents.SiteViewComponents
{
    public class SiteHeaderViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("SiteHeader");
        }

    }
}
