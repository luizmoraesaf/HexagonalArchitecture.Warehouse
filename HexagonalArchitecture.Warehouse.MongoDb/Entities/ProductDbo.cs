namespace HexagonalArchitecture.Warehouse.MongoDb.Entities;

public class ProductDbo
{
    public string ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double GrossValue { get; set; }
    public double NetValue { get; set; }
    public string ParentProductId { get; set; }
    public string ExternalProductId { get; set; }
}