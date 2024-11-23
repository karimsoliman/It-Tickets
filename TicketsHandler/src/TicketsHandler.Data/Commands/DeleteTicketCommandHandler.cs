using MediatR;
using Microsoft.Extensions.Logging;
using TicketsHandler.Data.Common;
using TicketsHandler.Data.Repositories;

namespace TicketsHandler.Data.Commands;

public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand, CommandResult<DeleteTicketCommand>>
{
    #region Constants

    public const string DeleteTicketSuccessMessage = "Ticket successfully deleted.";
    public const string DeleteTicketFailMessage = "An exception occurred whilst attempting to delete ticket.";
    public const string DeleteTicketNotFoundMessage = "Unable to find ticket with Id: {0}";

    #endregion

    #region Fields

    private readonly ILogger _logger;
    private readonly ITicketsRepository _ticketsRepository;

    #endregion

    #region Constructor

    public DeleteTicketCommandHandler(ILogger<DeleteTicketCommandHandler> logger, ITicketsRepository ticketsRepository)
    {
        _logger = logger;
        _ticketsRepository = ticketsRepository;
    }

    #endregion

    #region IRequestHandler

    public async Task<CommandResult<DeleteTicketCommand>> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (!_ticketsRepository.GetTicketById(request.Id, out var ticket))
            {
                _logger.LogError(string.Format(DeleteTicketNotFoundMessage, request.Id));
                return new NotFoundCommandResult<DeleteTicketCommand>();
            }
            _ticketsRepository.Delete(request.Id);
            await _ticketsRepository.SaveChangesAsync(cancellationToken);

            _logger.LogDebug(DeleteTicketSuccessMessage);
            return new SuccessCommandResult<DeleteTicketCommand>(request);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, DeleteTicketFailMessage);
            return new UnexpectedCommandResult<DeleteTicketCommand>(ex);
        }
    }


    #endregion
    
}