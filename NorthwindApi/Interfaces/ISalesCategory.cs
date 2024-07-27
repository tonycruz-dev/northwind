using NorthwindApi.DTOs;
using NorthwindApi.Helpers;

namespace NorthwindApi.Interfaces;

public interface ISalesCategory
{
    Task<SalesCategoryDto> GetCategoriesChartAsync(SalesCategoriesParam categoriesSalesParam);
}
