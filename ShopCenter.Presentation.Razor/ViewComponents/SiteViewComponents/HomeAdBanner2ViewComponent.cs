using Microsoft.AspNetCore.Mvc;
using ShopCenter.Application.InterfaceServices;
using ShopCenter.Domain.Models.Site;

namespace ShopCenter.Presentation.Razor.ViewComponents.SiteViewComponents
{
    public class HomeAdBanner2ViewComponent : ViewComponent
    {

        #region constructor

        private readonly ISiteService _siteService;

        public HomeAdBanner2ViewComponent(ISiteService siteService)
        {
            _siteService = siteService;
        }



        #endregion


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var banners = await _siteService.GetSiteBannersByPlacement(new List<BannerPlacement>()
            {
                BannerPlacement.Home_2
            });
            return View("HomeAdBanner2", banners);
        }
    }
}
