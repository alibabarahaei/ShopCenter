using ShopCenter.Domain.Models.Base;
using ShopCenter.Domain.Models.User;
using System.ComponentModel.DataAnnotations;

namespace ShopCenter.Domain.Models.Contacts
{
    public class TicketMessage : BaseEntity
    {
        #region properties

        public long TicketId { get; set; }

        public string UserId { get; set; }

        [Display(Name = "متن پیام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Text { get; set; }

        #endregion

        #region relations

        public Ticket Ticket { get; set; }

        public ApplicationUser User { get; set; }

        #endregion
    }
}
