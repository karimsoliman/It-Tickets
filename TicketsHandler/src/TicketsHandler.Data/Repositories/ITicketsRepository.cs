using TicketsHandler.Data.Entities;

namespace TicketsHandler.Data.Repositories
{
    public interface ITicketsRepository
    {
        List<Ticket> GetAllTickets();
        bool GetTicketById(int id, out Ticket ticket);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Ticket Create(Ticket ticket);
        void Delete(int id);
    }
}
