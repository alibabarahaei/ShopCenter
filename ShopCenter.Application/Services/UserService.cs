using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ShopCenter.Application.InterfaceServices;

namespace ShopCenter.Application.Services
{
    public class UserService:IUserService
    {


        #region constructor
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        #endregion




        #region dispose


        public async ValueTask DisposeAsync()
        {
          //  await _userManager.DisposeAsync()
        }

        #endregion


        public IdentityResult RegisterUser()
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityUser> IsUserNameInUse(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<IdentityUser> IsEmailInUse(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
    }
}
