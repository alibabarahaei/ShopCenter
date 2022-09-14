using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCenter.Application.DTOs.Contact;
using ShopCenter.Application.InterfaceServices;
using ShopCenter.Domain.Models.Contacts;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ShopCenter.Presentation.Razor.Areas.User.Pages.Dashboard
{


    [BindProperties]
    public class AddTicketModel : PageModel
    {


        #region properties
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "بخش مورد نظر")]
        public TicketSection TicketSection { get; set; }

        [Display(Name = "اولویت")]
        public TicketPriority TicketPriority { get; set; }

        [Display(Name = "متن پیام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Text { get; set; }


        #endregion



        #region constructor

        private readonly IContactService _contactService;

        public AddTicketModel(IContactService contactService)
        {
            _contactService = contactService;
        }

        #endregion







        public void OnGet()
        {
        }



        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {

                var ticket = new AddTicketViewModel()
                {
                    Title = Title,
                    TicketSection = TicketSection,
                    TicketPriority = TicketPriority,
                    Text = Text

                };
                
                var result = await _contactService.AddUserTicket(ticket, User);
                switch (result)
                {
                    case AddTicketResult.Error:
                        TempData["ErrorMessage"] = "عملیات با شکست مواجه شد";
                        break;
                    case AddTicketResult.Success:
                        TempData["SuccessMessage"] = "تیکت شما با موفقیت ثبت شد";
                        TempData["InfoMessage"] = "پاسخ شما به زودی ارسال خواهد شد";
                        return RedirectToPage("Profile");
                }
            }
            else
            {
                return Page();
            }

            return Page();
        }
            




    }
}
