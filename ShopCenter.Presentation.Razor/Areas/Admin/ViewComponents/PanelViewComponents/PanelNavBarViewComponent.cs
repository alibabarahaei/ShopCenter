

using Microsoft.AspNetCore.Mvc;

namespace ShopCenter.Presentation.Razor.Areas.Admin.ViewComponents.PanelViewComponents
{
    public class PanelNavBarViewComponent:ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("PanelNavBar");
        }
    }
}
