using MediatR;
using Microsoft.Extensions.Logging;

namespace TicketsHandler.Data.Common
{
    public class CommandDispatcher : ICommandDispatcher
    {
        #region Fields

        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        #endregion

        #region Constructor

        public CommandDispatcher(ILogger<CommandDispatcher> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        #endregion

        #region ICommandDispatcher

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            _logger.LogDebug($"Attempting to send command of type '{typeof(IRequest<TResponse>)}'.");
            return await _mediator.Send(request, cancellationToken);
        }

        #endregion
    }
}
