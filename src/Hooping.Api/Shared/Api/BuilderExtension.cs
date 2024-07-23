using Hooping.Api.Data;
using Hooping.Api.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Hooping.Api.Shared.Api;

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


        builder.Services
            .AddIdentityCore<User>()
            .AddRoles<IdentityRole<long>>()
            .AddEntityFrameworkStores<HoopingDbContext>()
            .AddApiEndpoints();
    }

    public static void AddServices(this WebApplicationBuilder builder)
    {
    }

    public static void AddSecurity(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddAuthentication(IdentityConstants.ApplicationScheme)
            .AddIdentityCookies();
        builder.Services.AddAuthorization();
    }
}
