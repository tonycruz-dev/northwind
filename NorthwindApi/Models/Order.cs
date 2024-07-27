
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthwindApi.Models;

public class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int? EmployeeId { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? RequiredDate { get; set; }

    public DateTime? ShippedDate { get; set; }

    public int? ShipVia { get; set; }

    [Column(TypeName = "money")]
    public decimal? Freight { get; set; }

    public string? ShipName { get; set; }

    public string? ShipAddress { get; set; }

    public string? ShipCity { get; set; }

    public string? ShipRegion { get; set; }

    public string? ShipPostalCode { get; set; }

    public string? ShipCountry { get; set; }

    public Customer? Customer { get; set; }

    public virtual List<OrderDetail> OrderDetails { get; set; } = [];

}
