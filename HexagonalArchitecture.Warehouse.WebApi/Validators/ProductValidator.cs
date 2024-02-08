using FluentValidation;
using HexagonalArchitecture.Warehouse.Domain.Entities;

namespace HexagonalArchitecture.Warehouse.Validators;

public class ProductValidator: AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.ExternalProductId).NotEmpty().WithMessage("External Product Id is required");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(x => x.GrossValue).NotEmpty().WithMessage("Gross Value is required");
        RuleFor(x => x.NetValue).NotEmpty().WithMessage("Net Value is required");
    }
}