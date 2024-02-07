using FluentValidation;
using HexagonalArchitecture.Warehouse.Domain.Entities;
using HexagonalArchitecture.Warehouse.Domain.Services;

namespace HexagonalArchitecture.Warehouse.Controllers;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this WebApplication app)
    {
        app.MapGet("/api/v1/product", async (ProductService productService) => Results.Ok(await productService.GetAll()));

        app.MapGet("/api/v1/product/{id}", async (string id, ProductService productService) => Results.Ok(await productService.Get(id)));
        
        app.MapGet("/api/v1/productByExternalId/{id}", async (string id, ProductService productService) => Results.Ok(await productService.GetByExternalProductId(id)));

        app.MapPost("/api/v1/product", async (Product product, IValidator<Product> validator, ProductService productService) =>
        {
            var validationResult = await validator.ValidateAsync(product);

            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors);
            }

            var result = await productService.Add(product);
            
            return Results.Created($"/api/items/{product.ProductId}", result);
        });

        app.MapPut("/api/v1/product/{id}", async (string id, Product updatedItem, IValidator<Product> validator, ProductService productService) =>
        {
            var existingItem = await productService.Get(id);

            if (existingItem == null)
            {
                return Results.NotFound();
            }

            // Validate the updated item
            var validationResult = await validator.ValidateAsync(updatedItem);

            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors);
            }

            // Update the existing item with the new values (SHOULD MOVE THIS LOGIC TO BUSINESS)
            existingItem.Name = updatedItem.Name;
            existingItem.Description = updatedItem.Description;
            existingItem.GrossValue = updatedItem.GrossValue;
            existingItem.NetValue = updatedItem.NetValue;
            
            await productService.Update(existingItem);

            return Results.NoContent();
        });

        app.MapDelete("/api/v1/product/{id}", async (string id, ProductService productService) => await productService.Delete(id));
    }
}