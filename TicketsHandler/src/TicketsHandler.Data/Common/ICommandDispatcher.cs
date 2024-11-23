using MediatR;

namespace TicketsHandler.Data.Common
{
    public interface ICommandDispatcher
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
    }
}
