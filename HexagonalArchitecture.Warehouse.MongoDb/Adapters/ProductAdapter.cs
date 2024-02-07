using HexagonalArchitecture.Warehouse.Domain.Entities;
using HexagonalArchitecture.Warehouse.Domain.InternalPorts;
using HexagonalArchitecture.Warehouse.MongoDb.Infrastructure;
using HexagonalArchitecture.Warehouse.MongoDb.Models;
using MongoDB.Driver;

namespace HexagonalArchitecture.Warehouse.MongoDb.Adapters;

public class ProductAdapter: IProductPort
{
    private readonly IMongoCollection<ProductDbo> _productCollection;
    
    public ProductAdapter(IMongoDatabase database)
    {
        _productCollection = database.GetCollection<ProductDbo>("Product");
    }
    
    public async Task<Product> Add(Product item)
    {
        await _productCollection.InsertOneAsync(item.ToDboProduct());

        return item;
    }

    public async Task<Product?> Get(string id)
    {
        var product = await _productCollection
            .Find(
                Builders<ProductDbo>.Filter.Eq("ProductId", id))
            .FirstOrDefaultAsync();

        return product.FromDboProduct();
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        var products = await _productCollection
            .Find(Builders<ProductDbo>.Filter.Empty)
            .ToListAsync();

        return products.Select(p => p.FromDboProduct());
    }

    public async Task<bool> Update(Product item)
    {
        var result = await _productCollection.ReplaceOneAsync(
            Builders<ProductDbo>.Filter.Eq("ProductId", item.ProductId),
            item.ToDboProduct());

        return result.IsAcknowledged;
    }

    public async Task<bool> Delete(string id)
    {
        var result = await _productCollection.DeleteOneAsync(
            Builders<ProductDbo>.Filter.Eq("ProductId", id));

        return result.IsAcknowledged;
    }

    public async Task<Product?> GetByExternalProductId(string externalProductId)
    {
        var product = await _productCollection
            .Find(
                Builders<ProductDbo>.Filter.Eq("ExternalProductId", externalProductId))
            .FirstOrDefaultAsync();

        return product.FromDboProduct();
    }
}