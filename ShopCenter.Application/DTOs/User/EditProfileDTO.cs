using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShopCenter.Application.DTOs.User
{
    public class EditProfileDTO
    {

  
        public ClaimsPrincipal User { get; set; }


        public string FirstName { get; set; }


       
        public string LastName { get; set; }

        
        public string PhoneNumber { get; set; }
    }
}
