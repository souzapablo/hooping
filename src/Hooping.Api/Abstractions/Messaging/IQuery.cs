using MediatR;

namespace Hooping.Api.Abstractions.Messaging;

public interface IQuery<TResponse> 
    : IRequest<TResponse>;
