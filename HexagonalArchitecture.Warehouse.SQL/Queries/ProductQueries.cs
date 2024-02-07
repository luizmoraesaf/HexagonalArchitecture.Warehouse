namespace HexagonalArchitecture.Warehouse.SQL.Queries;

public static class ProductQueries
{
    public static string GetByExternalProductId => "SELECT * FROM Products WHERE ExternalProductId = @ExternalProductId";
    public static string Add => "INSERT INTO Products (ProductId, ExternalProductId, Name, Description, Price, StockId) VALUES (@ProductId, @ExternalProductId, @Name, @Description, @Price, @StockId)";
    public static string Get => "SELECT * FROM Products WHERE ProductId = @ProductId";
    public static string GetAll => "SELECT * FROM Products";
    public static string Update => "UPDATE Products SET ExternalProductId = @ExternalProductId, Name = @Name, Description = @Description, Price = @Price, StockId = @StockId WHERE ProductId = @ProductId";
    public static string Delete => "DELETE FROM Products WHERE ProductId = @ProductId";
}