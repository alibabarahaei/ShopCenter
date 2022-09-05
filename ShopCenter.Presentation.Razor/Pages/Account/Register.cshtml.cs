﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCenter.Application.DTOs.Account;
using ShopCenter.Application.InterfaceServices;
using System.ComponentModel.DataAnnotations;

namespace ShopCenter.Presentation.Razor.Pages.Account
{
    [BindProperties]
    public class RegisterModel : PageModel
    {



        #region Properties
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [StringLength(30, ErrorMessage = "طول {0} باید بین {2} و {1} باشد", MinimumLength = 6)]
        [PageRemote(PageHandler = "IsUserNameInUse", HttpMethod = "Get")]
        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده صحیح نیست")]
        [PageRemote(PageHandler = "IsEmailInUse", HttpMethod = "Get")]
        [StringLength(40, ErrorMessage = "طول {0} باید  حداکثر  {1} کاراکتر باشد")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [MinLength(8, ErrorMessage = "{0} باید بیشتر از 7 کاراکتر باشد")]
        [StringLength(30, ErrorMessage = "طول {0} باید بین {2} و {1} باشد", MinimumLength = 8)]
        //[Compare()]
        public string Password { get; set; }
        #endregion



        #region constuctor
        private readonly IUserService _userService;

        public RegisterModel(IUserService userService)
        {
            _userService = userService;
        }
        #endregion














        public void OnGet()
        {
            TempData["ErrorMessage"] = "dffgfghhghjhjh";
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUserAsync(new RegisterUserDTO()
                {
                    UserName = UserName,
                    Email = Email,
                    Password = Password
                });
                if (!result.Succeeded)
                {
                    var error_username = false;
                    var error_password = false;
                    var error_email = false;
                    foreach (var error in result.Errors)
                    {

                        if (error.Code.Contains("Password") && error_password != true)
                        {
                            TempData["ErrorMessage"] = error.Description;
                            error_password = true;
                            ModelState.AddModelError("Password", error.Description);
                        }
                        else if (error.Code.Contains("UserName") && error_username != true)
                        {
                            error_username = true;
                            ModelState.AddModelError("UserName", error.Description);
                        }
                        else if (error.Code.Contains("Email") && error_email != true)
                        {
                            ModelState.AddModelError("Email", error.Description);
                            error_email = true;
                        }
                        else
                        {
                            ModelState.AddModelError("UserName", error.Description);
                            error_username = true;
                        }
                        return Page();

                    }



                    return Page();
                }
                return RedirectToPage("Login");
            }
            else
            {
                return Page();

            }
        }





        [ValidateAntiForgeryToken]
        public async Task<JsonResult> OnGetIsEmailInUse(string email)
        {
            var user = await _userService.IsEmailInUse(email);
            if (user == null) return new JsonResult(true);
            return new JsonResult("ایمیل وارد شده از قبل موجود است");
        }

        [ValidateAntiForgeryToken]
        public async Task<JsonResult> OnGetIsUserNameInUse(string userName)
        {
            var user = await _userService.IsUserNameInUse(userName);
            if (user == null)
                return new JsonResult(true);
            return new JsonResult("نام کاربری وارد شده توسط شخص دیگری انتخاب شده است");
        }

    }
}
