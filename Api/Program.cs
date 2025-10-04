using Api;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("TechDb");

builder.Services.AddServices(connectionString);

var app = builder.Build();

app.MapGet("/bancos", async (TechDbContext context) =>
{
    return await context.Bancos.ToListAsync();
});

app.MapGet("/boletos", async (TechDbContext context) =>
{
    return await context.Boletos.ToListAsync();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
