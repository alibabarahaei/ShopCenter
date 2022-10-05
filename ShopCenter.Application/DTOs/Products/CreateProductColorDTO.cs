using System.ComponentModel.DataAnnotations;

namespace ShopCenter.Application.DTOs.Products
{
    public class CreateProductColorDto
    {
        [Display(Name = "رنگ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string ColorName { get; set; }

        public int Price { get; set; }
    }
}
