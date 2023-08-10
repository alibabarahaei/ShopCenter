using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCenter.Application.DTOs.Common;
using ShopCenter.Application.DTOs.Store;
using ShopCenter.Application.InterfaceServices;
using ShopCenter.Presentation.Razor.Http;

namespace ShopCenter.Presentation.Razor.Areas.Admin.Pages.Panel.SellerManagement
{
    public class SellerRequestModel : PageModel
    {

        #region properties

        public FilterSellerDTO FilterSeller { get; set; }

        #endregion



        #region constructor
        private readonly IStoreService _storeService;

        public SellerRequestModel(IStoreService storeService)
        {
            _storeService = storeService;
        }

        #endregion



        public async Task OnGet(FilterSellerDTO filter)
        {
            filter.TakeEntity = 30;

            FilterSeller = await _storeService.FilterSellersAsync(filter);
        }



        public async Task<IActionResult> OnGetAcceptSellerRequest(long requestId)
        {
            var result = await _storeService.AcceptSellerRequestAsync(requestId);

            if (result)
            {
                return JsonResponseStatus.SendStatus(
                    JsonResponseStatusType.Success,
                    "درخواست مورد نظر با موفقیت تایید شد",
                    null);
            }

            return JsonResponseStatus.SendStatus(JsonResponseStatusType.Danger,
                "اطلاعاتی با این مشخصات یافت نشد", null);
        }




        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostRejectSellerRequest(RejectItemDTO reject)
        {
            if (ModelState.IsValid)
            {
                var result = await _storeService.RejectSellerRequestAsync(reject);

                if (result)
                {
                    return JsonResponseStatus.SendStatus(
                        JsonResponseStatusType.Success,
                        "درخواست مورد نظر با موفقیت رد شد شد",
                        reject);
                }

                return JsonResponseStatus.SendStatus(JsonResponseStatusType.Danger,
                    "اطلاعاتی با این مشخصات یافت نشد", null);

            }

            return Page();
            return JsonResponseStatus.SendStatus(JsonResponseStatusType.Danger,
                "اطلاعاتی با این مشخصات یافت نشد", null);
        }







    }
}
