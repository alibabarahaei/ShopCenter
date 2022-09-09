using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShopCenter.Presentation.Razor.Pages.Account
{
    public class ForgotPasswordModel : PageModel
    {
        public void OnGet()
        {
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            return RedirectToPage("login");
        }
    }
}
