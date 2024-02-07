using System.Data;
using System.Data.SqlClient;
using Dapper;
using HexagonalArchitecture.Warehouse.Domain.Entities;
using HexagonalArchitecture.Warehouse.Domain.InternalPorts;
using HexagonalArchitecture.Warehouse.SQL.Queries;
using Microsoft.Extensions.Configuration;

namespace HexagonalArchitecture.Warehouse.SQL.Adapters;

public class StockAdapter : IStockPort
{
    private readonly IConfiguration _configuration;

    public StockAdapter(IConfiguration configuration)
    {
        this._configuration = configuration;
    }

    public async Task<Stock> Add(Stock item)
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection"));
        connection.Open();
        var result = await connection.ExecuteAsync(StockQueries.Add, item);
        return item;
    }

    public async Task<Stock?> Get(string id)
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection"));
        connection.Open();
        var result = await connection.QuerySingleOrDefaultAsync<Stock>(StockQueries.Get, new { StockId = id });
        return result;
    }

    public async Task<IEnumerable<Stock>> GetAll()
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection"));
        connection.Open();
        var result = await connection.QueryAsync<Stock>(StockQueries.GetAll);
        return result.ToList();
    }

    public async Task<bool> Update(Stock item)
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection"));
        connection.Open();
        var result = await connection.ExecuteAsync(StockQueries.Update, item);
        return result.ToString() != "";
    }

    public async Task<bool> Delete(string id)
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection"));
        connection.Open();
        var result = await connection.ExecuteAsync(StockQueries.Delete, new { StockId = id });
        return result.ToString() != "";
    }

    public async Task<int> GetStockAmount(string productId)
    {
        using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString("DBConnection"));
        connection.Open();
        var result = await connection.ExecuteAsync(StockQueries.GetStockAmount, new { StockId = productId });
        return result;
    }
}