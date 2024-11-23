using TicketsHandler.Data.DataTransfer;
using TicketsHandler.Data.Models;

namespace TicketsHandler.Data.Queries
{
    public interface ITicketsQueries
    {
        Task<PayloadResponse<TicketDto>> GetAllTickets(int pageNumber);
    }
}
