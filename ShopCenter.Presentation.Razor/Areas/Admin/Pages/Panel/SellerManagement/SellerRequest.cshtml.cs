using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCenter.Application.DTOs.Store;
using ShopCenter.Application.InterfaceServices;

namespace ShopCenter.Presentation.Razor.Areas.Admin.Pages.Panel.SellerManagement
{
    public class SellerRequestModel : PageModel
    {

        #region properties

        public FilterSellerDTO FilterSeller { get; set; }

        #endregion



        #region constructor
        private readonly IStoreService _storeService;

        public SellerRequestModel(IStoreService storeService)
        {
            _storeService = storeService;
        }

        #endregion



        public async Task OnGet()
        {
            FilterSeller = new FilterSellerDTO();
            FilterSeller = await _storeService.FilterSellers(FilterSeller);
        }
    }
}
