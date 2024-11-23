using MediatR;
using TicketsHandler.Data.Common;

namespace TicketsHandler.Data.Commands
{
    public class HandleTicketCommand : IRequest<CommandResult<HandleTicketCommand>>
    {
        #region Constructor

        public HandleTicketCommand(int id)
        {
            Id = id;
        }

        #endregion

        #region Properties

        public int Id { get; private set; }

        #endregion
    }
}
