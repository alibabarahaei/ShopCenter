

using Microsoft.AspNetCore.Mvc;

namespace ShopCenter.Presentation.Razor.Areas.Seller.ViewComponents.SellerPanelNavBarViewComponents
{
    public class SellerPanelNavBarViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("SellerPanelNavBar");
        }
    }
}
