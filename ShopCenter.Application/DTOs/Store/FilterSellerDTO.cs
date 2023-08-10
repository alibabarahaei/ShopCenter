using ShopCenter.Application.DTOs.Paging;
using ShopCenter.Domain.Models.Store;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace ShopCenter.Application.DTOs.Store
{
    public class FilterSellerDTO : BasePaging
    {

        #region properties

        public ClaimsPrincipal? User { get; set; }
        public string StoreName { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public FilterSellerState State { get; set; }

        public List<Seller> Sellers { get; set; }

        #endregion


        #region methods

        public FilterSellerDTO SetSellers(List<Seller> sellers)
        {
            this.Sellers = sellers;
            return this;
        }

        public FilterSellerDTO SetPaging(BasePaging paging)
        {
            this.PageId = paging.PageId;
            this.AllEntitiesCount = paging.AllEntitiesCount;
            this.StartPage = paging.StartPage;
            this.EndPage = paging.EndPage;
            this.HowManyShowPageAfterAndBefore = paging.HowManyShowPageAfterAndBefore;
            this.TakeEntity = paging.TakeEntity;
            this.SkipEntity = paging.SkipEntity;
            this.PageCount = paging.PageCount;
            return this;
        }

        #endregion
    }

    public enum FilterSellerState
    {
        [Display(Name = "همه")]
        All,
        [Display(Name = "در حال بررسی")]
        UnderProgress,
        [Display(Name = "تایید شده")]
        Accepted,
        [Display(Name = "رد شده")]
        Rejected
    }

}
