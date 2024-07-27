namespace NorthwindApi.DTOs;

public class SalesCategoryDto
{
    public List<string> CategoryNames { get; set; } = [];
    public List<decimal?> CategoryResult { get; set; } = [];
}