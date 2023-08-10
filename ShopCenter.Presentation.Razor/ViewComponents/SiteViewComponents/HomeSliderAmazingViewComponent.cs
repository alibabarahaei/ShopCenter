using Microsoft.AspNetCore.Mvc;

namespace ShopCenter.Presentation.Razor.ViewComponents.SiteViewComponents
{
    public class HomeSliderAmazingViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("");
        }
    }
}
