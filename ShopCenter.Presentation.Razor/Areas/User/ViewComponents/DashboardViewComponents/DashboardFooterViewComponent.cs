using Microsoft.AspNetCore.Mvc;

namespace ShopCenter.Presentation.Razor.Areas.User.ViewComponents.DashboardViewComponents
{
    public class DashboardFooterViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("DashboardFooter");
        }
    }
}
