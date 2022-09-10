using Microsoft.AspNetCore.Mvc;
using ShopCenter.Application.InterfaceServices;
using ShopCenter.Domain.Models.Site;
using ShopCenter.Infrastructure.EFCore.Migrations;

namespace ShopCenter.Presentation.Razor.ViewComponents.SiteViewComponents
{
    public class HomeAdBanner1ViewComponent : ViewComponent
    {

        #region constructor

        private readonly ISiteService _siteService;

        public HomeAdBanner1ViewComponent(ISiteService siteService)
        {
            _siteService = siteService;
        }

        

        #endregion


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var banners = await _siteService.GetSiteBannersByPlacement(new List<BannerPlacement>()
            {
                BannerPlacement.Home_1
            });
            return View("HomeAdBanner1", banners);
        }
    }
}
