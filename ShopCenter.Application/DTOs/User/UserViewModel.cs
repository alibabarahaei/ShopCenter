﻿using ShopCenter.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShopCenter.Application.DTOs.User
{
    public class UserViewModel
    {



  
        public string? FirstName { get; set; }


  
        public string? LastName { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime CreationDate { get; set; } 

    
        public string PathProfileImage { get; set; }


        public char Gender { get; set; }

    }
}
