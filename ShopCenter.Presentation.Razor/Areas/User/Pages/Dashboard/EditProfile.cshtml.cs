using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCenter.Application.DTOs.User;
using ShopCenter.Application.InterfaceServices;
using System.ComponentModel.DataAnnotations;

namespace ShopCenter.Presentation.Razor.Areas.User.Pages.Dashboard
{




    [BindProperties]
    public class EditProfileModel : PageModel
    {


        #region properties

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string FirstName { get; set; }


        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string LastName { get; set; }


        [Display(Name = "شَماره موبایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} عدد باشد")]
        [DataType("Number")]
        public string PhoneNumber { get; set; }



        #endregion

        #region constructor

        private readonly IUserService _userService;


        public EditProfileModel(IUserService userService)
        {

            _userService = userService;

        }


        #endregion



        public async Task OnGet()
        {


            var user = await _userService.GetUserAsync(new GetUserDTO()
            {
                User = User
            });
            FirstName = user.FirstName;
            LastName = user.LastName;
            PhoneNumber = user.PhoneNumber;


        }



        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPost()
        {



            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    var newUser = new EditProfileDTO()
                    {
                        FirstName = FirstName,
                        LastName = LastName,
                        PhoneNumber = PhoneNumber,
                        User = User
                    };
                    var result = await _userService.EditProfileAsync(newUser);

                    if (result.Succeeded)
                    {
                        TempData["SuccessMessage"] = "اطلاعات شما با موفقیت تغییر کرد";
                        return RedirectToPage("Profile");
                    }
                    else
                    {
                        TempData["WarningMessage"] = "خطا";
                        FirstName = null;
                        LastName = null;
                        PhoneNumber = null;
                        return Page();
                    }

                }

                TempData["WarningMessage"] = "در سایت ورود کنید";
                return Page();
            }

            return Page();


        }
    }
}