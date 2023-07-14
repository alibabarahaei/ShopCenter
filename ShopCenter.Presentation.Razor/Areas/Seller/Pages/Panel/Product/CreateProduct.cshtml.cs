using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCenter.Application.DTOs.Products;
using ShopCenter.Application.InterfaceServices;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ShopCenter.Presentation.Razor.Areas.Seller.Pages.Panel.Product
{
    public class CreateProductModel : PageModel
    {

        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "قیمت محصول")]
        public int Price { get; set; }

        [Display(Name = "توضیحات کوتاه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string ShortDescription { get; set; }

        [Display(Name = "توضیحات اصلی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Description { get; set; }

        [Display(Name = "فعال / غیرفعال")]
        public bool IsActive { get; set; }

        //public List<CreateProductColorDTO> ProductColors { get; set; }

        public List<long> SelectedCategories { get; set; }

        public CreateProductDTO Product { get; set; }






        #region constructor

        private readonly IProductService _productService;
        private readonly IStoreService _storeService;

        public CreateProductModel(IProductService productService, IStoreService storeService)
        {
            _productService = productService;
            _storeService = storeService;
        }

        #endregion

        public async Task<IActionResult> OnGet()
        {
            ViewData["MainCategories"] = await _productService.GetAllProductCategoriesByParentId(null);

            return Page();
            
        }

        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreateProduct(CreateProductDTO product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // todo: create product
        //    }

        //    ViewBag.MainCategories = await _productService.GetAllProductCategoriesByParentId(null);
        //    return View(product);
        //}


    }
}
