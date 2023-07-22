using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCenter.Application.DTOs.Common;
using ShopCenter.Application.DTOs.Products;
using ShopCenter.Application.InterfaceServices;
using ShopCenter.Application.Services;
using ShopCenter.Presentation.Razor.Http;

namespace ShopCenter.Presentation.Razor.Areas.Admin.Pages.Panel.ProductManagement
{
    public class ProductRequestModel : PageModel
    {

        #region constructor


        private readonly IProductService _productService;

        public ProductRequestModel(IProductService productService)
        {
            _productService = productService;

        }

        #endregion








        public async Task<PageResult> OnGet(FilterProductDTO filter )
        {
            ViewData["filterproduct"] = await _productService.FilterProductsAsync(filter);

            return Page();
        }







        public async Task<IActionResult> OnGetAcceptProductRequest(long id)
        {
            var result = await _productService.AcceptSellerProduct(id);
            if (result)
            {
                return JsonResponseStatus.SendStatus(JsonResponseStatusType.Success,
                    "محصول مورد نظر با موفقیت تایید شد", null);
            }

            return JsonResponseStatus.SendStatus(JsonResponseStatusType.Danger, "محصول مورد نظر یافت نشد", null);
        }





        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostRejectProductRequest(RejectItemDTO reject)
        {
            if (ModelState.IsValid)
            {
                var result = await _productService.RejectSellerProduct(reject);

                if (result)
                {

                    return JsonResponseStatus.SendStatus(JsonResponseStatusType.Success,
                        "محصول مورد نظر با موفقیت رد شد", reject);
                }

                return JsonResponseStatus.SendStatus(JsonResponseStatusType.Danger,
                    "اطلاعات مورد نظر جهت عدم تایید را به درستی وارد نمایید", null);
            }


            return JsonResponseStatus.SendStatus(JsonResponseStatusType.Danger, "محصول مورد نظر یافت نشد", null);
        }
    }
}













    
