using Hooping.Api.Entities;
using Hooping.Api.Shared.Api;
using System.Security.Claims;

namespace Hooping.Api.Endpoints.Identity;

public class GetRolesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app) =>
        app.MapGet("/roles", Handle)
            .RequireAuthorization();

    public static IResult Handle(ClaimsPrincipal user)
    {
        if (user.Identity is null || !user.Identity.IsAuthenticated)
            return Results.Unauthorized();

        var identity = (ClaimsIdentity)user.Identity;
        var roles = identity
            .FindAll(ClaimTypes.Role)
            .Select(c => new RoleClaim
            {
                Issuer = c.Issuer,
                OrignalIssuer = c.OriginalIssuer,
                Type = c.Type,
                Value = c.Value,
                ValueType = c.ValueType
            });

        return TypedResults.Json(roles);
    }
}