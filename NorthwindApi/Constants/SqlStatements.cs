namespace NorthwindApi.Constants;

public static class SqlStatements
{
    public const string GetCategoriesSales = @"
       SELECT Categories.CategoryName, Products.ProductName, 
        Sum(CONVERT(money,([OrderDetails].[ExtendedPrice]))) AS Sales
        FROM (Categories INNER JOIN Products ON Categories.Id = Products.CategoryID) 
	        INNER JOIN (Orders 
		        INNER JOIN [OrderDetails] ON Orders.Id = [OrderDetails].OrderID) 
	        ON Products.Id = OrderDetails.ProductId
	        WHERE (((Orders.ShippedDate) Between @fromSD AND @toSD))
        GROUP BY Categories.CategoryName, Products.ProductName
    ";
}