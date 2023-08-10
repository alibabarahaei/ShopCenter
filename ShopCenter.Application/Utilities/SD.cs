namespace ShopCenter.Application.Utilities
{
    public static class SD
    {

        #region path






        #region uploader

        public static string UploadImage = "/img/upload/";
        public static string UploadImageServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/upload/");

        #endregion



        #region products

        public static string ProductImage = "/content/images/product/origin/";

        public static string ProductImageImageServer =
            Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/product/origin/");

        public static string ProductThumbnailImage = "/content/images/product/thumb/";

        public static string ProductThumbnailImageImageServer =
            Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/product/thumb/");

        #endregion


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
