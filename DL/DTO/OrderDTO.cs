namespace DL.DTO;

public partial class OrderDTO
{
    public int Id { get; set; }

    public DateTime OrderPlaced { get; set; }

    public DateTime? OrderFulfilled { get; set; }

    public int CustomerId { get; set; }

    public IEnumerable<OrderDetailDTO> OrderDetails { get; set; } = new List<OrderDetailDTO>();
}
