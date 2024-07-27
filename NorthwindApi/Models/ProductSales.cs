namespace NorthwindApi.Models;

public partial class ProductSales
{
    public string CategoryName { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public decimal? Sales { get; set; }
}
