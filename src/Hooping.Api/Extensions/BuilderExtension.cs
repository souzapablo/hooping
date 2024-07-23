using Hooping.Api.Auth;
using Hooping.Api.Data;
using Hooping.Api.Handlers;
using Hooping.Api.OptionsSetup;
using Hooping.Common.Handlers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Hooping.Api.Extensions;

public static class BuilderExtension
{
    public static void AddDocumentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new()
            {
                Title = "Hooping API",
                Version = "v1",
                Description = "A simple API for Hooping",
                Contact = new OpenApiContact
                {
                    Name = "Pablo Souza",
                    Email = "pablo.osouza@outlook.com",
                    Url = new Uri("https://github.com/souzapablo/")
                }
            });

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization with Bearer scheme."
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                    Array.Empty<string>()
                }
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        });
    }

    public static void AddDatabases(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration
            .GetConnectionString("DefaultConnection");

        builder.Services
            .AddDbContext<HoopingDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
    }

    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserHandler, UserHandler>();
    }

    public static void AddJwtAuthentication(this WebApplicationBuilder builder)
    {
        builder.Services.ConfigureOptions<JwtOptionsSetup>();
        builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

        builder.Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();

        builder.Services.AddScoped<IJwtProvider, JwtProvider>();
        builder.Services.AddScoped<IAuthHandler, AuthHandler>();
    }

    public static void AddSecurity(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthorization();
    }
}
