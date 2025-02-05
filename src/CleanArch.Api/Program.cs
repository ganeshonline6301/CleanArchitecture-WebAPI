using CleanArch.Api;
using CleanArch.Application;
using CleanArch.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation()
                .AddApplication()
                .AddInfrastructure();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
