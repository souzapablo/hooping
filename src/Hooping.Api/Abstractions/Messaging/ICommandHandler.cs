using MediatR;

namespace Hooping.Api.Abstractions.Messaging;

public interface ICommandHandler<TCommand> 
    : IRequestHandler<TCommand> 
    where TCommand : IRequest;

public interface ICommandHandler<TCommand, TResponse>
    : IRequestHandler<TCommand, TResponse>
    where TCommand : IRequest<TResponse>;