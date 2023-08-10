using Microsoft.AspNetCore.Mvc;

namespace ShopCenter.Presentation.Razor.Areas.User.ViewComponents.SiteViewComponents
{
    public class DashboardHeaderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("DashboardHeader");
        }

    }
}
