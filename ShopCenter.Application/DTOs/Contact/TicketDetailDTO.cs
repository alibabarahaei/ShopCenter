using ShopCenter.Domain.Models.Contacts;

namespace ShopCenter.Application.DTOs.Contact
{
    public class TicketDetailDTO
    {
        public Ticket Ticket { get; set; }

        public List<TicketMessage> TicketMessages { get; set; }
    }
}
