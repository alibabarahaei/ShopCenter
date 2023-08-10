using Microsoft.AspNetCore.Mvc;
using ShopCenter.Application.InterfaceServices;

namespace ShopCenter.Presentation.Razor.ViewComponents.SiteViewComponents
{
    public class SiteHeaderViewComponent : ViewComponent
    {



        private readonly IProductService _productService;

        public SiteHeaderViewComponent(IProductService productService)
        {
            _productService = productService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {



            ViewData["ProductCategories"] = await _productService.GetAllActiveProductCategories();

            return View("SiteHeader");
        }

    }
}
