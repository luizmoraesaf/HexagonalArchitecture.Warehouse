namespace HexagonalArchitecture.Warehouse.Domain.Entities;

public class Stock
{
    public string StockId { get; set; }
    public int Batch { get; set; }
    public List<Product> Products { get; set; }
}