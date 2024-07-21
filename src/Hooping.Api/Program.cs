using Hooping.Api.Data;
using Hooping.Api.Endpoints;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection");

builder.Services
    .AddDbContext<HoopingDbContext>(config =>
{
    config.UseNpgsql(connectionString);
});

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});

var app = builder.Build();

app.MapEndpoints();

app.Run();
