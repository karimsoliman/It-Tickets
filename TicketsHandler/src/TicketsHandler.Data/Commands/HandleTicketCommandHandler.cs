using MediatR;
using Microsoft.Extensions.Logging;
using TicketsHandler.Data.Common;
using TicketsHandler.Data.Repositories;

namespace TicketsHandler.Data.Commands
{
    public class HandleTicketCommandHandler : IRequestHandler<HandleTicketCommand, CommandResult<HandleTicketCommand>>
    {
        #region Constants

        public const string HandleTicketSuccessMessage = "Ticket successfully handled.";
        public const string HandleTicketFailMessage = "An exception occurred whilst attempting to handle ticket.";
        public const string HandleTicketNotFoundMessage = "Unable to find ticket with Id: {0}";

        #endregion

        #region Fields

        private readonly ILogger _logger;
        private readonly ITicketsRepository _ticketsRepository;

        #endregion

        #region Constructor

        public HandleTicketCommandHandler(ILogger<HandleTicketCommandHandler> logger, ITicketsRepository ticketsRepository)
        {
            _logger = logger;
            _ticketsRepository = ticketsRepository;
        }

        #endregion

        #region IRequestHandler

        public async Task<CommandResult<HandleTicketCommand>> Handle(HandleTicketCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!_ticketsRepository.GetTicketById(request.Id, out var ticket))
                {
                    _logger.LogError(string.Format(HandleTicketNotFoundMessage, request.Id));
                    return new NotFoundCommandResult<HandleTicketCommand>();
                }
                ticket.Handle();
                await _ticketsRepository.SaveChangesAsync(cancellationToken);

                _logger.LogDebug(HandleTicketSuccessMessage);
                return new SuccessCommandResult<HandleTicketCommand>(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, HandleTicketFailMessage);
                return new UnexpectedCommandResult<HandleTicketCommand>(ex);
            }
        }


        #endregion
    }
}
