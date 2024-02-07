using FluentValidation;
using HexagonalArchitecture.Warehouse.Domain.Entities;
using HexagonalArchitecture.Warehouse.Domain.Services;

namespace HexagonalArchitecture.Warehouse.Controllers;

public static class StockEndpoints
{
    public static void MapStockEndpoints(this WebApplication app)
    {
        app.MapGet("/api/v1/stock", (StockService stockService) => Results.Ok(stockService.GetAll()));

        app.MapGet("/api/v1/stock/{id}",
            (string id, StockService stockService) => Results.Ok(stockService.Get(id)));

        app.MapGet("/api/v1/stockAmount/{id}",
            (string id, StockService stockService) => Results.Ok(stockService.GetStockAmount(id)));

        app.MapPost("/api/v1/stock", (Stock stock, IValidator<Stock> validator, StockService stockService) =>
        {
            var validationResult = validator.Validate(stock);

            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors);
            }

            var result = stockService.Add(stock);

            return Results.Created($"/api/items/{stock.StockId}", result);
        });

        app.MapPut("/api/v1/stock/{id}",
            (string id, Stock updatedItem, IValidator<Stock> validator, StockService stockService) =>
            {
                var existingItem = stockService.Get(id).Result;

                if (existingItem == null)
                {
                    return Results.NotFound();
                }

                // Validate the updated item
                var validationResult = validator.Validate(updatedItem);

                if (!validationResult.IsValid)
                {
                    return Results.BadRequest(validationResult.Errors);
                }

                // Update the existing item with the new values (SHOULD MOVE THIS LOGIC TO BUSINESS)
                existingItem.Batch = updatedItem.Batch;
                existingItem.Products = updatedItem.Products;

                return Results.NoContent();
            });

        app.MapDelete("/api/v1/stock/{id}", (string id, StockService stockService) => stockService.Delete(id));
    }
}