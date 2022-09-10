using ShopCenter.Application.Utilities;
using ShopCenter.Domain.Models.Site;


namespace ShopCenter.Application.EntitiesExtensions
{
    public static class BannerExtension
    {
        public static string GetSliderImageAddress(this Banner banner)
        {
            return SD.BannerOrigin + banner.ImageName;
        }
    }
}
