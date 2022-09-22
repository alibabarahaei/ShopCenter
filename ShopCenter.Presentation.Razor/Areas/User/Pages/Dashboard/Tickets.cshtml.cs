using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCenter.Application.DTOs.Contact;
using ShopCenter.Application.InterfaceServices;

namespace ShopCenter.Presentation.Razor.Areas.User.Pages.Dashboard
{
    public class TicketsModel : PageModel
    {
        public FilterTicketDTO FilterTickets { get; set; }


        private readonly IContactService _contactService;


        public TicketsModel(IContactService contactService)
        {
            _contactService = contactService;
        }


        public async  Task OnGet(FilterTicketDTO filter)
        {
            filter.User = User;
            filter.FilterTicketState = FilterTicketState.NotDeleted;
            filter.OrderBy = FilterTicketOrder.CreateDate_DES;
            FilterTickets=await _contactService.FilterTicketsAsync(filter);


        }
    }
}
