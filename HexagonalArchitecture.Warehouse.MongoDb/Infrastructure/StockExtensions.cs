using HexagonalArchitecture.Warehouse.Domain.Entities;
using HexagonalArchitecture.Warehouse.MongoDb.Models;

namespace HexagonalArchitecture.Warehouse.MongoDb.Infrastructure;

public static class StockExtensions
{
    public static StockDbo ToDboStock(this Stock stock)
    {
        if (stock == null)
            return null;

        return new StockDbo()
        {
            StockId = stock.StockId,
            Products =  stock.Products.Select(p => p.ToDboProduct()).ToList(),
            Batch = stock.Batch
        };
    }

    public static Stock FromDboStock(this StockDbo stockDbo)
    {
        if (stockDbo == null)
            return null;

        return new Stock()
        {
            StockId = stockDbo.StockId,
            Products = stockDbo.Products.Select(p => p.FromDboProduct()).ToList(),
            Batch = stockDbo.Batch
        };
    }
    
}