using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ShopCenter.Application.DTOs.Account;
using ShopCenter.Application.DTOs.User;
using ShopCenter.Application.Extensions;
using ShopCenter.Application.InterfaceServices;
using ShopCenter.Application.Utilities;
using ShopCenter.Domain.Models.User;

namespace ShopCenter.Application.Services
{
    public class UserService:IUserService
    {


        #region constructor
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMessageSender _messageSender;

        public UserService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager, IMessageSender messageSender)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _messageSender = messageSender;
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

        public async Task<string> GenerateEmailConfirmationTokenAsync(EmailConfirmationDTO emailConfirmationDTO)
        {
            var user = new ApplicationUser()
            {
                UserName = emailConfirmationDTO.UserName
            };
           return  await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<IdentityResult> EditProfileAsync(EditProfileDTO editProfileDTO)
        {
            var currentUser = await _userManager.GetUserAsync(editProfileDTO.User);
            currentUser.FirstName  = editProfileDTO.FirstName;
            currentUser.LastName = editProfileDTO.LastName;    
            currentUser.PhoneNumber= editProfileDTO.PhoneNumber;


            if (editProfileDTO.Gender != null)
            {
            currentUser.Gender=editProfileDTO.Gender;
            }
            else
            {
                currentUser.Gender = GenderTypes.Unknown;
            }




            if (editProfileDTO.ProfileImage != null && editProfileDTO.ProfileImage.IsImage())
            {
                var imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(editProfileDTO.ProfileImage.FileName);
                editProfileDTO.ProfileImage.AddImageToServer(imageName, SD.UserProfileOriginServer, 64, 64, SD.UserProfileThumbServer, currentUser.PathProfileImage);
                currentUser.PathProfileImage = imageName;
            }








            return await _userManager.UpdateAsync(currentUser);
        }

        public async Task<ApplicationUser> GetUserAsync(GetUserDTO getuserDTO)
        {
            return await _userManager.GetUserAsync(getuserDTO.User);
        }


       


        public async Task<IdentityResult> ChangePasswordAsync(ChangepasswordDTO changepasswordDTO)
        {

            var user =await GetUserAsync(new GetUserDTO()
            {
                User = changepasswordDTO.User,
            });


            return await _userManager.ChangePasswordAsync(user, changepasswordDTO.CurrentPassword, changepasswordDTO.NewPassword);
        }

     
    }
}
