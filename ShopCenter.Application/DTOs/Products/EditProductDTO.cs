using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenter.Application.DTOs.Products
{
    public class EditProductDTO : CreateProductDTO
    {
        public long Id { get; set; }
        public string ImageName { get; set; }
    }
}
