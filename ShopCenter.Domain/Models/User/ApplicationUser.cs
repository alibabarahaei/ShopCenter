
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Identity;
using ShopCenter.Domain.Models.Contacts;
using ShopCenter.Domain.Models.Store;

namespace ShopCenter.Domain.Models.User
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "نام")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string? FirstName { get; set; }


        [Display(Name = "نام خانوادگی")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string? LastName { get; set; }


        [Display(Name = "تاریخ عضویت")]
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Display(Name = "تصویر پروفایل")] 
        public string? PathProfileImage { get; set; }

        public char? Gender { get; set; } = GenderTypes.Unknown;





        #region relations

        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<TicketMessage> TicketMessages { get; set; }
        public ICollection<Seller>  Sellers { get; set; }

        #endregion












    }
}
