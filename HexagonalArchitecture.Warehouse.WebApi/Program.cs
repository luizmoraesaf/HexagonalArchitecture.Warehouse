using FluentValidation;
using HexagonalArchitecture.Warehouse.Controllers;
using HexagonalArchitecture.Warehouse.Domain.Entities;
using HexagonalArchitecture.Warehouse.Domain.Services;
using HexagonalArchitecture.Warehouse.Domain.Validators;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Validators
builder.Services.TryAddScoped<IValidator<Stock>, StockValidator>();
builder.Services.TryAddScoped<IValidator<Product>, ProductValidator>();   

// Service Layer
// Here we have the database connection, stock adapter using mongo and product adapter using SQL were we can switch when we want
var client = new MongoClient(builder.Configuration["DatabaseSettings:ConnectionString"]!);
var database = client.GetDatabase(builder.Configuration["DatabaseSettings:DatabaseName"]!);

builder.Services.TryAddScoped<StockService>(sp => new StockService(new HexagonalArchitecture.Warehouse.MongoDb.Adapters.StockAdapter(database)));
builder.Services.TryAddScoped<ProductService>(sp => new ProductService(new HexagonalArchitecture.Warehouse.SQL.Adapters.ProductAdapter(builder.Configuration)));

app.MapStockEndpoints();
app.MapProductEndpoints();

app.Run();