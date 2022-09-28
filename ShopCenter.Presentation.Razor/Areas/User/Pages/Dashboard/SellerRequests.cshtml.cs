using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCenter.Application.DTOs.Store;
using ShopCenter.Application.InterfaceServices;

namespace ShopCenter.Presentation.Razor.Areas.User.Pages.Dashboard
{
    public class SellerRequestsModel : PageModel
    {



        #region properties
        public FilterSellerDTO filterSeller { get; set; }


        #endregion

        #region constructor

        private readonly IStoreService _storeService;

        public SellerRequestsModel(IStoreService storeService)
        {
            _storeService = storeService;
        }

        #endregion


        public async Task OnGet(FilterSellerDTO filter)
        {
            filter.TakeEntity = 5;
            filter.User = User;
            filter.State = FilterSellerState.All;
            filterSeller = await _storeService.FilterSellersAsync(filter);


        }
    }
}
