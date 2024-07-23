using Hooping.Api.Endpoints.Auth;
using Hooping.Api.Endpoints.User;

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

        app.MapGroup("v1/auth")
            .WithTags("Auth")
            .MapEndpoint<LoginEndpoint>();

        app.MapGroup("v1/users")
            .WithTags("Users")
            .MapEndpoint<CreateUserEndpoint>();

    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}
