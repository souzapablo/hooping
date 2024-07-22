using Hooping.Common.Handlers;
using Hooping.Common.Requests.User;

namespace Hooping.Api.Endpoints.User;

public class CreateUserEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("", HandleAsync);
    }

    /// <summary>
    /// Create a new user
    /// </summary>
    /// <param name="handler"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    private static async Task<IResult> HandleAsync(
        IUserHandler handler,
        CreateUserRequest request)
    {
        var result = await handler.CreateAsync(request);

        return result.IsSuccess
            ? Results.Created($"/v1/users/{result.Value}", result)
            : Results.BadRequest(result.Error);
    }
}
