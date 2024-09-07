using DL.DTO;

namespace DL.Interfaces
{
    public interface IMainService
    {
        Task<CustomerDTO?> GetCustomerAsync(int id);
        Task<List<CustomerDTO>?> GetCustomersAsync();
    }
}