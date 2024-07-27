using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindApi.Models;

public partial class OrderDetail
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal UnitPrice { get; set; }

    [Column(TypeName = "money")]
    public decimal ExtendedPrice { get; set; }

    public short Quantity { get; set; }

    public float Discount { get; set; }

    public string? ImageUrl { get; set; }

    public Order Order { get; set; } = null!;

    public Product Product { get; set; } = null!;
}
