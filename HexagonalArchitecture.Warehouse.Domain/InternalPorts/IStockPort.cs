using HexagonalArchitecture.Warehouse.Domain.Entities;
using HexagonalArchitecture.Warehouse.Domain.Interfaces;

namespace HexagonalArchitecture.Warehouse.Domain.InternalPorts;

public interface IStockPort : IBasePort<Stock>
{
    Task<int> GetStockAmount(string productId);
}