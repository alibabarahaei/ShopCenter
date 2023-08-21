using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCenter.Application.DTOs.User;
using ShopCenter.Application.InterfaceServices;
using ShopCenter.Domain.Models.Products;

namespace ShopCenter.Presentation.Razor.Areas.Seller.Pages.Panel.Product
{
    public class CreateProductGalleryModel : PageModel
    {





        private readonly IProductService _productService;
        private readonly IUserService _userService;


        public CreateProductGalleryModel(IProductService productService, IUserService userService)
        {
            _productService = productService;
            _userService = userService;
        }


        public async  Task<IActionResult> OnGet(long productId )
        {
            var user = await _userService.GetUserAsync(new GetUserDTO()
            {
                User = User
            });
            var product = await _productService.GetProductBySellerOwnerId(productId, user.Id);
            if (product == null) return NotFound();

            ViewData["product"] = product;
            return Page();
        }
    }
}
