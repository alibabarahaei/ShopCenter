using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShopCenter.Domain.Models.Contacts
{


    public enum TicketSection
    {
        [Display(Name = "پشتیبانی")]
        Support,
        [Display(Name = "فنی")]
        Technical,
        [Display(Name = "آموزشی")]
        Academic
    }

    public enum TicketPriority
    {
        [Display(Name = "کم")]
        Low,
        [Display(Name = "متوسط")]
        Medium,
        [Display(Name = "زیاد")]
        High
    }

    public enum TicketState
    {
        [Display(Name = "در حال بررسی")]
        UnderProgress,
        [Display(Name = "پاسخ داده شده")]
        Answered,
        [Display(Name = "بسته شده")]
        Closed
    }

  
}
