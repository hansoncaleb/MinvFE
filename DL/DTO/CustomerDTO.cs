namespace DL.DTO;

public partial class CustomerDTO
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public IEnumerable<OrderDTO> Orders { get; set; } = new List<OrderDTO>();
}
