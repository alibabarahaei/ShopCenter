using GoogleReCaptcha.V3.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCenter.Application.DTOs.Account;
using ShopCenter.Application.InterfaceServices;
using System.ComponentModel.DataAnnotations;

namespace ShopCenter.Presentation.Razor.Pages.Account
{
    [BindProperties]
    public class LoginModel : PageModel
    {

        #region Properties

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [StringLength(40, ErrorMessage = "طول {0} باید بین {2} و {1} باشد", MinimumLength = 6)]
        public string UserName { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [StringLength(30, ErrorMessage = "طول {0} باید بین {2} و {1} باشد", MinimumLength = 8)]
        public string Password { get; set; }

        [Display(Name = "یادآوری کلمه عبور")]
        public bool RememberMe { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Captcha { get; set; }
        #endregion


        #region constuctor
        
        private readonly IUserService _userService;
        private readonly ICaptchaValidator _captchaValidator;

        public LoginModel(IUserService userService, ICaptchaValidator captchaValidator)
        {

            _userService = userService;
            _captchaValidator = captchaValidator;
        }
       
        #endregion






        public void OnGet()
        {

        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPost()
        {

            if (!await _captchaValidator.IsCaptchaPassedAsync(Captcha))
            {
                TempData["ErrorMessage"] = "کد کپچای شما تایید نشد";
                return Page();
            }






            if (ModelState.IsValid)
            {
                var result = await _userService.LoginUserAsync(new LoginUserDTO()
                {
                    UserName = UserName,
                    Password = Password,
                    RememberMe = RememberMe
                });

                if (!result.Succeeded)
                {
                    if (result.IsLockedOut)
                    {
                        TempData["WarningMessage"] = "اکانت شما تا اطلاع ثانوی قفل شده است";
                        //ModelState.AddModelError("UserName", "اکانت شما تا اطلاع ثانوی قفل شده است");

                    }
                    else
                    {
                        TempData["WarningMessage"] = "نام کاربری یا رمز عبور اشتباه هست";
                        UserName = "";
                        RememberMe = false;
                        //ModelState.AddModelError("UserName", "نام کاربری یا رمز عبور اشتباه هست");

                    }
                    return Page();
                }
                TempData["SuccessMessage"] = "با موفقیت ثبت نام شدید";
                return RedirectToPage("../Index");


            }
            return Page();

        }
    }
}
