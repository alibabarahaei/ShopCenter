using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShopCenter.Application.DTOs.Contact
{
    public class GetTicketDTO
    {
       public long ticketId { get; set; }

       public ClaimsPrincipal User { get; set; }
    }
}
