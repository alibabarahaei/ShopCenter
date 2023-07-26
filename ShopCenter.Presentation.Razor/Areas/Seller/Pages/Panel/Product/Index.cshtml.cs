using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCenter.Application.DTOs.Products;
using ShopCenter.Application.InterfaceServices;

namespace ShopCenter.Presentation.Razor.Areas.Seller.Pages.Panel.Product
{
    public class IndexModel : PageModel
    {



        #region properties
        public FilterProductDTO Filter { get; set; }


        #endregion





        #region constructor

        private readonly IProductService _productService;
        private readonly IStoreService _storeService;

        public IndexModel(IProductService productService, IStoreService sellerService)
        {
            _productService = productService;
            _storeService = sellerService;
        }

        #endregion

        #region list

      
        public async Task<IActionResult> OnGet(FilterProductDTO filter)
        {
            var seller = await _storeService.GetLastActiveSellerByUserId(User);
            filter.SellerId = seller.Id;
            filter.FilterProductState = FilterProductState.All;
            filter=await _productService.FilterProductsAsync(filter);
            Filter = filter;
            return Page();
        }

        #endregion
    }
}
