
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindApi.Models;

public class Product
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public int? SupplierId { get; set; }

    public int? CategoryId { get; set; }

    public string? QuantityPerUnit { get; set; }

    [Column(TypeName = "money")]
    public decimal? UnitPrice { get; set; }

    public short? UnitsInStock { get; set; }

    public short? UnitsOnOrder { get; set; }

    public short? ReorderLevel { get; set; }

    public bool Discontinued { get; set; }

    public string? ImageUrl { get; set; }

    public Category? Category { get; set; }

    public List<OrderDetail> OrderDetails { get; set; } = [];

    public Supplier? Supplier { get; set; }
}
