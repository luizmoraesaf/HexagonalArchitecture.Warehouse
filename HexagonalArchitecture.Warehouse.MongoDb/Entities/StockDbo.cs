namespace HexagonalArchitecture.Warehouse.MongoDb.Entities;

public class StockDbo
{
    public string StockId { get; set; }
    public int Batch { get; set; }
    public List<ProductDbo> Products { get; set; }
}