using MediatR;
using TicketsHandler.Data.Common;

namespace TicketsHandler.Data.Commands
{
    public class AddTicketCommand : IRequest<CommandResult<AddTicketCommand>>
    {
        #region Constructor

        public AddTicketCommand(string userName, string complaintDescription)
        {
            UserName = userName;
            ComplaintDescription = complaintDescription;
        }

        #endregion

        #region Properties

        public string UserName { get; set; }
        public string ComplaintDescription { get; set; }

        #endregion
    }
}
