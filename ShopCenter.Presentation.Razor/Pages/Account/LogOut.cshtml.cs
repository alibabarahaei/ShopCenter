using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCenter.Application.InterfaceServices;

namespace ShopCenter.Presentation.Razor.Pages.Account
{
    [Authorize]
    public class LogOutModel : PageModel
    {
        #region constuctor
        private readonly IUserService _userService;

        public LogOutModel(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        public IActionResult OnGet()
        {

            _userService.LogOutUserAsync();
            return RedirectToPage("../Index");


        }
    }
}
