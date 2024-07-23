using Hooping.Api.Endpoints;
using Hooping.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddSecurity();
builder.AddDatabases();
builder.AddServices();
builder.AddDocumentation();
builder.AddJwtAuthentication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.ConfigureDevEnvironment();

app.UseSecurity();
app.MapEndpoints();

app.Run();
