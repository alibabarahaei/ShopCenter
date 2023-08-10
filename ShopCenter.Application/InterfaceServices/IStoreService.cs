using ShopCenter.Application.DTOs.Common;
using ShopCenter.Application.DTOs.Store;
using ShopCenter.Domain.Models.Store;
using System.Security.Claims;

namespace ShopCenter.Application.InterfaceServices
{
    public interface IStoreService : IAsyncDisposable
    {
        #region seller

        Task<RequestSellerResult> AddNewSellerRequestAsync(RequestSellerDTO seller, ClaimsPrincipal userCP);
        Task<FilterSellerDTO> FilterSellersAsync(FilterSellerDTO filter);
        Task<bool> AcceptSellerRequestAsync(long requestId);
        Task<bool> RejectSellerRequestAsync(RejectItemDTO reject);
        Task<Seller> GetLastActiveSellerByUserId(ClaimsPrincipal userCP);
        #endregion
    }
}
