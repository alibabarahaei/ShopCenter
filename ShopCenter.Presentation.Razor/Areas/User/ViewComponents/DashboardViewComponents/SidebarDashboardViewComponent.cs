using Microsoft.AspNetCore.Mvc;
using ShopCenter.Application.DTOs.User;
using ShopCenter.Application.InterfaceServices;
using System.Security.Claims;


namespace ShopCenter.Presentation.Razor.Areas.User.ViewComponents.DashboardViewComponents
{
    public class SidebarDashboardViewComponent : ViewComponent
    {
        private readonly IUserService _userService;
        public ClaimsPrincipal UserClaimsPrincipal { get; }
        public SidebarDashboardViewComponent(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var user = await _userService.GetUserAsync(new GetUserDTO()
            {
                User = this.HttpContext.User
            });

            var userviewmodel = new UserViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                PathProfileImage = user.PathProfileImage,
                CreationDate = user.CreationDate
            };


            return View("SidebarDashboard", userviewmodel);
        }
    }
}
