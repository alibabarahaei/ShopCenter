using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace ShopCenter.Application.DTOs.Contact
{
    public class AnswerTicketDTO
    {
        public long Id { get; set; }

        
        public string Text { get; set; }


        public ClaimsPrincipal User { get; set; } = null;
    }

    public enum AnswerTicketResult
    {
        NotForUser,
        NotFound,
        Success
    }
}
