using System.Security.Claims;

namespace ShopCenter.Application.DTOs.User
{
    public class GetUserDTO
    {
        public ClaimsPrincipal User { get; set; }
    }
}
