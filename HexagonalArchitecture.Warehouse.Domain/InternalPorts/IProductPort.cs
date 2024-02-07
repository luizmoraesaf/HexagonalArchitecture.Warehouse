using HexagonalArchitecture.Warehouse.Domain.Entities;
using HexagonalArchitecture.Warehouse.Domain.Interfaces;

namespace HexagonalArchitecture.Warehouse.Domain.InternalPorts;

public interface IProductPort: IBasePort<Product>
{
    Task<Product?> GetByExternalProductId(string externalProductId);
}