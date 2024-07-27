using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.EntityFrameworkCore;
using NorthwindApi.Data;
using NorthwindApi.Models;

namespace NorthwindApi.OdataControllers;

[Route("odata/Products")]
[Tags("Products")]
[ApiController]
[ODataAttributeRouting]
public class ProductsOdataController(NorthwindContext _context) : Controller
{

    [HttpGet]
    [EnableQuery(PageSize = 100)]
    public IQueryable<Product> Get()
    {
        return _context.Products.AsNoTracking();
    }
}