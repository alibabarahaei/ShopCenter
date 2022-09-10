using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ShopCenter.Presentation.Razor.Areas.User.Pages.Dashboard
{
    public class EditProfileModel : PageModel
    {


        [Display(Name = "نام")]
        [Required]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string FirstName { get; set; }


        [Display(Name = "نام خانوادگی")]
        [Required]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string LastName { get; set; }


        [Display(Name = "نام خانوادگی")]
        [Required]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} عدد باشد")]
        public string MobileNumber { get; set; }














        public void OnGet()
        {
        }
    }
}
