using HexagonalArchitecture.Warehouse.Domain.Entities;
using HexagonalArchitecture.Warehouse.Domain.InternalPorts;

namespace HexagonalArchitecture.Warehouse.Domain.Services;

public class StockService
{
    private readonly IStockPort _stockPort;
    
    public StockService(IStockPort stockPort)
    {
        _stockPort = stockPort;
    }

    public Task<int> GetStockAmount(string productId) => _stockPort.GetStockAmount(productId);
    public Task<Stock> Add(Stock item) => _stockPort.Add(item);
    public Task<Stock> Get(string id) => _stockPort.Get(id);
    public Task<IEnumerable<Stock>> GetAll() => _stockPort.GetAll();
    public Task<bool> Update(Stock item) => _stockPort.Update(item);
    public Task<bool> Delete(string id) => _stockPort.Delete(id);
}