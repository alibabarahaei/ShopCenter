using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ShopCenter.Application.DTOs.Contact;

namespace ShopCenter.Application.InterfaceServices
{
    public interface IContactService
    {

        #region ticket

        Task<AddTicketResult> AddUserTicket(AddTicketViewModel ticket, ClaimsPrincipal userCP);

        #endregion
    }
}
