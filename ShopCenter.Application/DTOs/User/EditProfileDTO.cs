using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ShopCenter.Application.DTOs.User
{
    public class EditProfileDTO
    {


        public ClaimsPrincipal User { get; set; }


        public string FirstName { get; set; }



        public string LastName { get; set; }


        public string PhoneNumber { get; set; }



        public IFormFile? ProfileImage { get; set; }


        public char? Gender { get; set; }
    }
}
