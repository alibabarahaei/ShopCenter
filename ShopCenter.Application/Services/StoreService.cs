
using Microsoft.EntityFrameworkCore;
using ShopCenter.Application.DTOs.Paging;
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

        public async Task<FilterSellerDTO> FilterSellers(FilterSellerDTO filter)
        {




            var query = _sellerRepository.GetQuery()
               .Include(s => s.User)
               .AsQueryable();

            #region state

            switch (filter.State)
            {
                case FilterSellerState.All:
                    query = query.Where(s => !s.IsDelete);
                    break;
                case FilterSellerState.Accepted:
                    query = query.Where(s => s.StoreAcceptanceState == StoreAcceptanceState.Accepted && !s.IsDelete);
                    break;

                case FilterSellerState.UnderProgress:
                    query = query.Where(s => s.StoreAcceptanceState == StoreAcceptanceState.UnderProgress && !s.IsDelete);
                    break;
                case FilterSellerState.Rejected:
                    query = query.Where(s => s.StoreAcceptanceState == StoreAcceptanceState.Rejected && !s.IsDelete);
                    break;
            }

            #endregion

            #region filter

            if (filter.User != null)
            {
                var user = await _userService.GetUserAsync(new GetUserDTO()
                {
                    User = filter.User
                });
                query = query.Where(s => s.UserId == user.Id);
            }

            if (!string.IsNullOrEmpty(filter.StoreName))
                query = query.Where(s => EF.Functions.Like(s.StoreName, $"%{filter.StoreName}%"));

            if (!string.IsNullOrEmpty(filter.Phone))
                query = query.Where(s => EF.Functions.Like(s.Phone, $"%{filter.Phone}%"));

            if (!string.IsNullOrEmpty(filter.Mobile))
                query = query.Where(s => EF.Functions.Like(s.Mobile, $"%{filter.Mobile}%"));

            if (!string.IsNullOrEmpty(filter.Address))
                query = query.Where(s => EF.Functions.Like(s.Address, $"%{filter.Address}%"));

            #endregion

            #region paging

            var pager = Pager.Build(filter.PageId, await query.CountAsync(), filter.TakeEntity, filter.HowManyShowPageAfterAndBefore);
            var allEntities = await query.Paging(pager).ToListAsync();

            #endregion

            return filter.SetPaging(pager).SetSellers(allEntities);
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
