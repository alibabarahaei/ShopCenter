using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCenter.Application.InterfaceServices;

namespace ShopCenter.Presentation.Razor.Areas.Seller.Pages.Panel.Product
{
    public class GetProductGalleriesModel : PageModel
    {

        #region constructor

        private readonly IProductService _productService;

        public GetProductGalleriesModel(IProductService productService)
        {
            _productService = productService;
        }

        #endregion





        public async  Task OnGet()
        {
            //await _productService.GetAllProductGalleriesInSellerPanel(id)
        }
    }
}
