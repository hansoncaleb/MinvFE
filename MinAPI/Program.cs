using DL;
using DL.Interfaces;
using DL.Models;
using DL.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FalkonExampleContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MainConnection"));
});

builder.Services.AddScoped<IMainService, MainService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var customerGroup = app.MapGroup("customers");

customerGroup.MapGet("/all", async (IMainService main) =>
{
    var customers = await main.GetCustomersAsync();
    return Results.Ok(customers);
})
.WithOpenApi();

customerGroup.MapGet("/{customerId:int}", async (int customerId, IMainService main) =>
{
    var customers = await main.GetCustomerAsync(customerId);
    return Results.Ok(customers);
})
.WithOpenApi();

app.Run();

