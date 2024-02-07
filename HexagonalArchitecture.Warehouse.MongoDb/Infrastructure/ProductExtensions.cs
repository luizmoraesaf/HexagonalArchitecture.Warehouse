using HexagonalArchitecture.Warehouse.Domain.Entities;
using HexagonalArchitecture.Warehouse.MongoDb.Models;

namespace HexagonalArchitecture.Warehouse.MongoDb.Infrastructure;

public static class ProductExtensions
{
    public static ProductDbo ToDboProduct(this Product product)
    {
        if (product == null)
            return null;

        return new ProductDbo()
        {
            ProductId = product.ProductId,
            ExternalProductId = product.ExternalProductId,
            Name = product.Name,
            Description = product.Description,
            GrossValue = product.GrossValue,
            NetValue = product.NetValue,
            ParentProductId = product.ParentProductId,
        };
    }

    public static Product FromDboProduct(this ProductDbo productDbo)
    {
        if (productDbo == null)
            return null;

        return new Product()
        {
            ProductId = productDbo.ProductId,
            ExternalProductId = productDbo.ExternalProductId,
            Name = productDbo.Name,
            Description = productDbo.Description,
            GrossValue = productDbo.GrossValue,
            NetValue = productDbo.NetValue,
            ParentProductId = productDbo.ParentProductId,
        };
    }
}