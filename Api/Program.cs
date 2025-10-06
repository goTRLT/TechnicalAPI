using Api;
using Api.Extensions;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServices();

var app = builder.Build();

app.Configure();

app.Run();
