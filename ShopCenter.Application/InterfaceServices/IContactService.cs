using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ShopCenter.Application.DTOs.Contact;
using ShopCenter.Domain.Models.Contacts;

namespace ShopCenter.Application.InterfaceServices
{
    public interface IContactService
    {

        #region ticket

        Task<AddTicketResult> AddUserTicketAsync(AddTicketDTO ticket, ClaimsPrincipal userCP);
        Task<FilterTicketDTO> FilterTicketsAsync(FilterTicketDTO filter);
        Task<TicketDetailDTO> GetTicketForShowAsync(GetTicketDTO getTicket );
        Task<AnswerTicketResult> AnswerTicketAsync(AnswerTicketDTO answer);
        #endregion
    }
}
