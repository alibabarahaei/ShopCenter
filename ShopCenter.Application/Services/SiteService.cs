
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

        public SiteService(IGenericRepository<Slider> sliderRepository)
        {
            
            _sliderRepository = sliderRepository;
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
        }

        #endregion
    }
}
