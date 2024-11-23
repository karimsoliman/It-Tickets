using Microsoft.EntityFrameworkCore;
using TicketsHandler.Data.Contexts;
using TicketsHandler.Data.Entities;

namespace TicketsHandler.Data.Repositories
{
    public class TicketsRepository : ITicketsRepository
    {
        #region fields

        private readonly TicketsContext _context;

        #endregion

        #region Constructor

        public TicketsRepository(TicketsContext context)
        {
            _context = context;
        }

        #endregion

        #region ITicketsRepository

        public Ticket Create(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            return ticket;
        }

        public List<Ticket> GetAllTickets()
        {
            return _context.Tickets.ToList();
        }

        public bool GetTicketById(int id, out Ticket ticket)
        {
            ticket = _context.Tickets.FirstOrDefault(t => t.Id == id);
            return ticket != null;
        }

        public void Delete(int id)
        {
            var ticket = _context.Tickets.FirstOrDefault(t => t.Id == id); 
            _context.Tickets.Remove(ticket);
        }

        #endregion

        #region IRepository

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                return await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

    }
}
