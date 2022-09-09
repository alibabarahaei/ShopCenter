using Microsoft.AspNetCore.Mvc;
using ShopCenter.Application.InterfaceServices;

namespace ShopCenter.Presentation.Razor.ViewComponents.SiteViewComponents
{
    public class HomeMainSliderViewComponent:ViewComponent
    {

        #region constructor

        private readonly ISiteService _siteService;

        public HomeMainSliderViewComponent(ISiteService siteService)
        {
            _siteService = siteService;
        }

        

        #endregion


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sliders = await _siteService.GetAllActiveSliders();
            return View("HomeMainSlider", sliders);
        }
    }
}
