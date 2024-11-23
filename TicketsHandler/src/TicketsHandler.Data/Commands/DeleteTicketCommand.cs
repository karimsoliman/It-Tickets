using MediatR;
using TicketsHandler.Data.Common;

namespace TicketsHandler.Data.Commands;

public class DeleteTicketCommand : IRequest<CommandResult<DeleteTicketCommand>>
{
    #region Constructor

    public DeleteTicketCommand(int id)
    {
        Id = id;
    }

    #endregion

    #region Properties

    public int Id { get; set; }

    #endregion
}