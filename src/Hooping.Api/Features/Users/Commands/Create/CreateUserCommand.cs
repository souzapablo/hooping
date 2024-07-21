using Hooping.Api.Abstractions.Messaging;
using Hooping.Common.Responses;

namespace Hooping.Api.Features.Users.Commands.Create;

public record CreateUserCommand(
    string Email,
    string Password) : ICommand<Result<long>>;
