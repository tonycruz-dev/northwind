using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindApi.Models;

public class Category
{
    public int Id { get; set; }

    [StringLength(50)]
    public required string CategoryName { get; set; }
   

    public string? Description { get; set; } = string.Empty;

    public string? ImageUrl { get; set; } = string.Empty;
    public List<Product> Products { get; set; } = [];
}
