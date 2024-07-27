using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.EntityFrameworkCore;
using NorthwindApi.Data;
using NorthwindApi.Models;

namespace NorthwindApi.OdataControllers;

[Route("odata/Categories")]
[Tags("Categories")]
[ApiController]
[ODataAttributeRouting]
public class CategoriesOdataController(NorthwindContext _context) : Controller
{
    [HttpGet]
    [EnableQuery(PageSize = 250)]
    public IQueryable<Category> Get()
    {
        return _context.Categories.AsNoTracking();
    }
}
