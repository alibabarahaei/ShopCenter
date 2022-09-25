using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCenter.Application.DTOs.Contact;
using ShopCenter.Application.InterfaceServices;

namespace ShopCenter.Presentation.Razor.Areas.User.Pages.Dashboard
{

    public class AnswerTicketModel : PageModel
    {


        #region properties

        public TicketDetailDTO Ticket { get; set; }

        #endregion





        #region constructor


        private readonly IContactService _contactService;

        public AnswerTicketModel(IContactService contactService)
        {
            _contactService = contactService;
        }

        #endregion

        public async Task<IActionResult> OnGet(long ticketId)
        {
            if (ticketId != null)
            {

                Ticket = await _contactService.GetTicketForShowAsync(new GetTicketDTO()
                {
                    User = User,
                    ticketId = ticketId
                });

                if (Ticket == null)
                {
                    TempData["ErrorMessage"] = "پیام مورد نظر یافت نشد"; ;
                    return RedirectToPage("Tickets");
                }
            }
            else
            {
                TempData["ErrorMessage"] = "پیام مورد نظر یافت نشد"; ;
            }


            return Page();
        }


        public async Task<IActionResult> OnPost(AnswerTicketDTO answer)
        {
            if (string.IsNullOrEmpty(answer.Text))
            {
                TempData["ErrorMessage"] = "لطفا متن پیام خود را وارد نمایید";
            }




            var res = await _contactService.AnswerTicketAsync(new AnswerTicketDTO()
            {
                User = User,
                Id = answer.Id,
                Text = answer.Text
            });
            switch (res)
            {
                case AnswerTicketResult.NotForUser:
                    TempData["ErrorMessage"] = "عدم دسترسی";
                    TempData["InfoMessage"] = "در صورت تکرار این مورد ، دسترسی شما به صورت کلی از سیستم قطع خواهد شد";
                    return RedirectToAction("Index");
                case AnswerTicketResult.NotFound:
                    TempData["WarningMessage"] = "اطلاعات مورد نظر یافت نشد";
                    return RedirectToAction("Index");
                case AnswerTicketResult.Success:
                    TempData["SuccessMessage"] = "اطلاعات مورد نظر با موفقیت ثبت شد";
                    break;
            }



            return RedirectToPage("AnswerTicket", new { ticketId = answer.Id });
        }
    }
}
