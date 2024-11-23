using TicketsHandler.Data.Entities;

namespace TicketsHandler.Data.Models
{
    public class TicketDto
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string ComplaintDescription { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public TicketStatus Status { get; set; }
    }
}
