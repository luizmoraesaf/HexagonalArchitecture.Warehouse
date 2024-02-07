namespace HexagonalArchitecture.Warehouse.SQL.Queries;

public static class StockQueries
{
    public const string Add = "INSERT INTO Stock (StockId, Batch) VALUES (@StockId, @Batch)";
    public const string Get = "SELECT * FROM Stock WHERE StockId = @StockId";
    public const string GetAll = "SELECT * FROM Stock";
    public const string Update = "UPDATE Stock SET StockId = @StockId, Batch = @Batch WHERE StockId = @StockId";
    public const string Delete = "DELETE FROM Stock WHERE StockId = @StockId";
    public const string GetStockAmount = "SELECT COUNT(*) FROM Stock WHERE StockId = @StockId";
    public const string AddProductToStock = "INSERT INTO StockProduct (StockId, ProductId) VALUES (@StockId, @ProductId)";
    public const string GetProducts = "SELECT * FROM Product WHERE ProductId IN (SELECT ProductId FROM StockProduct WHERE StockId = @StockId)";
    public const string RemoveProductFromStock = "DELETE FROM StockProduct WHERE StockId = @StockId AND ProductId = @ProductId";
    public const string GetStockByProductId = "SELECT * FROM Stock WHERE StockId IN (SELECT StockId FROM StockProduct WHERE ProductId = @ProductId)";
    public const string GetStockByExternalProductId = "SELECT * FROM Stock WHERE StockId IN (SELECT StockId FROM StockProduct WHERE ProductId IN (SELECT ProductId FROM Product WHERE ExternalProductId = @ExternalProductId))";
    public const string GetStockByProductIds = "SELECT * FROM Stock WHERE StockId IN (SELECT StockId FROM StockProduct WHERE ProductId IN @ProductIds)";
    public const string GetStockByExternalProductIds = "SELECT * FROM Stock WHERE StockId IN (SELECT StockId FROM StockProduct WHERE ProductId IN (SELECT ProductId FROM Product WHERE ExternalProductId IN @ExternalProductIds))";
    public const string GetStockByProduct = "SELECT * FROM Stock WHERE StockId IN (SELECT StockId FROM StockProduct WHERE ProductId = @ProductId)";
    public const string GetStockByExternalProduct = "SELECT * FROM Stock WHERE StockId IN (SELECT StockId FROM StockProduct WHERE ProductId IN (SELECT ProductId FROM Product WHERE ExternalProductId = @ExternalProductId))";
    public const string GetStockByProducts = "SELECT * FROM Stock WHERE StockId IN (SELECT StockId FROM StockProduct WHERE ProductId IN @ProductIds)";
    public const string GetStockByExternalProducts = "SELECT * FROM Stock WHERE StockId IN (SELECT StockId FROM StockProduct WHERE ProductId IN (SELECT ProductId FROM Product WHERE ExternalProductId IN @ExternalProductIds))";
}