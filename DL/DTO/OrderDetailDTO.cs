namespace DL.DTO;

public partial class OrderDetailDTO
{
    public int Id { get; set; }

    public int Quantity { get; set; }

    public int ProductId { get; set; }

    public int OrderId { get; set; }

    public ProductDTO Product { get; set; } = null!;
}
