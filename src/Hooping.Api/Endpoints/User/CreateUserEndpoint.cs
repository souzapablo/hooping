using Hooping.Api.Features.Users.Commands.Create;
using Hooping.Common.Requests.User;
using MediatR;

namespace Hooping.Api.Endpoints.User;

public class CreateUserEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("", HandleAsync);
    }

    private static async Task<IResult> HandleAsync(
        ISender sender,
        CreateUserRequest request)
    {
        var result = await sender.Send(new CreateUserCommand(request.Email, request.Password));

        return result.IsSuccess
            ? Results.Created($"/v1/users/{result.Value}", result)
            : Results.BadRequest(result.Error);
    }
}
