using HexagonalArchitecture.Warehouse.Domain.Entities;
using HexagonalArchitecture.Warehouse.Domain.InternalPorts;
using HexagonalArchitecture.Warehouse.MongoDb.Entities;
using HexagonalArchitecture.Warehouse.MongoDb.Infrastructure;
using MongoDB.Driver;

namespace HexagonalArchitecture.Warehouse.MongoDb.Adapters;

public class StockAdapter: IStockPort
{
    private readonly IMongoCollection<StockDbo> _stockCollection;
    
    public StockAdapter(IMongoDatabase database)
    {
        _stockCollection = database.GetCollection<StockDbo>("Stock");
    }
    
    public async Task<Stock> Add(Stock item)
    {
        await _stockCollection.InsertOneAsync(item.ToDboStock());

        return item;
    }

    public async Task<Stock?> Get(string id)
    {
        var stock = await _stockCollection
            .Find(
                Builders<StockDbo>.Filter.Eq("StockId", id))
            .FirstOrDefaultAsync();

        return stock.FromDboStock();
    }

    public async Task<IEnumerable<Stock>> GetAll()
    {
        var stocks = await _stockCollection
            .Find(Builders<StockDbo>.Filter.Empty)
            .ToListAsync();

        return stocks.Select(s => s.FromDboStock());
    }

    public async Task<bool> Update(Stock item)
    {
        var result = await _stockCollection.ReplaceOneAsync(
            Builders<StockDbo>.Filter.Eq("StockId", item.StockId),
            item.ToDboStock());

        return result.IsAcknowledged;
    }

    public async Task<bool> Delete(string id)
    {
        var result = await _stockCollection.DeleteOneAsync(
            Builders<StockDbo>.Filter.Eq("StockId", id));

        return result.IsAcknowledged;
    }

    public async Task<int> GetStockAmount(string productId)
    {
        var stock = await _stockCollection
            .Find(
                Builders<StockDbo>.Filter.Eq("ProductId", productId))
            .FirstOrDefaultAsync();

        return stock?.Products.Count ?? 0;
    }
}