
using Hooping.Common.Handlers;
using Hooping.Common.Requests.Auth;

namespace Hooping.Api.Endpoints.Auth;

public class LoginEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        app.MapPost("", HandleAsync);
    }

    /// <summary>
    /// Login a user
    /// </summary>
    /// <param name="handler"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    private static async Task<IResult> HandleAsync(
        IAuthHandler handler,
        LoginRequest request)
    {
        var result = await handler.LoginAsync(request);

        return result.IsSuccess
            ? Results.Ok(result)
            : Results.BadRequest(result.Error);
    }
}
