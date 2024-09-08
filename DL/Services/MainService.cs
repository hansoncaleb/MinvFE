using DL.DTO;
using DL.Interfaces;
using DL.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace DL.Services;

public class MainService(FalkonExampleContext context) : IMainService
{
    public async Task<List<CustomerDTO>?> GetCustomersAsync() =>
        await context.Customers.AsQueryable<Customer>()
        .AsNoTracking().ProjectToType<CustomerDTO>().ToListAsync();

    public async Task<CustomerDTO?> GetCustomerAsync(int id) =>
        (await context.Customers.FindAsync(id))?.Adapt<Customer, CustomerDTO>();
}
