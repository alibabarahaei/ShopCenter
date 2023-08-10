using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCenter.Application.DTOs.Store;
using ShopCenter.Application.InterfaceServices;
using System.ComponentModel.DataAnnotations;

namespace ShopCenter.Presentation.Razor.Areas.User.Pages.Dashboard
{
    public class RequestSellerPanelModel : PageModel
    {




        #region properties

        [Display(Name = "نام فروشگاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string StoreName { get; set; }

        [Display(Name = "تلفن فروشگاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Phone { get; set; }

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Address { get; set; }

        #endregion

        #region constructor

        private readonly IStoreService _storeService;

        public RequestSellerPanelModel(IStoreService sellerService)
        {
            _storeService = sellerService;
        }

        #endregion

        #region request seller


        public void OnGet()
        {

        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPost(RequestSellerDTO seller)
        {
            if (ModelState.IsValid)
            {
                var res = await _storeService.AddNewSellerRequestAsync(seller, User);
                switch (res)
                {
                    case RequestSellerResult.HasNotPermission:
                        TempData["ErrorMessage"] = "شما دسترسی لازم جهت انجام فرایند مورد نظر را ندارید";
                        break;
                    case RequestSellerResult.HasUnderProgressRequest:
                        TempData["WarningMessage"] = "درخواست های قبلی شما در حال پیگیری می باشند";
                        TempData["InfoMessage"] = "در حال حاضر نمیتوانید درخواست جدیدی ثبت کنید";
                        break;
                    case RequestSellerResult.Success:
                        TempData["SuccessMessage"] = "درخواست شما با موفقیت ثبت شد";
                        TempData["InfoMessage"] = "فرایند تایید اطلاعات شما در حال پیگیری می باشد";
                        RedirectToPage("SellerRequests");
                        break;

                }
            }

            return Page();
        }

        #endregion

    }
}
