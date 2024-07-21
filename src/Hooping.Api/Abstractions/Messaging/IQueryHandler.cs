using MediatR;

namespace Hooping.Api.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, TResponse>
    where TQuery : IRequest<TResponse>;