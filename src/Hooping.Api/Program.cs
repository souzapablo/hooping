using Hooping.Api.Endpoints;
using Hooping.Api.Shared.Api;

var builder = WebApplication.CreateBuilder(args);

builder.AddSecurity();
builder.AddDatabases();
builder.AddServices();
builder.AddDocumentation();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.ConfigureDevEnvironment();

app.UseSecurity();
app.MapEndpoints();

app.Run();
