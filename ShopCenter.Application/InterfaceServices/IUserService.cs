using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ShopCenter.Application.InterfaceServices
{
    public interface IUserService : IAsyncDisposable
    {

        public IdentityResult RegisterUser();
        Task<IdentityUser> IsUserNameInUse(string userName);
        Task<IdentityUser> IsEmailInUse(string email);
    }
}
