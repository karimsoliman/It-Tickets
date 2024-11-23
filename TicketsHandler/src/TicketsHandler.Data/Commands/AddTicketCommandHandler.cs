using MediatR;
using Microsoft.Extensions.Logging;
using TicketsHandler.Data.Common;
using TicketsHandler.Data.Entities;
using TicketsHandler.Data.Repositories;

namespace TicketsHandler.Data.Commands
{
    public class AddTicketCommandHandler : IRequestHandler<AddTicketCommand, CommandResult<AddTicketCommand>>
    {
        #region Constants

        public const string AddTicketSuccessMessage = "Ticket successfully created.";
        public const string AddTicketFailMessage = "An exception occurred whilst attempting to create ticket.";

        #endregion

        #region Fields

        private readonly ILogger _logger;
        private readonly ITicketsRepository _ticketsRepository;

        #endregion

        #region Constructor

        public AddTicketCommandHandler(ILogger<AddTicketCommandHandler> logger, ITicketsRepository ticketsRepository)
        {
            _logger = logger;
            _ticketsRepository = ticketsRepository;
        }

        #endregion

        #region IRequestHandler

        public async Task<CommandResult<AddTicketCommand>> Handle(AddTicketCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Ticket newTicket = new Ticket(request.UserName, request.ComplaintDescription);
                _ticketsRepository.Create(newTicket);
                await _ticketsRepository.SaveChangesAsync(cancellationToken);
                
                _logger.LogDebug(AddTicketSuccessMessage);
                return new SuccessCommandResult<AddTicketCommand>(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, AddTicketFailMessage);
                return new UnexpectedCommandResult<AddTicketCommand>(ex);
            }
        }

        #endregion

    }
}
