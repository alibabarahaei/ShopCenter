using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ShopCenter.Domain.Models.Base;

namespace ShopCenter.Domain.Models.Site
{
    public class Slider:BaseEntity
    {

        #region properties

        [Display(Name = "نام تصویر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string ImageName { get; set; }

        [Display(Name = "لینک")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Link { get; set; }

        [Display(Name = "فعال / غیرفعال")]
        public bool IsActive { get; set; }

        #endregion


    }
}
