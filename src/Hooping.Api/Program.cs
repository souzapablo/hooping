using Hooping.Api.Config;
using Hooping.Api.Endpoints;
using Hooping.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddDatabases();
builder.AddServices();
builder.AddDocumentation();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.ConfigureDevEnvironment();

app.MapEndpoints();

app.Run();
