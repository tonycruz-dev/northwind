using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.EntityFrameworkCore;
using NorthwindApi.Data;
using NorthwindApi.Models;

namespace NorthwindApi.OdataControllers;

[Route("odata/Customers")]
[Tags("Customers")]
[ApiController]
[ODataAttributeRouting]
public class CustomersODController(NorthwindContext _context) : Controller
{
    [HttpGet]
    [EnableQuery(PageSize = 100)]
    public IQueryable<Customer> Get()
    {
        return _context.Customers.AsNoTracking();
    }
}
