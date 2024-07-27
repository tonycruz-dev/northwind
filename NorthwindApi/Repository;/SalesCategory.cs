using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NorthwindApi.Constants;
using NorthwindApi.Data;
using NorthwindApi.DTOs;
using NorthwindApi.Helpers;
using NorthwindApi.Interfaces;

namespace NorthwindApi.Repository_;

public class SalesCategory(NorthwindContext _context) : ISalesCategory
{
    public async Task<SalesCategoryDto> GetCategoriesChartAsync(SalesCategoriesParam categoriesSalesParam)
    {
        var fromShippedDateParam = new SqlParameter("@fromSD", $@"{categoriesSalesParam.From.Year}-{categoriesSalesParam.From.Month}-{categoriesSalesParam.From.Day}");
        var toShippedDateParam = new SqlParameter("@toSD", $@"{categoriesSalesParam.To.Year}-{categoriesSalesParam.To.Month}-{categoriesSalesParam.To.Day}");

        var productSales = await _context
            .ProductSales
            .FromSqlRaw(SqlStatements.GetCategoriesSales, fromShippedDateParam, toShippedDateParam)
            .ToListAsync();

        var groupByCategory = productSales
            .OrderBy(ps => ps.CategoryName)
            .GroupBy(ps => new { ps.CategoryName })
            .Select(ps => new
            {
                categoryName = ps.Key.CategoryName,
                totalSales = ps.Sum(p => p.Sales)
            }).ToList();

        var result = new SalesCategoryDto
        {
            CategoryNames = groupByCategory.Select(c => c.categoryName).ToList(),
            CategoryResult = groupByCategory.Select(c => c.totalSales).ToList()
        };
        return result;
    }
}
