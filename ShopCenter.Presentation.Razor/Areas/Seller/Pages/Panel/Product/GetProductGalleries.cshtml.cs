using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCenter.Application.DTOs.User;
using ShopCenter.Application.InterfaceServices;

namespace ShopCenter.Presentation.Razor.Areas.Seller.Pages.Panel.Product
{
    public class GetProductGalleriesModel : PageModel
    {

        #region constructor

        private readonly IProductService _productService;
        private readonly IUserService _userService;

        public GetProductGalleriesModel(IProductService productService, IUserService userService)
        {
            _productService = productService;
            _userService = userService;
        }

        #endregion





        public async  Task<IActionResult> OnGet(long id)
        {

            var user = await _userService.GetUserAsync(new GetUserDTO()
            {
                User = User
            });


            ViewData["productId"] = id;

            ViewData["ProductGalleries"] = await _productService.GetAllProductGalleriesInSellerPanel(id, user.Id);
            return Page();
      
        }
    }
}
