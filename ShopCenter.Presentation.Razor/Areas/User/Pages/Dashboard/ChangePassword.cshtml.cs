using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCenter.Application.InterfaceServices;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using ShopCenter.Application.DTOs.User;

namespace ShopCenter.Presentation.Razor.Areas.User.Pages.Dashboard
{


    [BindProperties]
    public class ChangePassword : PageModel
    {



        #region properties

        [Display(Name = "کلمه ی عبور فعلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string CurrentPassword { get; set; }

        [Display(Name = "کلمه ی عبور جدید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string NewPassword { get; set; }

        [Display(Name = "تکرار کلمه ی عبور جدید")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Compare("NewPassword", ErrorMessage = " رمز عبور شما با هم تطابق ندارد")]
        public string ConfirmNewPassword { get; set; }

        #endregion


        #region constructor

        private readonly IUserService _userService;


        public ChangePassword(IUserService userService)
        {

            _userService = userService;

        }
        

        #endregion





        public void OnGet()
        {
        }
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result =await _userService.ChangePasswordAsync(new ChangepasswordDTO()
            {
                User = User,
                CurrentPassword = CurrentPassword,
                NewPassword = NewPassword,
                ConfirmNewPassword = ConfirmNewPassword
            });

            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "رمز عبور شما با موفقیت تغییر کرد";
            }
            else
            {
                ConfirmNewPassword = null;
                NewPassword = null;
                CurrentPassword = null;
                foreach (var error in result.Errors)
                {
                    TempData["ErrorMessage"] = error.Description;
                }
            }


            return RedirectToPage("Profile");



        }


    }
}
