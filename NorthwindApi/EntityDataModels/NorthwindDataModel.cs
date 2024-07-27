using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using NorthwindApi.Models;
using System.Drawing;

namespace NorthwindApi.EntityDataModels;

public class NorthwindDataModel
{
    public IEdmModel GetEntityDataModel()
    {
        var builder = new ODataConventionModelBuilder
        {
            Namespace = "Northwind",
            ContainerName = "NorthwindContainer"
        };
        builder.EntitySet<Order>("Orders");
        builder.EntitySet<Customer>("Customers");
        builder.EntitySet<Product>("Products");
        builder.EntitySet<Supplier>("Suppliers");
        builder.EntitySet<Category>("Categories");
        builder.EntitySet<OrderDetail>("OrderDetails");
        builder.EnableLowerCamelCase(NameResolverOptions.ProcessReflectedPropertyNames);
        return builder.GetEdmModel();
    }
}
