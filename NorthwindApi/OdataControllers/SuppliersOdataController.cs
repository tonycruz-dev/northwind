using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.EntityFrameworkCore;
using NorthwindApi.Data;
using NorthwindApi.Models;

namespace NorthwindApi.OdataControllers;

[Route("odata/Suppliers")]
[Tags("Suppliers")]
[ApiController]
[ODataAttributeRouting]
public class SuppliersOdataController : Controller
{
    private readonly NorthwindContext _context;

    public SuppliersOdataController(NorthwindContext context)
    {
        _context = context;
    }
    [HttpGet]
    [EnableQuery(PageSize = 100)]
    public IQueryable<Supplier> Get()
    {
        return _context.Suppliers.AsNoTracking();
    }
}