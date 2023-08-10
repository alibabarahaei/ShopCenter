using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCenter.Application.DTOs.User;
using ShopCenter.Application.Extensions;
using ShopCenter.Application.InterfaceServices;
using System.ComponentModel.DataAnnotations;

namespace ShopCenter.Presentation.Razor.Areas.User.Pages.Dashboard
{
    public class ProfileModel : PageModel
    {

        #region properties
        [Display(Name = "نام")]
        public string FirstName { get; set; }


        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }


        [Display(Name = "شَماره موبایل")]
        public string PhoneNumber { get; set; }


        public String Gmail { get; set; }


        public string CreationDate { get; set; }
        #endregion


        #region constructor

        private readonly IUserService _userService;


        public ProfileModel(IUserService userService)
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
            Gmail = user.Email;
            CreationDate = user.CreationDate.ToShamsi();
        }
    }
}
