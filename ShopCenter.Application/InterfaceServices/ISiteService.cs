using ShopCenter.Domain.Models.Site;

namespace ShopCenter.Application.InterfaceServices
{
    public interface ISiteService : IAsyncDisposable
    {
        #region slider

        Task<List<Slider>> GetAllActiveSliders();

        #endregion
        #region site banners

        Task<List<Banner>> GetSiteBannersByPlacement(List<BannerPlacement> placements);

        #endregion
    }
}
