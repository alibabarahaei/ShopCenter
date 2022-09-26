using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShopCenter.Application.DTOs.Store
{
    public class RequestSellerDTO
    {
     
        public string StoreName { get; set; }


        public string Phone { get; set; }

        public string Address { get; set; }
    }

    public enum RequestSellerResult
    {
        Success,
        HasUnderProgressRequest,
        HasNotPermission
    }
}
