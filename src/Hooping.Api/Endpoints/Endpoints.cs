using Hooping.Api.Endpoints.Identity;
using Hooping.Api.Entities;
using Hooping.Api.Shared.Api;

namespace Hooping.Api.Endpoints;

public static class Endpoints
{
    public static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        var endpoints = app
            .MapGroup("");

        endpoints.MapGroup("/")
            .WithTags("Health Check")
            .MapGet("/", () => new { message = "Hello World!" });

        endpoints.MapGroup("v1/identity")
            .WithTags("Identity")
            .MapIdentityApi<User>();

        endpoints.MapGroup("v1/identity")
            .WithTags("Identity")
            .MapEndpoint<GetRolesEndpoint>()
            .MapEndpoint<LogoutEndpoint>();

    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}
