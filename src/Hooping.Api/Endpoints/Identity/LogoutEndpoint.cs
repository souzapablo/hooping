using Hooping.Api.Entities;
using Hooping.Api.Shared.Api;
using Microsoft.AspNetCore.Identity;

namespace Hooping.Api.Endpoints.Identity;

public class LogoutEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapPost("/logout", HandleAsync)
            .RequireAuthorization();

    private static async Task<IResult> HandleAsync(SignInManager<User> signInManager)
    {
        await signInManager.SignOutAsync();
        return Results.Ok();
    }
}