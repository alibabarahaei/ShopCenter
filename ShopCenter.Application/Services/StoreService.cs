
using Microsoft.EntityFrameworkCore;
using ShopCenter.Application.DTOs.Store;
using ShopCenter.Application.DTOs.User;
using ShopCenter.Application.InterfaceServices;
using ShopCenter.Domain.InterfaceRepositories.Base;
using ShopCenter.Domain.Models.Store;
using System.Security.Claims;


namespace ShopCenter.Application.Services
{
    public class StoreService : IStoreService
    {
        #region constrcutor

        private readonly IGenericRepository<Seller> _sellerRepository;
        private readonly IUserService _userService;

        public StoreService(IGenericRepository<Seller> sellerRepository, IUserService userService)
        {
            _sellerRepository = sellerRepository;
            _userService = userService;
        }

        #endregion

        #region seller

        public async Task<RequestSellerResult> AddNewSellerRequest(RequestSellerDTO seller, ClaimsPrincipal userCP)
        {
            var user = await _userService.GetUserAsync(new GetUserDTO()
            {
                User = userCP
            });

            //if (user.IsBlocked) return RequestSellerResult.HasNotPermission;

            var hasUnderProgressRequest = await _sellerRepository.GetQuery().AsQueryable().AnyAsync(s =>
                s.UserId == user.Id && s.StoreAcceptanceState == StoreAcceptanceState.UnderProgress);

            if (hasUnderProgressRequest) return RequestSellerResult.HasUnderProgressRequest;

            var newSeller = new Seller
            {
                UserId = user.Id,
                StoreName = seller.StoreName,
                Address = seller.Address,
                Phone = seller.Phone,
                StoreAcceptanceState = StoreAcceptanceState.UnderProgress
            };

            await _sellerRepository.AddEntity(newSeller);
            await _sellerRepository.SaveChanges();

            return RequestSellerResult.Success;
        }

        #endregion

        #region dispose

        public async ValueTask DisposeAsync()
        {
            await _sellerRepository.DisposeAsync();
        }

        #endregion
    }
}
