using ShopCenter.Domain.Models.Base;
using ShopCenter.Domain.Models.User;
using System.ComponentModel.DataAnnotations;

namespace ShopCenter.Domain.Models.Contacts
{
    public class Ticket : BaseEntity
    {
        #region properties

        public string UserId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "وضعیت تیکت")]
        public TicketState TicketState { get; set; }

        [Display(Name = "بخش مورد نظر")]
        public TicketSection TicketSection { get; set; }

        [Display(Name = "اولویت")]
        public TicketPriority TicketPriority { get; set; }

        public bool IsReadByOwner { get; set; }

        public bool IsReadByAdmin { get; set; }

        #endregion

        #region relations

        public ApplicationUser User { get; set; }
        public ICollection<TicketMessage> TicketMessages { get; set; }

        #endregion
    }


}
