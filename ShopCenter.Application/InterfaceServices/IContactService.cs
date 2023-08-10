using ShopCenter.Application.DTOs.Contact;
using System.Security.Claims;

namespace ShopCenter.Application.InterfaceServices
{
    public interface IContactService : IAsyncDisposable
    {

        #region ticket

        Task<AddTicketResult> AddUserTicketAsync(AddTicketDTO ticket, ClaimsPrincipal userCP);
        Task<FilterTicketDTO> FilterTicketsAsync(FilterTicketDTO filter);
        Task<TicketDetailDTO> GetTicketForShowAsync(GetTicketDTO getTicket);
        Task<AnswerTicketResult> AnswerTicketAsync(AnswerTicketDTO answer);
        #endregion
    }
}
