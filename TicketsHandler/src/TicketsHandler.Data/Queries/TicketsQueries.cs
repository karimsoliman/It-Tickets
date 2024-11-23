using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TicketsHandler.Data.Contexts;
using TicketsHandler.Data.DataTransfer;
using TicketsHandler.Data.Entities;
using TicketsHandler.Data.Models;

namespace TicketsHandler.Data.Queries
{
    public class TicketsQueries : ITicketsQueries
    {
        #region Fields

        private readonly ILogger _logger;
        private readonly TicketsContext _context;

        #endregion

        #region Constructor

        public TicketsQueries(TicketsContext dbContext, ILogger<TicketsQueries> logger)
        {
            _logger = logger;
            _context = dbContext;
        }

        #endregion

        #region ITicketsQueries

        public async Task<PayloadResponse<TicketDto>> GetAllTickets(int pageNumber)
        {
            try
            {
                var skip = pageNumber * 5;
                var query = await _context.Tickets.ToListAsync();
                var count = query.Count();
                var tickets = query.Skip(skip).Take(5).Select(t => Map(t)).ToList();
                return new PayloadResponse<TicketDto>
                {
                    Payload = tickets,
                    IsSuccess = true,
                    Count = count
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new PayloadResponse<TicketDto>
                {
                    IsSuccess = false
                };
            }
        }

        #endregion

        #region HelperMethods

        private TicketDto Map(Ticket ticket)
        {
            return new TicketDto
            {
                Id = ticket.Id,
                Status = ticket.Status,
                User = ticket.UserName,
                ComplaintDescription = ticket.ComplaintDescription,
            };
        }

        #endregion
    }
}
