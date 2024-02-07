namespace HexagonalArchitecture.Warehouse.MongoDb.Models;

public class StockDbo
{
    public string StockId { get; set; }
    public int Batch { get; set; }
    public List<ProductDbo> Products { get; set; }
}