using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.EntityFrameworkCore;
using NorthwindApi.Data;
using NorthwindApi.Models;

namespace NorthwindApi.OdataControllers;

[Route("odata/Orders")]
[Tags("Orders")]
[ApiController]
[ODataAttributeRouting]
public class OrdersOdataController(NorthwindContext _context) : Controller
{
    [HttpGet]
    [EnableQuery(PageSize = 100)]
    public IQueryable<Order> Get()
    {
        return _context.Orders.AsNoTracking();
    }
}
