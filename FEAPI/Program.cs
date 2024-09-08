using DL;
using DL.Interfaces;
using DL.Services;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FalkonExampleContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MainConnection"));
});

builder.Services.AddScoped<IMainService, MainService>();
builder.Services.AddFastEndpoints().SwaggerDocument();

var app = builder.Build();

app.UseFastEndpoints().UseSwaggerGen();

app.Run();
