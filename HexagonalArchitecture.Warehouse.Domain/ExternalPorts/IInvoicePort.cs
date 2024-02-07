namespace HexagonalArchitecture.Warehouse.Domain.ExternalPorts;

public interface IInvoicePort
{
    bool GenerateInvoice(string recipient, string invoiceNumber, string invoiceText);
}