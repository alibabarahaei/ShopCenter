using ShopCenter.Application.DTOs.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenter.Application.InterfaceServices
{
    public interface IStoreService:IAsyncDisposable
    {
        #region seller

        Task<RequestSellerResult> AddNewSellerRequest(RequestSellerDTO seller, ClaimsPrincipal userCP);

        #endregion
    }
}
