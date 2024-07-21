using MediatR;

namespace Hooping.Api.Abstractions.Messaging;

public interface ICommand 
    : IRequest;

public interface ICommand<TResponse> 
    : IRequest<TResponse>;
