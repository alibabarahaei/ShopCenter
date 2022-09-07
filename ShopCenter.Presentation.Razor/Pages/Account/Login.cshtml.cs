using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShopCenter.Presentation.Razor.Pages.Account
{
    public class LoginModel : PageModel
    {





        public void OnGet()
        {
            
        }

        [ValidateAntiForgeryToken]
        public void OnPost()
        {

        }
    }
}
