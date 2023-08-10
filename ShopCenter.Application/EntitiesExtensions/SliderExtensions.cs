using ShopCenter.Application.Utilities;
using ShopCenter.Domain.Models.Site;

namespace ShopCenter.Application.EntitiesExtensions
{
    public static class SliderExtensions
    {
        public static string GetSliderImageAddress(this Slider slider)
        {
            return SD.SliderOrigin + slider.ImageName;
        }
    }
}
