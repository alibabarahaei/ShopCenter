using System.Security.Claims;

namespace ShopCenter.Application.DTOs.Contact
{
    public class GetTicketDTO
    {
        public long ticketId { get; set; }

        public ClaimsPrincipal User { get; set; }
    }
}
