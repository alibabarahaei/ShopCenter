using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShopCenter.Presentation.Razor.Pages.Account
{
    public class ConfirmEmailModel : PageModel
    {



        public async Task<IActionResult> OnGetAsync(string userName, string token)
        {
            //if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(token))
            //    return NotFound();
            //var user = await _userManager.FindByNameAsync(userName);
            //if (user == null) return NotFound();
            //var result = await _userManager.ConfirmEmailAsync(user, token);

            //return Content(result.Succeeded ? "Email Confirmed" : "Email Not Confirmed");
            return Page();
        }
    }
}
