using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.EntityFrameworkCore;
using NorthwindApi.Data;
using NorthwindApi.Models;

namespace NorthwindApi.OdataControllers;

[Route("odata/OrderDetails")]
[Tags("OrderDetails")]
[ApiController]
[ODataAttributeRouting]
public class OrderDetailOdataController(NorthwindContext _context) : Controller
{

    [HttpGet]
    [EnableQuery(PageSize = 100)]
    public IQueryable<OrderDetail> Get()
    {
        return _context.OrderDetails.AsNoTracking();
    }
}
