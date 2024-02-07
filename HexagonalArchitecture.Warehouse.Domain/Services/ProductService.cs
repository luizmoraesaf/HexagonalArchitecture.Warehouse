using HexagonalArchitecture.Warehouse.Domain.Entities;
using HexagonalArchitecture.Warehouse.Domain.InternalPorts;

namespace HexagonalArchitecture.Warehouse.Domain.Services;

public class ProductService
{
    private readonly IProductPort _productPort;
    
    public ProductService(IProductPort productPort)
    {
        _productPort = productPort;
    }
    
    public Task<Product> GetByExternalProductId(string externalProductId) => _productPort.GetByExternalProductId(externalProductId);
    public Task<Product> Add(Product item) => _productPort.Add(item);
    public Task<Product> Get(string id) => _productPort.Get(id);
    public Task<IEnumerable<Product>> GetAll() => _productPort.GetAll();
    public Task<bool> Update(Product item) => _productPort.Update(item);
    public Task<bool> Delete(string id) => _productPort.Delete(id);
}