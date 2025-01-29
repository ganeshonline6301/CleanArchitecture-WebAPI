using CleanArch.Api;
using CleanArch.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation()
                .AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
