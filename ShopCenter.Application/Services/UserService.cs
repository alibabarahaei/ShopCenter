using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ShopCenter.Application.DTOs.Account;
using ShopCenter.Application.InterfaceServices;
using ShopCenter.Domain.Models;

namespace ShopCenter.Application.Services
{
    public class UserService:IUserService
    {


        #region constructor
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
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


        public async Task<IdentityResult> RegisterUserAsync(RegisterUserDTO registerUserDTO)
        {
            var user = new ApplicationUser()
            {
                UserName = registerUserDTO.UserName,
                Email = registerUserDTO.Email,
            };

            return await _userManager.CreateAsync(user, registerUserDTO.Password);


        }

        public async Task<IdentityUser> IsUserNameInUseAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<IdentityUser> IsEmailInUseAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<SignInResult> LoginUserAsync(LoginUserDTO loginUserDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(loginUserDTO.UserName, loginUserDTO.Password, loginUserDTO.RememberMe, true);
            return result;
        }

        public async Task LogOutUserAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
