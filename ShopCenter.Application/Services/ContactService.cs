using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopCenter.Application.DTOs.Contact;
using ShopCenter.Application.DTOs.Paging;
using ShopCenter.Application.DTOs.User;
using ShopCenter.Application.InterfaceServices;
using ShopCenter.Domain.InterfaceRepositories.Base;
using ShopCenter.Domain.Models.Contacts;

namespace ShopCenter.Application.Services
{
    public class ContactService:IContactService
    {



        #region constructor

        
        private readonly IGenericRepository<Ticket> _ticketRepository;
        private readonly IGenericRepository<TicketMessage> _ticketMessageRepository;
        private readonly IUserService _userService;

        public ContactService(IGenericRepository<Ticket> ticketRepository, IGenericRepository<TicketMessage> ticketMessageRepository, IUserService userService)
        {
            _ticketRepository = ticketRepository;
            _ticketMessageRepository = ticketMessageRepository;
            _userService = userService;
        }

        #endregion


        #region ticket

        public async Task<AddTicketResult> AddUserTicketAsync(AddTicketDTO ticket, ClaimsPrincipal userCP)
        {
            if (string.IsNullOrEmpty(ticket.Text)) return AddTicketResult.Error;


            var user = await _userService.GetUserAsync(new GetUserDTO()
            {
                User = userCP
            });
            // add ticket
            var newTicket = new Ticket
            {
                UserId = user.Id,
                IsReadByOwner = true,
                TicketPriority = ticket.TicketPriority,
                Title = ticket.Title,
                TicketSection = ticket.TicketSection,
                TicketState = TicketState.UnderProgress
            };

            await _ticketRepository.AddEntity(newTicket);
            await _ticketRepository.SaveChanges();

            // add ticket message
            var newMessage = new TicketMessage
            {
                TicketId = newTicket.Id,
                Text = ticket.Text,
                UserId = user.Id,
            };

            await _ticketMessageRepository.AddEntity(newMessage);
            await _ticketMessageRepository.SaveChanges();

            return AddTicketResult.Success;
        }

        public async Task<FilterTicketDTO> FilterTicketsAsync(FilterTicketDTO filter)
        {
            var query = _ticketRepository.GetQuery().AsQueryable();

            #region state

            switch (filter.FilterTicketState)
            {
                case FilterTicketState.All:
                    break;
                case FilterTicketState.Deleted:
                    query = query.Where(s => s.IsDelete);
                    break;
                case FilterTicketState.NotDeleted:
                    query = query.Where(s => !s.IsDelete);
                    break;
            }

            switch (filter.OrderBy)
            {
                case FilterTicketOrder.CreateDate_ASC:
                    query = query.OrderBy(s => s.CreateDate);
                    break;
                case FilterTicketOrder.CreateDate_DES:
                    query = query.OrderByDescending(s => s.CreateDate);
                    break;
            }

            #endregion

            #region filter

            if (filter.TicketSection != null)
                query = query.Where(s => s.TicketSection == filter.TicketSection.Value);

            if (filter.TicketPriority != null)
                query = query.Where(s => s.TicketPriority == filter.TicketPriority.Value);

            if (filter.User != null )
            {
               var user= await _userService.GetUserAsync(new GetUserDTO()
                {
                    User = filter.User
                });
               query = query.Where(s => s.UserId == user.Id);

            }

            if (!string.IsNullOrEmpty(filter.Title))
                query = query.Where(s => EF.Functions.Like(s.Title, $"%{filter.Title}%"));

            #endregion


            #region paging

            var pager = Pager.Build(filter.PageId, await query.CountAsync(), filter.TakeEntity, filter.HowManyShowPageAfterAndBefore);
            var allEntities = await query.Paging(pager).ToListAsync();

            #endregion


            return filter.SetPaging(pager).SetTickets(allEntities);
        }

        public async Task<TicketDetailDTO> GetTicketForShowAsync(GetTicketDTO getTicket)
        {
            var ticket = await _ticketRepository.GetQuery().AsQueryable()
                .Include(s => s.User)
                .SingleOrDefaultAsync(s => s.Id == getTicket.ticketId);
            var user = await _userService.GetUserAsync(new GetUserDTO()
            {
                User = getTicket.User
            });
            if (ticket == null || ticket.UserId !=user.Id) return null;

            return new TicketDetailDTO
            {
                Ticket = ticket,
                TicketMessages = await _ticketMessageRepository.GetQuery().AsQueryable()
                    .OrderByDescending(s => s.CreateDate)
                    .Where(s => s.TicketId == getTicket.ticketId && !s.IsDelete).ToListAsync()
            };
        }

        public async Task<AnswerTicketResult> AnswerTicketAsync(AnswerTicketDTO answer)
        {
            var user = await _userService.GetUserAsync(new GetUserDTO()
            {
                User = answer.User
            });
            var ticket = await _ticketRepository.GetEntityById(answer.Id);
            if (ticket == null) return AnswerTicketResult.NotFound;
            if (ticket.UserId != user.Id) return AnswerTicketResult.NotForUser;

            var ticketMessage = new TicketMessage
            {
                TicketId = ticket.Id,
                UserId = user.Id,
                Text = answer.Text
            };

            await _ticketMessageRepository.AddEntity(ticketMessage);
            await _ticketMessageRepository.SaveChanges();

            ticket.IsReadByAdmin = false;
            ticket.IsReadByOwner = true;
            await _ticketRepository.SaveChanges();
            return AnswerTicketResult.Success;
        }


        #endregion

        #region dispose

        public async ValueTask DisposeAsync()
        {
          
        }

        #endregion







    }
}
