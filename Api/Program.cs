using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddEntityFrameworkNpgsql()
    .AddDbContext<ApiDbContext>(options => options
    .UseNpgsql(builder.Configuration.GetConnectionString("DbConStr")));

var app = builder.Build();

app.MapGet("/bancos", async (ApiDbContext context) =>
{
    return await context.Bancos.ToListAsync();
});

app.MapGet("/boletos", async (ApiDbContext context) =>
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
