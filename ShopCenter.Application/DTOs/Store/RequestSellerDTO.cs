namespace ShopCenter.Application.DTOs.Store
{
    public class RequestSellerDTO
    {

        public string StoreName { get; set; }


        public string Phone { get; set; }

        public string Address { get; set; }
    }

    public enum RequestSellerResult
    {
        Success,
        HasUnderProgressRequest,
        HasNotPermission
    }
}
