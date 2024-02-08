using FluentValidation;
using HexagonalArchitecture.Warehouse.Domain.Entities;

namespace HexagonalArchitecture.Warehouse.Validators;

public class StockValidator : AbstractValidator<Stock>
{
    public StockValidator()
    {
        RuleFor(x => x.Products).NotEmpty().WithMessage("Products are required");
        RuleFor(x => x.Batch).NotEmpty().WithMessage("Batch is required");
        RuleFor(x => x.StockId).NotEmpty().WithMessage("Stock is required");
    }
}