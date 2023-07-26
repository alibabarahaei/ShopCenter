using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCenter.Application.DTOs.Products;
using ShopCenter.Application.InterfaceServices;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ShopCenter.Presentation.Razor.Areas.Seller.Pages.Panel.Product
{
    public class EditProductModel : PageModel
    {





        #region property
        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "قیمت محصول")]
        public long Price { get; set; }

        [Display(Name = "توضیحات کوتاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string ShortDescription { get; set; }

        [Display(Name = "توضیحات اصلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Description { get; set; }

        [Display(Name = "فعال / غیرفعال")]
        public bool IsActive { get; set; }


        public long Id { get; set; }

        public string ImageName { get; set; }

        public List<CreateProductColorDTO> ProductColors { get; set; }


        public List<long> SelectedCategories { get; set; }

        public CreateProductDTO Product { get; set; }
#endregion














        #region constructor

        private readonly IProductService _productService;
        private readonly IStoreService _storeService;

        public EditProductModel(IProductService productService, IStoreService storeService)
        {
            _productService = productService;
            _storeService = storeService;
        }

        #endregion









        public async Task<PageResult> OnGet(long productId)
        {
            var product = await _productService.GetProductForEdit(productId);
            Title=product.Title;
            Price = product.Price;
            ShortDescription=product.ShortDescription;
            Description = product.Description;
            IsActive = product.IsActive;
            Id=product.Id;
            ImageName = product.ImageName;
            ProductColors = product.ProductColors;
            SelectedCategories = product.SelectedCategories;
            //if (product == null) return NotFound();
            ViewData["Categories"] = await _productService.GetAllActiveProductCategories();
            return Page();
        }
    }
}
