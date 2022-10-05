using System.ComponentModel.DataAnnotations;
using ShopCenter.Domain.Models.Base;

namespace ShopCenter.Domain.Models.Products
{
    public class ProductColor : BaseEntity
    {
        #region properties

        public long ProductId { get; set; }

        [Display(Name = "رنگ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string ColorName { get; set; }

        public long Price { get; set; }

        #endregion

        #region relations

        public Product Product { get; set; }

        #endregion
    }
}
