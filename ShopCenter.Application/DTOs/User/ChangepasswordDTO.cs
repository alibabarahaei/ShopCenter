using System.Security.Claims;

namespace ShopCenter.Application.DTOs.User
{
    public class ChangepasswordDTO
    {

        public ClaimsPrincipal User { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
