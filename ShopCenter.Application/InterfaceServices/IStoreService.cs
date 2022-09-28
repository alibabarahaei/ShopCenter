using ShopCenter.Application.DTOs.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ShopCenter.Application.DTOs.Common;

namespace ShopCenter.Application.InterfaceServices
{
    public interface IStoreService:IAsyncDisposable
    {
        #region seller

        Task<RequestSellerResult> AddNewSellerRequestAsync(RequestSellerDTO seller, ClaimsPrincipal userCP);
        Task<FilterSellerDTO> FilterSellersAsync(FilterSellerDTO filter);
        Task<bool> AcceptSellerRequestAsync(long requestId);
        Task<bool> RejectSellerRequestAsync(RejectItemDTO reject);
        #endregion
    }
}
