using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenter.Application.Utilities
{
    public static class SD
    {

        #region path

        #region default images

        public static string DefaultProfileman = "/images/defaults/man.png";
        public static string DefaultProfilewoman = "/images/defaults/woman.png";
        

        #endregion 


        #region user avatar

        public static string UserProfileOrigin = "/content/images/profileimage/origin/";
        public static string UserProfileOriginServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/profileimage/origin/");

        public static string UserProfileThumb = "/content/images/profileimage/thumb/";
        public static string UserProfileThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/profileimage/thumb/");


        #endregion



        #region banner
        public static string BannerOrigin = "/images/adplacement/";
        #endregion

        #region slider
        public static string SliderOrigin = "/images/slider-main/";
        #endregion
        

        #endregion



    }
}
