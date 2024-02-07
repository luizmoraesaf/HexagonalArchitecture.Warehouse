using System.Data;
using System.Data.SqlClient;
using Dapper;
using HexagonalArchitecture.Warehouse.Domain.Entities;
using HexagonalArchitecture.Warehouse.Domain.InternalPorts;
using HexagonalArchitecture.Warehouse.SQL.Queries;
using Microsoft.Extensions.Configuration;

namespace HexagonalArchitecture.Warehouse.SQL.Adapters;

public class ProductAdapter : IProductPort
{
    private readonly IConfiguration _configuration;

    public ProductAdapter(IConfiguration configuration)
    {
        this._configuration = configuration;
    }

    public async Task<Product> Add(Product item)
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection"));
        connection.Open();
        var result = await connection.ExecuteAsync(ProductQueries.Add, item);
        return item;
    }

    public async Task<Product?> Get(string id)
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection"));
        connection.Open();
        var result = await connection.QuerySingleOrDefaultAsync<Product>(ProductQueries.Get, new { ProductId = id });
        return result;
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection"));
        connection.Open();
        var result = await connection.QueryAsync<Product>(ProductQueries.GetAll);
        return result.ToList();
    }

    public async Task<bool> Update(Product item)
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection"));
        connection.Open();
        var result = await connection.ExecuteAsync(ProductQueries.Update, item);
        return result.ToString() != "";
    }

    public async Task<bool> Delete(string id)
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection"));
        connection.Open();
        var result = await connection.ExecuteAsync(ProductQueries.Delete, new { ProductId = id });
        return result.ToString() != "";
    }

    public async Task<Product?> GetByExternalProductId(string externalProductId)
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection"));
        connection.Open();
        var result = await connection.QuerySingleOrDefaultAsync<Product>(ProductQueries.GetByExternalProductId, new { ExternalProductId = externalProductId });
        return result;
    }
}