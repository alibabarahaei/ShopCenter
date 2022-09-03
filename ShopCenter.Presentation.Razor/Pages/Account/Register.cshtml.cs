using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCenter.Application.InterfaceServices;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ShopCenter.Presentation.Razor.Pages.Account
{
    public class RegisterModel : PageModel
    {



        #region Properties
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
        }

        public async Task<IActionResult> OnPostAsync()
        {

        }





        [ValidateAntiForgeryToken]
        public async Task<JsonResult> OnGetIsEmailInUse(string email)
        {
            var user = await _userService.IsEmailInUse(email);
            if (user == null) return new JsonResult(true);
            return new JsonResult("ایمیل وارد شده از قبل موجود است");
        }


    }
}
