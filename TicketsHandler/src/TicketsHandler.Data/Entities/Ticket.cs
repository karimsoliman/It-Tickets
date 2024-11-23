namespace TicketsHandler.Data.Entities
{
    public class Ticket
    {
        #region Constructor

        public Ticket(string userName, string complaintDescription)
        {
            CreatedDateTime = DateTime.UtcNow;
            UserName = userName;
            ComplaintDescription = complaintDescription;
            Status = TicketStatus.NotHandled;
        }

        #endregion


        #region Columns

        public int Id { get; set; }
        public DateTime CreatedDateTime { get; private set; }
        public string UserName { get; private set; }
        public string ComplaintDescription { get; private set; }
        public TicketStatus Status { get; private set; }

        #endregion

        #region Public methods

        public void Handle()
        {
            Status = TicketStatus.Handled;
        }

        #endregion
    }
}
