
using Microsoft.EntityFrameworkCore;
using ShopCenter.Application.InterfaceServices;
using ShopCenter.Domain.InterfaceRepositories.Base;
using ShopCenter.Domain.Models.Site;

namespace ShopCenter.Application.Services
{
    public class SiteService:ISiteService
    {


        #region constructor

        
        private readonly IGenericRepository<Slider> _sliderRepository;
        private readonly IGenericRepository<Banner> _bannerRepository;
        public SiteService(IGenericRepository<Slider> sliderRepository, IGenericRepository<Banner> bannerRepository)
        {
            _sliderRepository = sliderRepository;
            _bannerRepository = bannerRepository;
        }

        #endregion

        #region site banners

        public async Task<List<Banner>> GetSiteBannersByPlacement(List<BannerPlacement> placements)
        {
            return await _bannerRepository.GetQuery().AsQueryable()
                .Where(s => placements.Contains(s.BannerPlacement)).ToListAsync();
        }

        #endregion

        #region slider

        public async Task<List<Slider>> GetAllActiveSliders()
        {
            return await _sliderRepository.GetQuery().AsQueryable()
                .Where(s => s.IsActive && !s.IsDelete).ToListAsync();
        }


        #endregion

        #region dispose

        public async ValueTask DisposeAsync()
        {

            if (_sliderRepository != null) await _sliderRepository.DisposeAsync();
            if (_bannerRepository != null) await _bannerRepository.DisposeAsync();
        }

        #endregion
    }
}
