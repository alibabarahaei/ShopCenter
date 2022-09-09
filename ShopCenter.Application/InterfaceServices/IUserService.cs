using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ShopCenter.Application.DTOs.Account;
using ShopCenter.Domain.Models;

namespace ShopCenter.Application.InterfaceServices
{
    public interface IUserService : IAsyncDisposable
    {

        Task<IdentityResult> RegisterUserAsync(RegisterUserDTO registerUserDTO);
        Task<IdentityUser> IsUserNameInUseAsync(string userName);
        Task<IdentityUser> IsEmailInUseAsync(string email);
        Task<SignInResult> LoginUserAsync(LoginUserDTO loginUserDTO) ;
        Task LogOutUserAsync();
        Task<string> GenerateEmailConfirmationTokenAsync(EmailConfirmationDTO emailConfirmationDTO);
    }
}
