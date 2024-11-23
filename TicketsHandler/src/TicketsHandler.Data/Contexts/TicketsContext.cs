using Microsoft.EntityFrameworkCore;
using TicketsHandler.Data.Entities;

namespace TicketsHandler.Data.Contexts
{
    public class TicketsContext : DbContext
    {
        public TicketsContext(DbContextOptions<TicketsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }

        public DbSet<Ticket> Tickets { get; set; }
    }
}
