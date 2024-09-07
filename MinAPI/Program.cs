using DL;
using DL.Interfaces;
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


app.MapGet("/customers", async (IMainService main) =>
{
    var customers = await main.GetCustomersAsync();
    return Results.Ok(customers);
})
.WithName("GetCustomers")
.WithOpenApi();

app.Run();

