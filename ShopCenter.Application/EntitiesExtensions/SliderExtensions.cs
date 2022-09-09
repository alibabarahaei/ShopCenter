using ShopCenter.Domain.Models.Site;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopCenter.Application.Utilities;

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
