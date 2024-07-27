using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthwindApi.Data;
using NorthwindApi.Models;

namespace NorthwindApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController(NorthwindContext _context) : ControllerBase
{

    // GET: api/Orders/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrder(int id)
    {
        var order = await _context.Orders.FindAsync(id);

        if (order == null)
        {
            return NotFound();
        }

        return order;
    }

    // PUT: api/Orders/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutOrder(int id, Order order)
    {
        if (id != order.Id)
        {
            return BadRequest();
        }

        _context.Entry(order).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!OrderExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Orders
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Order>> PostOrder(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetOrder", new { id = order.Id }, order);
    }

    // DELETE: api/Orders/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null)
        {
            return NotFound();
        }

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool OrderExists(int id)
    {
        return _context.Orders.Any(e => e.Id == id);
    }

    // GET: api/Orders/5
    [HttpGet("AddOrdera")]
    public async Task<ActionResult> AddOrdera()
    {
        var orderFrom = new DateTime(2023, 1, 1, 0, 0, 0);
        var orderTo = new DateTime(2023, 07, 31, 23, 59, 0);
        var order = await _context.Orders
            .Include(i => i.OrderDetails)
            .Where(x => x.OrderDate >= orderFrom && x.OrderDate <= orderTo)
            .ToListAsync();

        foreach (var item in order)
        {
            var newOrder = new Order();
            var shippedDate = item.OrderDate.Value.AddDays(3);
            var requiredDate = item.OrderDate.Value.AddDays(7);
            newOrder.CustomerId = item.CustomerId;
            newOrder.EmployeeId = item.EmployeeId;
            newOrder.OrderDate = new DateTime(2024, item.OrderDate.Value.Month, item.OrderDate.Value.Day, 0, 0, 0);
            newOrder.RequiredDate = new DateTime(2024, item.OrderDate.Value.Month, requiredDate.Day, 0, 0, 0);
            newOrder.ShippedDate = new DateTime(2024, item.OrderDate.Value.Month, shippedDate.Day, 0, 0, 0);
            newOrder.ShipVia = item.ShipVia;
            newOrder.Freight = item.Freight;
            newOrder.ShipName = item.ShipName;
            newOrder.ShipAddress = item.ShipAddress;
            newOrder.ShipCity = item.ShipCity;
            newOrder.ShipRegion = item.ShipRegion;
            newOrder.ShipPostalCode = item.ShipPostalCode;
            newOrder.ShipCountry = item.ShipCountry;

            foreach (var detail in item.OrderDetails)
            {
                var newDetail = new OrderDetail();
                //newDetail.OrderId = detail.OrderId;
                newDetail.ProductId = detail.ProductId;
                newDetail.UnitPrice = detail.UnitPrice;
                newDetail.Quantity = detail.Quantity;
                newDetail.Discount = detail.Discount;
                newOrder.OrderDetails.Add(newDetail);
            }
            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();



        }
        return Ok(order);
    }
}