using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCenter.Application.DTOs.Products;
using ShopCenter.Application.InterfaceServices;

namespace ShopCenter.Presentation.Razor.Areas.Seller.Pages.Panel.Product
{
    public class CreateProductModel : PageModel
    {



        public CreateProductDTO Product { get; set; }






        #region constructor

        private readonly IProductService _productService;
        private readonly IStoreService _storeService;

        public CreateProductModel(IProductService productService, IStoreService storeService)
        {
            _productService = productService;
            _storeService = storeService;
        }

        #endregion

        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.MainCategories = await _productService.GetAllProductCategoriesByParentId(null);

            return View();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(CreateProductDTO product)
        {
            if (ModelState.IsValid)
            {
                // todo: create product
            }

            ViewBag.MainCategories = await _productService.GetAllProductCategoriesByParentId(null);
            return View(product);
        }

   
    }
}
